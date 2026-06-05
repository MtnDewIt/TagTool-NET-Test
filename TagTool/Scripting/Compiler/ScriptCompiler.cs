using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Ai;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;
using TagTool.Tags.Definitions;
using TagTool.Tags.Definitions.Common;
using TagTool.Common.Logging;

namespace TagTool.Scripting.Compiler
{
    public class ScriptCompiler
    {
        public GameCache Cache { get; }
        public Scenario Definition { get; }

        private List<HsScript> Scripts;
        private List<HsGlobal> Globals;
        private List<HsSyntaxNode> ScriptExpressions;
        private List<TagReferenceBlock> ScriptSourceFileReferences;

        private BinaryWriter StringWriter;
        private Dictionary<string, uint> StringOffsets;

        private ushort NextIdentifier = 0xE37F;
        private HsScript CurrentScript = null;

        private bool IgnoreExternDuplicates;
        private bool EmitPaddingBlocks;

        public ScriptCompiler(GameCache cache, Scenario definition)
        {
            Cache = cache;
            Definition = definition;

            Scripts = new List<HsScript>();
            Globals = new List<HsGlobal>();
            ScriptExpressions = new List<HsSyntaxNode>();
            ScriptSourceFileReferences = new List<TagReferenceBlock>();

            StringWriter = new BinaryWriter(new MemoryStream());
            StringOffsets = new Dictionary<string, uint>();

            IgnoreExternDuplicates = false;
        }

        public void AppendCompileFile(FileInfo file, bool emitPaddingBlocks = false)
        {
            EmitPaddingBlocks = emitPaddingBlocks;
            IgnoreExternDuplicates = true;

            //
            // Reuse exisitng scripts before compiling new ones
            //

            Scripts = Definition.Scripts;
            Globals = Definition.Globals;
            ScriptExpressions = Definition.ScriptExpressions;

            var memoryStream = new MemoryStream(Definition.ScriptStrings);
            var binaryReader = new BinaryReader(memoryStream);
            StringWriter = new BinaryWriter(new MemoryStream());

            // Copy data from BinaryReader to StringWriter
            var buffer = new byte[1024];
            int bytesRead;
            while ((bytesRead = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
            {
                StringWriter.Write(buffer, 0, bytesRead);
            }

            // Set the position of StringWriter
            StringWriter.BaseStream.Position = memoryStream.Length;

            ScriptSourceFileReferences = Definition.ScriptSourceFileReferences;

            //proceed normally
            CompileFile(file, EmitPaddingBlocks);
        }

        public void CompileFile(FileInfo file, bool emitPaddingBlocks = false)
        {
            EmitPaddingBlocks = emitPaddingBlocks;
            if (!file.Exists)
                throw new FileNotFoundException(file.FullName);

            //
            // Read the input file into syntax nodes
            //

            List<IScriptSyntax> nodes;

            using (var fileStream = file.OpenRead())
            {
                // Ensure the file ends with a newline so the parser always
                // sees a clean terminator after the last closing parenthesis.
                var fileBytes = new byte[fileStream.Length];
                fileStream.ReadExactly(fileBytes);

                var paddedStream = new MemoryStream();
                paddedStream.Write(fileBytes, 0, fileBytes.Length);
                if (fileBytes.Length == 0 || (fileBytes[fileBytes.Length - 1] != 10 && fileBytes[fileBytes.Length - 1] != 13))
                    paddedStream.WriteByte(10);
                paddedStream.Position = 0;

                nodes = new ScriptSyntaxReader(paddedStream).ReadToEnd();
            }

            //
            // Parse the input syntax nodes
            //

            foreach (var node in nodes)
                PrecompileToplevel(node);

            foreach (var node in nodes)
                CompileToplevel(node);

            Definition.Scripts = Scripts;
            Definition.Globals = Globals;
            Definition.ScriptExpressions = ScriptExpressions;
            Definition.ScriptStrings = (StringWriter.BaseStream as MemoryStream).ToArray();
            Definition.ScriptSourceFileReferences = ScriptSourceFileReferences;
        }

        private void PrecompileToplevel(IScriptSyntax node)
        {
            switch (node)
            {
                case ScriptGroup group:
                    switch (group.Head)
                    {
                        case ScriptSymbol symbol:
                            switch (symbol.Value)
                            {
                                case "global":
                                    break;

                                case "script":
                                    PrecompileScript(group);
                                    break;
                            }
                            break;

                        default:
                            throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");
                    }
                    break;

                default:
                    throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");
            }
        }

        private void CompileToplevel(IScriptSyntax node)
        {
            switch (node)
            {
                case ScriptGroup group:
                    switch (group.Head)
                    {
                        case ScriptSymbol symbol:
                            switch (symbol.Value)
                            {
                                case "global":
                                    if (EmitPaddingBlocks) EmitScriptPaddingBlocks();
                                    CompileGlobal(group);
                                    break;

                                case "script":
                                    if (EmitPaddingBlocks) EmitScriptPaddingBlocks();
                                    CompileScript(group);
                                    break;
                            }
                            break;

                        default:
                            throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");
                    }
                    break;

                default:
                    throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");
            }
        }

        private HsType ParseHsType(IScriptSyntax node)
        {
            var result = new HsType();

            if (!(node is ScriptSymbol symbol))
                throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

            if (!Enum.TryParse(symbol.Value, true, out result))
                result = HsType.Invalid;

            return result;
        }

        private HsScriptType ParseScriptType(IScriptSyntax node)
        {
            if (!(node is ScriptSymbol symbol) ||
                !Enum.TryParse<HsScriptType>(symbol.Value, true, out var result))
            {
                throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");
            }

            return result;
        }

        private uint CompileStringAddress(string input)
        {
            if (!StringOffsets.ContainsKey(input))
            {
                var offset = (uint)StringWriter.BaseStream.Position;
                StringWriter.Write(input.ToArray());
                StringWriter.Write('\0');
                StringOffsets[input] = offset;
            }

            return StringOffsets[input];
        }

        private void CompileGlobal(IScriptSyntax node)
        {
            //
            // Verify the input syntax node is in the right format
            //

            if (!(node is ScriptGroup group) ||
                !(group.Head is ScriptSymbol symbol && symbol.Value == "global") ||
                !(group.Tail is ScriptGroup declGroup))
            {
                throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");
            }

            //
            // Compile the global type
            //

            var globalType = ParseHsType(declGroup.Head);

            //
            // Compile the global name
            //

            if (!(declGroup.Tail is ScriptGroup declTailGroup))
                throw new ScriptCompilerException(group.Line, $"Malformed declaration.");

            if (!(declTailGroup.Head is ScriptSymbol declName))
                throw new ScriptCompilerException(group.Line, $"Malformed declaration.");

            var globalName = declName.Value;

            //
            // Compile the global initialization expression
            //

            if (!(declTailGroup.Tail is ScriptGroup declTailTailGroup))
                throw new ScriptCompilerException(group.Line, $"Malformed declaration.");

            var globalInit = CompileExpression(globalType, declTailTailGroup.Head);

            //
            // Add an entry to the globals block in the scenario definition
            //

            Globals.Add(new HsGlobal
            {
                Name = globalName,
                Type = globalType,
                InitializationExpressionHandle = globalInit
            });
        }

        private void PrecompileScript(IScriptSyntax node)
        {
            //
            // Verify the input syntax node is in the right format
            //

            if (!(node is ScriptGroup group))
                throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

            if (!(group.Head is ScriptSymbol symbol && symbol.Value == "script"))
                throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

            if (!(group.Tail is ScriptGroup declGroup))
                throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

            //
            // Compile the script type
            //

            var scriptType = ParseScriptType(declGroup.Head);

            //
            // Compile the script return type
            //

            if (!(declGroup.Tail is ScriptGroup declTailGroup))
                throw new ScriptCompilerException(group.Line, $"Malformed declaration.");

            var scriptReturnType = ParseHsType(declTailGroup.Head);

            bool skipReturnType = false;
            if (scriptReturnType == HsType.Invalid)
            {
                scriptReturnType = HsType.Void;
                skipReturnType = true;
            }

            //
            // Compile the script name and parameters (if any)
            //

            ScriptGroup declTailTailGroup;
            if (!skipReturnType && !(declTailGroup.Tail is ScriptGroup))
                throw new ScriptCompilerException(group.Line, $"Malformed declaration.");
            else if (skipReturnType && !(declTailGroup.Head is ScriptSymbol))
                throw new ScriptCompilerException(group.Line, $"Malformed declaration.");
            else
            {
                if (!skipReturnType)
                    declTailTailGroup = (ScriptGroup)declTailGroup.Tail;
                else
                    declTailTailGroup = declTailGroup;
            }

            string scriptName;
            var scriptParams = new List<HsScriptParameter>();

            switch (declTailTailGroup.Head)
            {
                // (script static boolean do_stuff ...)
                case ScriptSymbol declName:
                    scriptName = declName.Value;
                    break;

                // (script static boolean (do_stuff (real a) (real b)) ...)
                case ScriptGroup declNameGroup:
                    {
                        //
                        // Get the name of the script
                        //

                        if (!(declNameGroup.Head is ScriptSymbol declGroupName))
                            throw new ScriptCompilerException(group.Line, $"Malformed declaration.");

                        scriptName = declGroupName.Value;

                        //
                        // Get a list of script parameters
                        //

                        if (!(declNameGroup.Tail is ScriptGroup tailGroup))
                            throw new ScriptCompilerException(group.Line, $"Malformed declaration.");

                        if (!(tailGroup is ScriptGroup declParamGroup))
                            throw new ScriptCompilerException(group.Line, $"Malformed declaration.");

                        for (IScriptSyntax param = declParamGroup;
                            param is ScriptGroup paramGroup;
                            param = paramGroup.Tail)
                        {
                            //
                            // Verify the input parameter syntax is correct: (type name)
                            //

                            if (!(paramGroup.Head is ScriptGroup paramDeclGroup))
                                throw new ScriptCompilerException(group.Line, $"Malformed declaration.");

                            //
                            // Get the parameter type
                            //

                            if (!(paramDeclGroup.Head is ScriptSymbol paramDeclType))
                                throw new ScriptCompilerException(group.Line, $"Malformed declaration.");

                            var paramType = ParseHsType(paramDeclType);

                            //
                            // Get the parameter name
                            //

                            if (!(paramDeclGroup.Tail is ScriptGroup paramDeclTailGroup))
                                throw new ScriptCompilerException(group.Line, $"Malformed declaration.");

                            if (!(paramDeclTailGroup.Head is ScriptSymbol paramDeclName))
                                throw new ScriptCompilerException(group.Line, $"Malformed declaration.");

                            var paramName = paramDeclName.Value;

                            if (!(paramDeclTailGroup.Tail is ScriptInvalid))
                                throw new ScriptCompilerException(group.Line, $"Malformed declaration.");

                            //
                            // Add an entry to the script parameters list
                            //

                            scriptParams.Add(new HsScriptParameter
                            {
                                Name = paramName,
                                Type = paramType
                            });
                        }
                    }
                    break;

                default:
                    throw new ScriptCompilerException(group.Line, $"Malformed declaration.");
            }

            //
            // Add an entry to the scripts block in the scenario definition
            //

            var script = new HsScript
            {
                ScriptName = scriptName,
                Type = scriptType,
                ReturnType = scriptReturnType,
                RootExpressionHandle = DatumHandle.None,
                Parameters = scriptParams
            };

            var exists = false;

            foreach (var s in Scripts)
            {
                if (s.ScriptName != scriptName || s.Parameters.Count != scriptParams.Count)
                    continue;

                if (IgnoreExternDuplicates && s.Type == HsScriptType.Extern && script.Type == HsScriptType.Extern)
                    return;

                exists = true;

                for (var i = 0; i < scriptParams.Count; i++)
                {
                    if (s.Parameters[i].Type != scriptParams[i].Type)
                    {
                        exists = false;
                        break;
                    }
                }

                if (exists)
                    break;
            }

            if (exists)
                throw new ScriptCompilerException(group.Line, $"Script '{scriptName}' is already defined.");

            Scripts.Add(script);
        }

        // Compiles a script body (the statements after the declaration).
        // Bungie's compiler emits the body expressions first, then places the
        // begin Group and FunctionName nodes at the end - so the root node sits
        // at a higher index than its children. We replicate that layout here.
        private DatumHandle CompileScriptBody(HsType returnType, IScriptSyntax body)
        {
            var builtin = Cache.ScriptDefinitions.Scripts.First(x => x.Value.Name == "begin");

            // Compile all body statements first - they get the lower indices
            var firstHandle = DatumHandle.None;
            HsSyntaxNode prevExpr = null;

            for (IScriptSyntax current = body;
                current is ScriptGroup currentGroup;
                current = currentGroup.Tail)
            {
                bool isLast = !(currentGroup.Tail is ScriptGroup);
                var stmtType = isLast ? returnType : HsType.Void;
                var currentHandle = CompileExpression(stmtType, currentGroup.Head);

                if (firstHandle == DatumHandle.None)
                    firstHandle = currentHandle;

                if (prevExpr != null)
                    prevExpr.NextExpressionHandle = currentHandle;

                prevExpr = ScriptExpressions[currentHandle.Index];
            }

            // Now allocate the begin Group and FunctionName nodes at the end
            var beginHandle = AllocateExpression(returnType, HsSyntaxNodeFlags.Group, (ushort)builtin.Key, 0);
            var beginExpr = ScriptExpressions[beginHandle.Index];

            var functionNameHandle = AllocateExpression(HsType.FunctionName, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, (ushort)builtin.Key, 0);
            var functionNameExpr = ScriptExpressions[functionNameHandle.Index];

            Array.Copy(BitConverter.GetBytes(functionNameHandle.Value), beginExpr.Data, 4);
            Array.Copy(BitConverter.GetBytes(0), functionNameExpr.Data, 4);
            functionNameExpr.NextExpressionHandle = firstHandle;

            return beginHandle;
        }

        private void CompileScript(IScriptSyntax node)
        {
            //
            // Verify the input syntax node is in the right format
            //

            if (!(node is ScriptGroup group))
                throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

            if (!(group.Head is ScriptSymbol symbol && symbol.Value == "script"))
                throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

            if (!(group.Tail is ScriptGroup declGroup))
                throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

            //
            // Compile the script type
            //

            var scriptType = ParseScriptType(declGroup.Head);

            //
            // Compile the script return type
            //

            if (!(declGroup.Tail is ScriptGroup declTailGroup))
                throw new ScriptCompilerException(group.Line, $"Malformed declaration.");

            var scriptReturnType = ParseHsType(declTailGroup.Head);

            bool skipReturnType = false;
            if (scriptReturnType == HsType.Invalid)
            {
                scriptReturnType = HsType.Void;
                skipReturnType = true;
            }

            //
            // Compile the script name and parameters (if any)
            //

            ScriptGroup declTailTailGroup;
            if (!skipReturnType && !(declTailGroup.Tail is ScriptGroup))
                throw new ScriptCompilerException(group.Line, $"Malformed declaration.");
            else if (skipReturnType && !(declTailGroup.Head is ScriptSymbol))
                throw new ScriptCompilerException(group.Line, $"Malformed declaration.");
            else
            {
                if (!skipReturnType)
                    declTailTailGroup = (ScriptGroup)declTailGroup.Tail;
                else
                    declTailTailGroup = declTailGroup;
            }

            string scriptName;
            var scriptParams = new List<HsScriptParameter>();

            switch (declTailTailGroup.Head)
            {
                // (script static boolean do_stuff ...)
                case ScriptSymbol declName:
                    scriptName = declName.Value;
                    break;

                // (script static boolean (do_stuff (real a) (real b)) ...)
                case ScriptGroup declNameGroup:
                    {
                        //
                        // Get the name of the script
                        //

                        if (!(declNameGroup.Head is ScriptSymbol declGroupName))
                            throw new ScriptCompilerException(group.Line, $"Malformed declaration.");

                        scriptName = declGroupName.Value;

                        //
                        // Get a list of script parameters
                        //

                        if (!(declNameGroup.Tail is ScriptGroup tailGroup))
                            throw new ScriptCompilerException(group.Line, $"Malformed declaration.");

                        if (!(tailGroup is ScriptGroup declParamGroup))
                            throw new ScriptCompilerException(group.Line, $"Malformed declaration.");

                        for (IScriptSyntax param = declParamGroup;
                            param is ScriptGroup paramGroup;
                            param = paramGroup.Tail)
                        {
                            //
                            // Verify the input parameter syntax is correct: (type name)
                            //

                            if (!(paramGroup.Head is ScriptGroup paramDeclGroup))
                                throw new ScriptCompilerException(group.Line, $"Malformed declaration.");

                            //
                            // Get the parameter type
                            //

                            if (!(paramDeclGroup.Head is ScriptSymbol paramDeclType))
                                throw new ScriptCompilerException(group.Line, $"Malformed declaration.");

                            var paramType = ParseHsType(paramDeclType);

                            //
                            // Get the parameter name
                            //

                            if (!(paramDeclGroup.Tail is ScriptGroup paramDeclTailGroup))
                                throw new ScriptCompilerException(group.Line, $"Malformed declaration.");

                            if (!(paramDeclTailGroup.Head is ScriptSymbol paramDeclName))
                                throw new ScriptCompilerException(group.Line, $"Malformed declaration.");

                            var paramName = paramDeclName.Value;

                            if (!(paramDeclTailGroup.Tail is ScriptInvalid))
                                throw new ScriptCompilerException(group.Line, $"Malformed declaration.");

                            //
                            // Add an entry to the script parameters list
                            //

                            scriptParams.Add(new HsScriptParameter
                            {
                                Name = paramName,
                                Type = paramType
                            });
                        }
                    }
                    break;

                default:
                    throw new ScriptCompilerException(group.Line, $"Malformed declaration.");
            }

            HsScript script = null;

            foreach (var s in Scripts)
            {
                if (s.ScriptName != scriptName || s.Parameters.Count != scriptParams.Count)
                    continue;

                script = s;

                for (var i = 0; i < scriptParams.Count; i++)
                {
                    if (s.Parameters[i].Type != scriptParams[i].Type)
                    {
                        script = null;
                        break;
                    }
                }

                if (script != null)
                    break;
            }

            if (script == null)
                throw new ScriptCompilerException(group.Line, $"Script '{scriptName}' is not defined.");

            CurrentScript = script;

            // Bungie emits body expressions first, then the begin Group/FunctionName wrapper
            // at the end. The engine navigates via pointers so order in the array matters.
            script.RootExpressionHandle = CompileScriptBody(scriptReturnType, declTailTailGroup.Tail);

            CurrentScript = null;
        }

        private DatumHandle CompileExpression(HsType type, IScriptSyntax node)
        {
            if (node is ScriptGroup group)
                return CompileGroupExpression(type, group);

            if (node is ScriptSymbol symbol)
            {
                //
                // Check if the symbol is a reference to a script parameter
                //

                if (CurrentScript != null)
                {
                    foreach (var parameter in CurrentScript.Parameters)
                    {
                        if (parameter.Name != symbol.Value)
                            continue;

                        // When an implicit cast from the parameter's declared type to the
                        // expected type is valid (e.g. unit -> object, vehicle -> unit,
                        // unit -> object_list), emit the node with the TARGET type so the
                        // engine interprets the runtime handle in the correct type context.
                        // Otherwise keep the parameter's natural declared type.
                        if (type == HsType.Unit && !IsImplicitlyCastable(parameter.Type, HsType.Unit))
                            Log.Warning($"Line {symbol.Line}: '{symbol.Value}' has type '{parameter.Type}' which cannot be implicitly cast to 'unit'. Use the (unit) cast function instead.");

                        var emitType = IsImplicitlyCastable(parameter.Type, type) ? type : parameter.Type;
                        return CompileParameterReference(symbol, parameter, emitType);
                    }
                }

                //
                // Check if the symbol is a reference to a script-local global
                //

                foreach (var global in Globals)
                {
                    if (global.Name != symbol.Value)
                        continue;

                    if (type == HsType.Unit && !IsImplicitlyCastable(global.Type, HsType.Unit))
                        Log.Warning($"Line {symbol.Line}: '{symbol.Value}' has type '{global.Type}' which cannot be implicitly cast to 'unit'. Use the (unit) cast function instead.");

                    var emitType = IsImplicitlyCastable(global.Type, type) ? type : global.Type;
                    bool explicitType = (emitType == type && type != HsType.Unparsed);
                    return CompileGlobalReference(symbol, global, emitType, explicitType);
                }

                //
                // Check if the symbol is a reference to a cache (engine-built-in) global
                //

                foreach (var global in Cache.ScriptDefinitions.Globals)
                    if (global.Value.Name == symbol.Value)
                    {
                        var emitType = IsImplicitlyCastable(global.Value.Type, type) ? type : global.Value.Type;
                        return CompileGlobalReference(symbol, emitType, global.Value.Name, (ushort)(global.Key | 0x8000));
                    }
            }

            // Normalize: accept both quoted and unquoted forms bidirectionally.
            // A bare symbol (including "none") becomes a ScriptString transparently.
            ScriptString nodeAsStr = node is ScriptString ss ? ss
                : node is ScriptSymbol sy ? new ScriptString { Value = sy.Value, Line = sy.Line }
                : null;

            // For enum/keyword types, a quoted string or integer is also valid.
            ScriptSymbol nodeAsSym = node is ScriptSymbol sym ? sym
                : node is ScriptString st ? new ScriptSymbol { Value = st.Value, Line = st.Line }
                : node is ScriptInteger si ? new ScriptSymbol { Value = si.Value.ToString(), Line = si.Line }
                : null;

            switch (type)
            {
                case HsType.Unparsed:
                    if (node is ScriptSymbol)
                    {
                        var unparsedHandle = AllocateExpression(HsType.Unparsed, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)((ScriptSymbol)node).Line);
                        if (unparsedHandle != DatumHandle.None)
                            ScriptExpressions[unparsedHandle.Index].StringAddress = CompileStringAddress(((ScriptSymbol)node).Value);
                        return unparsedHandle;
                    }
                    switch (node)
                    {
                        case ScriptBoolean unparsedBoolean:
                            return CompileBooleanExpression(unparsedBoolean);
                        case ScriptReal unparsedReal:
                            return CompileRealExpression(unparsedReal);
                        case ScriptInteger unparsedInteger:
                            if (unparsedInteger.Value < short.MinValue || unparsedInteger.Value > short.MaxValue)
                                return CompileLongExpression(unparsedInteger);
                            return CompileShortExpression(unparsedInteger);
                        case ScriptString unparsedString:
                            return CompileStringExpression(unparsedString);
                    }
                    {
                        var unparsedHandle = AllocateExpression(HsType.Unparsed, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)((node as IScriptSyntax)?.Line ?? 0));
                        return unparsedHandle;
                    }

                case HsType.Boolean:
                    if (node is ScriptBoolean boolValue)
                        return CompileBooleanExpression(boolValue);
                    goto default;

                case HsType.Real:
                    if (node is ScriptReal realValue)
                        return CompileRealExpression(realValue);
                    else if (node is ScriptInteger realIntegerValue)
                        return CompileRealExpression(new ScriptReal { Value = (double)realIntegerValue.Value, Line = realIntegerValue.Line });
                    goto default;

                case HsType.Short:
                    if (node is ScriptInteger shortValue)
                        return CompileShortExpression(shortValue);
                    goto default;

                case HsType.Long:
                    if (node is ScriptInteger longValue)
                        return CompileLongExpression(longValue);
                    goto default;

                case HsType.String:
                    if (nodeAsStr != null) return CompileStringExpression(nodeAsStr);
                    goto default;

                case HsType.Script:
                    if (nodeAsSym != null) return CompileScriptExpression(nodeAsSym);
                    goto default;

                case HsType.StringId:
                    if (nodeAsStr != null) return CompileStringIdExpression(nodeAsStr);
                    goto default;

                case HsType.UnitSeatMapping:
                    if (nodeAsStr != null) return CompileUnitSeatMappingExpression(nodeAsStr);
                    goto default;

                case HsType.TriggerVolume:
                    if (nodeAsStr != null) return CompileScenarioIndexExpression(HsType.TriggerVolume, nodeAsStr,
                        name => Definition.TriggerVolumes.FindIndex(tv => string.Equals(name, Cache.StringTable.GetString(tv.Name), StringComparison.OrdinalIgnoreCase)), 2);
                    goto default;

                case HsType.CutsceneFlag:
                    if (nodeAsStr != null) return CompileScenarioIndexExpression(HsType.CutsceneFlag, nodeAsStr,
                        name => Definition.CutsceneFlags.FindIndex(cf => string.Equals(name, Cache.StringTable.GetString(cf.Name), StringComparison.OrdinalIgnoreCase)), 2);
                    goto default;

                case HsType.CutsceneCameraPoint:
                    if (nodeAsStr != null) return CompileScenarioIndexExpression(HsType.CutsceneCameraPoint, nodeAsStr,
                        name => Definition.CutsceneCameraPoints.FindIndex(ccp => string.Equals(name, ccp.Name, StringComparison.OrdinalIgnoreCase)), 2);
                    goto default;

                case HsType.CutsceneTitle:
                    if (nodeAsStr != null) return CompileScenarioIndexExpression(HsType.CutsceneTitle, nodeAsStr,
                        name => Definition.CutsceneTitles.FindIndex(ct => string.Equals(name, Cache.StringTable.GetString(ct.Name), StringComparison.OrdinalIgnoreCase)), 2);
                    goto default;

                case HsType.CutsceneRecording:
                    throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"The type 'CutsceneRecording' is not yet supported by the compiler.");

                case HsType.DeviceGroup:
                    if (nodeAsStr != null) return CompileScenarioIndexExpression(HsType.DeviceGroup, nodeAsStr,
                        name => Definition.DeviceGroups.FindIndex(dg => string.Equals(dg.Name, name, StringComparison.OrdinalIgnoreCase)), 4);
                    goto default;

                case HsType.Ai:
                    if (nodeAsStr != null) return CompileAiExpression(nodeAsStr, type);
                    goto default;

                case HsType.AiCommandList:
                    throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"The type 'AiCommandList' is not yet supported by the compiler.");

                case HsType.AiCommandScript:
                    if (nodeAsSym != null) return CompileScriptExpression(nodeAsSym, HsType.AiCommandScript, HsScriptType.Command_Script);
                    goto default;

                case HsType.AiBehavior:
                    throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"The type 'AiBehavior' is not yet supported by the compiler.");

                case HsType.AiOrders:
                    throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"The type 'AiOrders' is not yet supported by the compiler.");

                case HsType.AiLine:
                    if (nodeAsStr != null) return CompileStringIdExpression(nodeAsStr, HsType.AiLine);
                    goto default;

                case HsType.StartingProfile:
                    if (nodeAsStr != null) return CompileStartingProfileExpression(nodeAsStr);
                    goto default;

                case HsType.Conversation:
                    throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"The type 'Conversation' is not yet supported by the compiler.");

                case HsType.ZoneSet:
                    if (nodeAsStr != null) return CompileScenarioIndexExpression(HsType.ZoneSet, nodeAsStr,
                        name => Definition.ZoneSets.FindIndex(zs => string.Equals(name, Cache.StringTable.GetString(zs.Name), StringComparison.OrdinalIgnoreCase)), 2);
                    goto default;

                case HsType.DesignerZone:
                    if (nodeAsStr != null) return CompileScenarioIndexExpression(HsType.ZoneSet, nodeAsStr,
                        name => Definition.DesignerZoneSets.FindIndex(dz => string.Equals(name, Cache.StringTable.GetString(dz.Name), StringComparison.OrdinalIgnoreCase)), 2);
                    goto default;

                case HsType.PointReference:
                    if (nodeAsStr != null) return CompilePointReferenceExpression(nodeAsStr);
                    goto default;

                case HsType.Style:
                    if (nodeAsStr != null) return CompileTagExpression<Style>(HsType.Style, nodeAsStr);
                    goto default;

                case HsType.ObjectList:
                    if (nodeAsStr != null) return CompileObjectListExpression(nodeAsStr);
                    goto default;

                case HsType.Folder:
                    if (nodeAsStr != null) return CompileScenarioIndexExpression(HsType.Folder, nodeAsStr,
                        name => Definition.EditorFolders.FindIndex(ef => string.Equals(ef.Name, name, StringComparison.OrdinalIgnoreCase)), 4);
                    goto default;

                case HsType.Sound:
                    if (nodeAsStr != null) return CompileTagExpression<Sound>(HsType.Sound, nodeAsStr);
                    goto default;

                case HsType.Effect:
                    if (nodeAsStr != null) return CompileTagExpression<Effect>(HsType.Effect, nodeAsStr);
                    goto default;

                case HsType.Damage:
                    if (nodeAsStr != null) return CompileTagExpression<DamageEffect>(HsType.Damage, nodeAsStr);
                    goto default;

                case HsType.LoopingSound:
                    if (nodeAsStr != null) return CompileTagExpression<SoundLooping>(HsType.LoopingSound, nodeAsStr);
                    goto default;

                case HsType.AnimationGraph:
                    if (nodeAsStr != null) return CompileTagExpression<ModelAnimationGraph>(HsType.AnimationGraph, nodeAsStr);
                    goto default;

                case HsType.DamageEffect:
                    if (nodeAsStr != null) return CompileTagExpression<DamageEffect>(HsType.DamageEffect, nodeAsStr);
                    goto default;

                case HsType.ObjectDefinition:
                    if (nodeAsStr != null) return CompileUntypedTagExpression(HsType.ObjectDefinition, nodeAsStr, "obje");
                    goto default;

                case HsType.Bitmap:
                    if (nodeAsStr != null) return CompileTagExpression<Bitmap>(HsType.Bitmap, nodeAsStr);
                    goto default;

                case HsType.Shader:
                    if (nodeAsStr != null) return CompileTagExpression<RenderMethod>(HsType.Shader, nodeAsStr);
                    goto default;

                case HsType.RenderModel:
                    if (nodeAsStr != null) return CompileTagExpression<RenderModel>(HsType.RenderModel, nodeAsStr);
                    goto default;

                case HsType.StructureDefinition:
                    if (nodeAsStr != null) return CompileTagExpression<ScenarioStructureBsp>(HsType.StructureDefinition, nodeAsStr);
                    goto default;

                case HsType.LightmapDefinition:
                    throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"The type 'LightmapDefinition' is not yet supported by the compiler.");

                case HsType.CinematicDefinition:
                    if (nodeAsStr != null) return CompileTagExpression<Cinematic>(HsType.CinematicDefinition, nodeAsStr);
                    goto default;

                case HsType.CinematicSceneDefinition:
                    if (nodeAsStr != null) return CompileTagExpression<CinematicScene>(HsType.CinematicSceneDefinition, nodeAsStr);
                    goto default;

                case HsType.BinkDefinition:
                    if (nodeAsStr != null) return CompileTagExpression<Bink>(HsType.BinkDefinition, nodeAsStr);
                    goto default;

                case HsType.AnyTag:
                    if (nodeAsStr != null) return CompileUntypedTagExpression(HsType.AnyTag, nodeAsStr);
                    goto default;

                case HsType.AnyTagNotResolving:
                    if (nodeAsStr != null) return CompileUntypedTagExpression(HsType.AnyTagNotResolving, nodeAsStr);
                    goto default;

                case HsType.GameDifficulty:
                    if (nodeAsSym != null) return CompileEnumExpression<GameDifficulty>(HsType.GameDifficulty, nodeAsSym);
                    goto default;

                case HsType.Team:
                    if (nodeAsSym != null) return CompileEnumExpression<GameTeam>(HsType.Team, nodeAsSym);
                    goto default;

                case HsType.MpTeam:
                    if (nodeAsSym != null) return CompileEnumExpression<GameMultiplayerTeam>(HsType.MpTeam, nodeAsSym);
                    goto default;

                case HsType.Controller:
                    if (nodeAsSym != null) return CompileEnumExpression<GameController>(HsType.Controller, nodeAsSym);
                    goto default;

                case HsType.ButtonPreset:
                    if (nodeAsSym != null) return CompileEnumExpression<GameControllerButtonPreset>(HsType.ButtonPreset, nodeAsSym);
                    goto default;

                case HsType.JoystickPreset:
                    if (nodeAsSym != null) return CompileEnumExpression<GameControllerJoystickPreset>(HsType.JoystickPreset, nodeAsSym);
                    goto default;

                case HsType.PlayerCharacterType:
                    if (nodeAsSym != null) return CompileEnumExpression<GamePlayerCharacterType>(HsType.PlayerCharacterType, nodeAsSym);
                    goto default;

                case HsType.VoiceOutputSetting:
                    if (nodeAsSym != null) return CompileEnumExpression<GameVoiceOutputSetting>(HsType.VoiceOutputSetting, nodeAsSym);
                    goto default;

                case HsType.VoiceMask:
                    if (nodeAsSym != null) return CompileEnumExpression<GameVoiceMask>(HsType.VoiceMask, nodeAsSym);
                    goto default;

                case HsType.SubtitleSetting:
                    if (nodeAsSym != null) return CompileEnumExpression<GameSubtitleSetting>(HsType.SubtitleSetting, nodeAsSym);
                    goto default;

                case HsType.ActorType:
                    if (nodeAsSym != null) return CompileEnumExpression<ActorTypeEnum>(HsType.ActorType, nodeAsSym);
                    goto default;

                case HsType.ModelState:
                    if (nodeAsSym != null) return CompileEnumExpression<GameModelState>(HsType.ModelState, nodeAsSym);
                    goto default;

                case HsType.Event:
                    if (nodeAsSym != null) return CompileEnumExpression<GameEventType>(HsType.Event, nodeAsSym);
                    goto default;

                case HsType.CharacterPhysics:
                    if (nodeAsSym != null) return CompileEnumExpression<GameCharacterPhysics>(HsType.CharacterPhysics, nodeAsSym);
                    goto default;

                case HsType.PrimarySkull:
                    if (nodeAsSym != null) return CompileEnumExpression<GamePrimarySkull>(HsType.PrimarySkull, nodeAsSym);
                    goto default;

                case HsType.SecondarySkull:
                    if (nodeAsSym != null) return CompileEnumExpression<GameSecondarySkull>(HsType.SecondarySkull, nodeAsSym);
                    goto default;

                case HsType.Object:
                    if (nodeAsStr != null) return CompileObjectExpression(nodeAsStr, HsType.Object);
                    goto default;

                case HsType.Unit:
                    if (nodeAsStr != null) return CompileObjectExpression(nodeAsStr, HsType.Unit);
                    goto default;

                case HsType.Vehicle:
                    if (nodeAsStr != null) return CompileObjectExpression(nodeAsStr, HsType.Vehicle);
                    goto default;

                case HsType.Weapon:
                    if (nodeAsStr != null) return CompileObjectExpression(nodeAsStr, HsType.Weapon);
                    goto default;

                case HsType.Device:
                    if (nodeAsStr != null) return CompileObjectExpression(nodeAsStr, HsType.Device);
                    goto default;

                case HsType.Scenery:
                    if (nodeAsStr != null) return CompileObjectExpression(nodeAsStr, HsType.Scenery);
                    goto default;

                case HsType.EffectScenery:
                    if (nodeAsStr != null) return CompileObjectExpression(nodeAsStr, HsType.EffectScenery);
                    goto default;

                case HsType.ObjectName:
                    if (nodeAsStr != null) return CompileObjectNameExpression(nodeAsStr, HsType.ObjectName);
                    goto default;

                case HsType.UnitName:
                    if (nodeAsStr != null) return CompileObjectNameExpression(nodeAsStr, HsType.UnitName, GameObjectTypeHaloOnline.Biped, GameObjectTypeHaloOnline.Giant, GameObjectTypeHaloOnline.Vehicle);
                    goto default;

                case HsType.VehicleName:
                    if (nodeAsStr != null) return CompileObjectNameExpression(nodeAsStr, HsType.VehicleName, GameObjectTypeHaloOnline.Vehicle);
                    goto default;

                case HsType.WeaponName:
                    if (nodeAsStr != null) return CompileObjectNameExpression(nodeAsStr, HsType.WeaponName, GameObjectTypeHaloOnline.Weapon);
                    goto default;

                case HsType.DeviceName:
                    if (nodeAsStr != null) return CompileObjectNameExpression(nodeAsStr, HsType.DeviceName, GameObjectTypeHaloOnline.AlternateRealityDevice, GameObjectTypeHaloOnline.Control, GameObjectTypeHaloOnline.Machine);
                    goto default;

                case HsType.SceneryName:
                    if (nodeAsStr != null) return CompileObjectNameExpression(nodeAsStr, HsType.SceneryName, GameObjectTypeHaloOnline.Scenery);
                    goto default;

                case HsType.EffectSceneryName:
                    if (nodeAsStr != null) return CompileObjectNameExpression(nodeAsStr, HsType.EffectSceneryName, GameObjectTypeHaloOnline.EffectScenery);
                    goto default;

                case HsType.CinematicLightprobe:
                    if (nodeAsStr != null) return CompileScenarioIndexExpression(HsType.CinematicLightprobe, nodeAsStr,
                        name => Definition.CinematicLighting.FindIndex(cl => string.Equals(name, Cache.StringTable.GetString(cl.Name), StringComparison.OrdinalIgnoreCase)), 4);
                    goto default;

                case HsType.AnimationBudgetReference:
                    throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"The type 'AnimationBudgetReference' is not yet supported by the compiler.");

                case HsType.LoopingSoundBudgetReference:
                    throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"The type 'LoopingSoundBudgetReference' is not yet supported by the compiler.");

                case HsType.SoundBudgetReference:
                    throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"The type 'SoundBudgetReference' is not yet supported by the compiler.");

                default:
                    throw new ScriptCompilerException(node.Line, $"Cannot compile expression '{node}' as type '{type}'. Check that the return type matches the script declaration.");
            }
        }

        private void EmitScriptPaddingBlocks(int count = 5)
        {
            for (int i = 0; i < count; i++)
            {
                ScriptExpressions.Add(new HsSyntaxNode
                {
                    Identifier          = 0,
                    Opcode              = 0xBABA,
                    ValueType           = HsType.Invalid,
                    Flags               = HsSyntaxNodeFlags.Invalid,
                    NextExpressionHandle = new DatumHandle(0xBABA, 0xBABA),
                    StringAddress       = 0xBABABABA,
                    Data                = new byte[] { 0xBA, 0xBA, 0xBA, 0xBA },
                    LineNumber          = unchecked((short)0xBABA),
                    Unknown             = unchecked((short)0xBABA),
                });
            }
        }

        private DatumHandle AllocateExpression(HsType valueType, HsSyntaxNodeFlags expressionType, ushort? opcode = null, short? line = null)
        {
            ushort identifier = NextIdentifier;

            if (identifier == ushort.MaxValue)
                identifier = 0xE37F;

            NextIdentifier = (ushort)(identifier + 1);

            uint stringAddress = 0; // TODO?

            var expression = new HsSyntaxNode
            {
                Identifier = identifier,
                Opcode = opcode ?? GetHsTypeAsInteger(valueType),
                ValueType = valueType,
                Flags = expressionType,
                NextExpressionHandle = DatumHandle.None,
                StringAddress = stringAddress,
                Data = BitConverter.GetBytes(-1),
                LineNumber = line.HasValue ? line.Value : (short)-1
            };

            if (!Enum.TryParse(valueType.ToString(), out expression.ValueType))
                expression.ValueType = HsType.Invalid;

            ScriptExpressions.Add(expression);

            return new DatumHandle(identifier, (ushort)ScriptExpressions.IndexOf(expression));
        }

        // Returns true if type is a concrete object subtype
        // (i.e. a runtime object handle that can be upcast to HsType.Object).
        // Does NOT include ObjectList, which is a container, not a subtype.
        private static bool IsObjectSubtype(HsType type)
        {
            switch (type)
            {
                case HsType.Object:
                case HsType.Unit:
                case HsType.Vehicle:
                case HsType.Weapon:
                case HsType.Device:
                case HsType.Scenery:
                case HsType.EffectScenery:
                    return true;
                default:
                    return false;
            }
        }

        // Returns true if type is an object-name index type
        // (scenario ObjectNames table reference).
        private static bool IsObjectNameType(HsType type)
        {
            switch (type)
            {
                case HsType.ObjectName:
                case HsType.UnitName:
                case HsType.VehicleName:
                case HsType.WeaponName:
                case HsType.DeviceName:
                case HsType.SceneryName:
                case HsType.EffectSceneryName:
                    return true;
                default:
                    return false;
            }
        }

        // Returns true if sourceType can be implicitly cast to targetType
        // according to the HaloScript type-casting rules:
        //   passthrough -> any type
        //   any type -> void
        //   boolean <- real, long, short, string
        //   real <- short, long
        //   long <- short, real
        //   short <- long, real
        //   object <- any object subtype or object_name type
        //   unit <- vehicle (and their name equivalents)
        //   vehicle/weapon/device/scenery/effect_scenery <- matching _name type
        //   object_list <- any object subtype or object_name type
        private static bool IsImplicitlyCastable(HsType sourceType, HsType targetType)
        {
            if (sourceType == targetType)
                return true;
            if (sourceType == HsType.Passthrough)
                return true;    // passthrough is compatible with every target
            if (targetType == HsType.Void)
                return true;    // any expression can be discarded as void

            switch (targetType)
            {
                case HsType.Boolean:
                    return sourceType == HsType.Real
                        || sourceType == HsType.Long
                        || sourceType == HsType.Short
                        || sourceType == HsType.String;

                case HsType.Real:
                    return sourceType == HsType.Short || sourceType == HsType.Long;

                case HsType.Long:
                    return sourceType == HsType.Short || sourceType == HsType.Real;

                case HsType.Short:
                    return sourceType == HsType.Long || sourceType == HsType.Real;

                // object accepts any object subtype, any object-name type, or an AI reference
                case HsType.Object:
                    return IsObjectSubtype(sourceType) || IsObjectNameType(sourceType) || sourceType == HsType.Ai;

                // unit accepts, unit_name, vehicle, vehicle_name, or an AI reference
                case HsType.Unit:
                    return sourceType == HsType.Vehicle
                        || sourceType == HsType.UnitName
                        || sourceType == HsType.VehicleName
                        || sourceType == HsType.Ai;

                // specific subtypes accept their matching _name counterpart
                case HsType.Vehicle:
                    return sourceType == HsType.Object || sourceType == HsType.VehicleName || sourceType == HsType.Ai;

                case HsType.Weapon:
                    return sourceType == HsType.Object || sourceType == HsType.WeaponName;

                case HsType.Device:
                    return sourceType == HsType.Object || sourceType == HsType.DeviceName;

                case HsType.Scenery:
                    return sourceType == HsType.Object || sourceType == HsType.SceneryName;

                case HsType.EffectScenery:
                    return sourceType == HsType.Object || sourceType == HsType.EffectSceneryName;

                // object_list accepts a single object/object_name or an AI reference
                case HsType.ObjectList:
                    return IsObjectSubtype(sourceType) || IsObjectNameType(sourceType) || sourceType == HsType.Ai;

                default:
                    return false;
            }
        }

        private ushort GetHsTypeAsInteger(HsType type)
        {
            return (ushort)VersionedEnum.ExportValue(typeof(HsType), type, Cache.Version, Cache.Platform);
        }

        private DatumHandle CompileCondRecursive(
            HsType type,
            int line,
            List<(IScriptSyntax condition, ScriptGroup bodyGroup)> cases,
            int caseIndex)
        {
            var ifBuiltin = Cache.ScriptDefinitions.Scripts.First(x => x.Value.Name == "if");

            // Base case: no more pairs — emit terminal default primitive (type, value=0)
            if (caseIndex >= cases.Count)
            {
                var termHandle = AllocateExpression(type, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)line);
                Array.Copy(BitConverter.GetBytes(0), ScriptExpressions[termHandle.Index].Data, 4);
                return termHandle;
            }

            var (condition, bodyGroup) = cases[caseIndex];

            // Allocate if group
            var ifHandle = AllocateExpression(type, HsSyntaxNodeFlags.Group, (ushort)ifBuiltin.Key, (short)line);
            var ifExpr = ScriptExpressions[ifHandle.Index];

            // Allocate if function-name predicate node
            var fnHandle = AllocateExpression(HsType.FunctionName, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, (ushort)ifBuiltin.Key, (short)line);
            var fnExpr = ScriptExpressions[fnHandle.Index];
            fnExpr.StringAddress = CompileStringAddress("if");
            Array.Copy(BitConverter.GetBytes(fnHandle.Value), ifExpr.Data, 4);
            Array.Copy(BitConverter.GetBytes(0), fnExpr.Data, 4);

            // Compile condition as boolean
            var condHandle = CompileExpression(HsType.Boolean, condition);
            var condExpr = ScriptExpressions[condHandle.Index];
            fnExpr.NextExpressionHandle = condHandle;

            // Compile body — wrap in implicit begin unless it already is one
            bool bodyIsAlreadyBegin = bodyGroup.Head is ScriptGroup bg &&
                                      bg.Head is ScriptSymbol bs &&
                                      bs.Value == "begin" &&
                                      bodyGroup.Tail is ScriptInvalid;
            var bodyHandle = bodyIsAlreadyBegin
                ? CompileExpression(type, bodyGroup.Head)
                : CompileExpression(type, new ScriptGroup { Head = new ScriptSymbol { Value = "begin" }, Tail = bodyGroup });
            var bodyExpr = ScriptExpressions[bodyHandle.Index];
            condExpr.NextExpressionHandle = bodyHandle;

            // Propagate resolved type when parent is Unparsed
            if (type == HsType.Unparsed)
                ifExpr.ValueType = bodyExpr.ValueType;

            // Compile else branch recursively (next case or terminal default)
            var elseHandle = CompileCondRecursive(type, line, cases, caseIndex + 1);
            bodyExpr.NextExpressionHandle = elseHandle;

            return ifHandle;
        }

        private DatumHandle CompileGroupExpression(HsType type, ScriptGroup group)
        {
            if (!(group.Head is ScriptSymbol functionNameSymbol))
                throw new ScriptCompilerException(group.Line, $"Malformed declaration.");

            if (!(group.Tail is ScriptGroup) && !(group.Tail is ScriptInvalid))
                throw new ScriptCompilerException(group.Line, $"Malformed declaration.");

            //
            // Handle special builtin functions
            //

            switch (functionNameSymbol.Value)
            {
                case "begin":
                case "begin_random":
                    {
                        var builtin = Cache.ScriptDefinitions.Scripts.First(x => x.Value.Name == functionNameSymbol.Value);

                        //
                        // Allocate the group and functionName nodes FIRST, before any body
                        // expressions, so that the parent node precedes its children in the
                        // ScriptExpressions list. All other special forms (if, cond, sleep, etc.)
                        // follow this pattern. The old order - compiling body first - produced an
                        // inverted layout where the root begin node sat at a higher index than all
                        // its children, which causes incorrect execution in the engine.
                        //

                        var beginHandle = AllocateExpression(type, HsSyntaxNodeFlags.Group, (ushort)builtin.Key, (short)group.Line);
                        var beginExpr = ScriptExpressions[beginHandle.Index];

                        var functionNameHandle = AllocateExpression(HsType.FunctionName, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, (ushort)builtin.Key, (short)functionNameSymbol.Line);
                        var functionNameExpr = ScriptExpressions[functionNameHandle.Index];
                        functionNameExpr.StringAddress = CompileStringAddress(functionNameSymbol.Value);

                        Array.Copy(BitConverter.GetBytes(functionNameHandle.Value), beginExpr.Data, 4);
                        Array.Copy(BitConverter.GetBytes(0), functionNameExpr.Data, 4);

                        //
                        // Now compile the body expressions. They will receive consecutive indices
                        // immediately following the begin/functionName nodes above.
                        //

                        var firstHandle = DatumHandle.None;
                        HsSyntaxNode prevExpr = null;

                        for (IScriptSyntax current = group.Tail;
                            current is ScriptGroup currentGroup;
                            current = currentGroup.Tail)
                        {
                            // Pass the context type to the last statement so the return
                            // type is correctly promoted (e.g. Short context -> Short result
                            // for arithmetic). All earlier statements are Unparsed.
                            bool isLast = !(currentGroup.Tail is ScriptGroup);
                            var stmtType = isLast ? type : HsType.Void;
                            var currentHandle = CompileExpression(stmtType, currentGroup.Head);

                            if (firstHandle == DatumHandle.None)
                                firstHandle = currentHandle;

                            if (prevExpr != null)
                                prevExpr.NextExpressionHandle = currentHandle;

                            prevExpr = ScriptExpressions[currentHandle.Index];
                        }

                        functionNameExpr.NextExpressionHandle = firstHandle;

                        return beginHandle;
                    }

                case "if":
                    {
                        var builtin = Cache.ScriptDefinitions.Scripts.First(x => x.Value.Name == functionNameSymbol.Value);

                        var ifHandle = AllocateExpression(type, HsSyntaxNodeFlags.Group, (ushort)builtin.Key, (short)group.Line);
                        var ifExpr = ScriptExpressions[ifHandle.Index];
                        // if opcode
                        var functionNameHandle = AllocateExpression(HsType.FunctionName, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, (ushort)builtin.Key, (short)functionNameSymbol.Line);
                        var functionNameExpr = ScriptExpressions[functionNameHandle.Index];
                        functionNameExpr.StringAddress = CompileStringAddress(functionNameSymbol.Value);

                        Array.Copy(BitConverter.GetBytes(functionNameHandle.Value), ifExpr.Data, 4);
                        Array.Copy(BitConverter.GetBytes(0), functionNameExpr.Data, 4);

                        if (!(group.Tail is ScriptGroup booleanGroup))
                            throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");

                        var booleanHandle = CompileExpression(HsType.Boolean, booleanGroup.Head);
                        var booleanExpr = ScriptExpressions[booleanHandle.Index];

                        functionNameExpr.NextExpressionHandle = booleanHandle;

                        if (!(booleanGroup.Tail is ScriptGroup thenGroup))
                            throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");

                        var thenHandle = CompileExpression(type, thenGroup.Head);
                        var thenExpr = ScriptExpressions[thenHandle.Index];

                        if (type == HsType.Unparsed)
                            ifExpr.ValueType = thenExpr.ValueType.DeepClone();

                        booleanExpr.NextExpressionHandle = thenHandle;

                        var nextGroup = thenGroup;
                        var nextExpr = thenExpr;

                        do
                        {
                            if (nextGroup.Tail is ScriptGroup elseGroup)
                            {
                                nextExpr.NextExpressionHandle = CompileExpression(type, elseGroup.Head);
                                nextGroup = elseGroup;
                                nextExpr = ScriptExpressions[nextExpr.NextExpressionHandle.Index];
                            }
                        }
                        while (!(nextGroup.Tail is ScriptInvalid)); // until the end of the nest

                        return ifHandle;
                    }

                case "cond":
                    {
                        var cases = new List<(IScriptSyntax condition, ScriptGroup bodyGroup)>();
                        for (IScriptSyntax cur = group.Tail; cur is ScriptGroup cg; cur = cg.Tail)
                        {
                            if (!(cg.Head is ScriptGroup condGroup) || !(condGroup.Tail is ScriptGroup bodyGroup))
                                throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");
                            cases.Add((condGroup.Head, bodyGroup));
                        }

                        if (cases.Count == 0)
                            throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");

                        return CompileCondRecursive(type, group.Line, cases, 0);
                    }

                case "set":
                    {
                        if (!(group.Tail is ScriptGroup setGroup))
                            throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");

                        if (!(setGroup.Head is ScriptSymbol globalName))
                            throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");

                        if (!(setGroup.Tail is ScriptGroup setValueGroup) || !(setValueGroup.Tail is ScriptInvalid))
                            throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");

                        // --- Check user-defined (script-local) globals first ---
                        foreach (var global in Globals)
                        {
                            if (global.Name != globalName.Value)
                                continue;

                            var builtin = Cache.ScriptDefinitions.Scripts.First(x => x.Value.Name == functionNameSymbol.Value);

                            var setHandle = AllocateExpression(HsType.Void, HsSyntaxNodeFlags.Group, (ushort)builtin.Key, (short)group.Line);
                            var setExpr = ScriptExpressions[setHandle.Index];

                            var functionNameHandle = AllocateExpression(HsType.FunctionName, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, (ushort)builtin.Key, (short)functionNameSymbol.Line);
                            var functionNameExpr = ScriptExpressions[functionNameHandle.Index];
                            functionNameExpr.StringAddress = CompileStringAddress(functionNameSymbol.Value);

                            Array.Copy(BitConverter.GetBytes(functionNameHandle.Value), setExpr.Data, 4);
                            Array.Copy(BitConverter.GetBytes(0), functionNameExpr.Data, 4);

                            var globalHandle = CompileGlobalReference(globalName, global);
                            // Bungie uses opcode 65535 for the set-target global node
                            ScriptExpressions[globalHandle.Index].Opcode = ushort.MaxValue;
                            functionNameExpr.NextExpressionHandle = globalHandle;

                            var globalExpr = ScriptExpressions[globalHandle.Index];
                            globalExpr.NextExpressionHandle = CompileExpression(global.Type, setValueGroup.Head);

                            return setHandle;
                        }

                        // --- Check engine (cache) globals ---
                        foreach (var cacheGlobal in Cache.ScriptDefinitions.Globals)
                        {
                            if (cacheGlobal.Value.Name != globalName.Value)
                                continue;

                            var builtin = Cache.ScriptDefinitions.Scripts.First(x => x.Value.Name == functionNameSymbol.Value);

                            var setHandle = AllocateExpression(HsType.Void, HsSyntaxNodeFlags.Group, (ushort)builtin.Key, (short)group.Line);
                            var setExpr = ScriptExpressions[setHandle.Index];

                            var functionNameHandle = AllocateExpression(HsType.FunctionName, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, (ushort)builtin.Key, (short)functionNameSymbol.Line);
                            var functionNameExpr = ScriptExpressions[functionNameHandle.Index];
                            functionNameExpr.StringAddress = CompileStringAddress(functionNameSymbol.Value);

                            Array.Copy(BitConverter.GetBytes(functionNameHandle.Value), setExpr.Data, 4);
                            Array.Copy(BitConverter.GetBytes(0), functionNameExpr.Data, 4);

                            // Engine globals use (opcode | 0x8000) as their index, and their
                            // type comes from the definition table entry's type field.
                            var globalHandle = CompileGlobalReference(globalName, cacheGlobal.Value.Type, cacheGlobal.Value.Name, (ushort)(cacheGlobal.Key | 0x8000));
                            // Bungie uses opcode 65535 for the set-target global node
                            ScriptExpressions[globalHandle.Index].Opcode = ushort.MaxValue;
                            functionNameExpr.NextExpressionHandle = globalHandle;

                            var globalExpr = ScriptExpressions[globalHandle.Index];
                            globalExpr.NextExpressionHandle = CompileExpression(cacheGlobal.Value.Type, setValueGroup.Head);

                            return setHandle;
                        }

                        throw new ScriptCompilerException(globalName.Line, $"Unknown global variable: '{globalName.Value}'.");
                    }

                case "and":
                case "or":
                    {
                        var builtin = Cache.ScriptDefinitions.Scripts.First(x => x.Value.Name == functionNameSymbol.Value);

                        var handle = AllocateExpression(builtin.Value.Type, HsSyntaxNodeFlags.Group, (ushort)builtin.Key, (short)group.Line);
                        var expr = ScriptExpressions[handle.Index];

                        var functionNameHandle = AllocateExpression(HsType.FunctionName, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, (ushort)builtin.Key, (short)functionNameSymbol.Line);
                        var functionNameExpr = ScriptExpressions[functionNameHandle.Index];
                        functionNameExpr.StringAddress = CompileStringAddress(functionNameSymbol.Value);

                        Array.Copy(BitConverter.GetBytes(functionNameHandle.Value), expr.Data, 4);
                        Array.Copy(BitConverter.GetBytes(0), functionNameExpr.Data, 4);

                        var prevExpr = functionNameExpr;

                        for (IScriptSyntax current = group.Tail;
                            current is ScriptGroup currentGroup;
                            current = currentGroup.Tail)
                        {
                            if (!(currentGroup.Tail is ScriptGroup) && !(currentGroup.Tail is ScriptInvalid))
                                throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");

                            var currentHandle = CompileExpression(HsType.Boolean, currentGroup.Head);

                            prevExpr.NextExpressionHandle = currentHandle;
                            prevExpr = ScriptExpressions[currentHandle.Index];
                        }

                        return handle;
                    }

                case "+":
                case "-":
                case "*":
                case "/":
                case "%":
                case "min":
                case "max":
                    {
                        var builtin = Cache.ScriptDefinitions.Scripts.First(x => x.Value.Name == functionNameSymbol.Value);

                        // If the calling context needs a specific type and the arithmetic function's
                        // natural Real return is implicitly castable to it (e.g. set assigns to a
                        // Short global), emit the Group with the context type so the engine knows
                        // to convert the result.  When context is Unparsed (no specific target),
                        // fall back to the function's natural Real return type.
                        var groupType = (type != HsType.Unparsed && IsImplicitlyCastable(builtin.Value.Type, type))
                            ? type
                            : builtin.Value.Type;

                        var handle = AllocateExpression(groupType, HsSyntaxNodeFlags.Group, (ushort)builtin.Key, (short)group.Line);
                        var expr = ScriptExpressions[handle.Index];

                        var functionNameHandle = AllocateExpression(HsType.FunctionName, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, (ushort)builtin.Key, (short)functionNameSymbol.Line);
                        var functionNameExpr = ScriptExpressions[functionNameHandle.Index];
                        functionNameExpr.StringAddress = CompileStringAddress(functionNameSymbol.Value);

                        Array.Copy(BitConverter.GetBytes(functionNameHandle.Value), expr.Data, 4);
                        Array.Copy(BitConverter.GetBytes(0), functionNameExpr.Data, 4);

                        var prevExpr = functionNameExpr;

                        for (IScriptSyntax current = group.Tail;
                            current is ScriptGroup currentGroup;
                            current = currentGroup.Tail)
                        {
                            if (!(currentGroup.Tail is ScriptGroup) && !(currentGroup.Tail is ScriptInvalid))
                                throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");

                            // Engine's hs_parse_arithmetic always parses operands as Real.
                            var currentHandle = CompileExpression(HsType.Real, currentGroup.Head);

                            prevExpr.NextExpressionHandle = currentHandle;
                            prevExpr = ScriptExpressions[currentHandle.Index];
                        }

                        return handle;
                    }

                case "=":
                case "!=":
                    {
                        var builtin = Cache.ScriptDefinitions.Scripts.First(x => x.Value.Name == functionNameSymbol.Value);

                        var handle = AllocateExpression(builtin.Value.Type, HsSyntaxNodeFlags.Group, (ushort)builtin.Key, (short)group.Line);
                        var expr = ScriptExpressions[handle.Index];

                        var functionNameHandle = AllocateExpression(HsType.FunctionName, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, (ushort)builtin.Key, (short)functionNameSymbol.Line);
                        var functionNameExpr = ScriptExpressions[functionNameHandle.Index];
                        functionNameExpr.StringAddress = CompileStringAddress(functionNameSymbol.Value);

                        Array.Copy(BitConverter.GetBytes(functionNameHandle.Value), expr.Data, 4);
                        Array.Copy(BitConverter.GetBytes(0), functionNameExpr.Data, 4);

                        if (!(group.Tail is ScriptGroup tailGroup))
                            throw new ScriptCompilerException(group.Line, $"Unexpected expression near '{group}'.");

                        if (!(tailGroup.Tail is ScriptGroup tailTailGroup) || !(tailTailGroup.Tail is ScriptInvalid))
                            throw new ScriptCompilerException(group.Line, $"Unexpected expression near '{group}'.");

                        // Three-tier fallback matching hs_parse_equality
                        var firstArgHandle = CompileExpression(HsType.Unparsed, tailGroup.Head);
                        var firstExpr = ScriptExpressions[firstArgHandle.Index];

                        if (firstExpr.ValueType != HsType.Unparsed && firstExpr.ValueType != HsType.Invalid)
                        {
                            firstExpr.NextExpressionHandle = (tailTailGroup.Head is ScriptGroup)
                                ? CompileExpression(HsType.Unparsed, tailTailGroup.Head)
                                : CompileExpression(firstExpr.ValueType, tailTailGroup.Head);
                        }
                        else
                        {
                            var secondArgHandle = CompileExpression(HsType.Unparsed, tailTailGroup.Head);
                            var secondExpr = ScriptExpressions[secondArgHandle.Index];

                            if (secondExpr.ValueType != HsType.Unparsed && secondExpr.ValueType != HsType.Invalid)
                            {
                                firstArgHandle = CompileExpression(secondExpr.ValueType, tailGroup.Head);
                                firstExpr = ScriptExpressions[firstArgHandle.Index];
                                firstExpr.NextExpressionHandle = secondArgHandle;
                            }
                            else
                            {
                                firstArgHandle = CompileExpression(HsType.Real, tailGroup.Head);
                                firstExpr = ScriptExpressions[firstArgHandle.Index];
                                firstExpr.NextExpressionHandle = CompileExpression(HsType.Real, tailTailGroup.Head);
                            }
                        }

                        functionNameExpr.NextExpressionHandle = firstArgHandle;
                        return handle;
                    }

                case "<":
                case ">":
                case "<=":
                case ">=":
                    {
                        var builtin = Cache.ScriptDefinitions.Scripts.First(x => x.Value.Name == functionNameSymbol.Value);

                        var handle = AllocateExpression(builtin.Value.Type, HsSyntaxNodeFlags.Group, (ushort)builtin.Key, (short)group.Line);
                        var expr = ScriptExpressions[handle.Index];

                        var functionNameHandle = AllocateExpression(HsType.FunctionName, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, (ushort)builtin.Key, (short)functionNameSymbol.Line);
                        var functionNameExpr = ScriptExpressions[functionNameHandle.Index];
                        functionNameExpr.StringAddress = CompileStringAddress(functionNameSymbol.Value);

                        Array.Copy(BitConverter.GetBytes(functionNameHandle.Value), expr.Data, 4);
                        Array.Copy(BitConverter.GetBytes(0), functionNameExpr.Data, 4);

                        if (!(group.Tail is ScriptGroup tailGroup))
                            throw new ScriptCompilerException(group.Line, $"Unexpected expression near '{group}'.");

                        if (!(tailGroup.Tail is ScriptGroup tailTailGroup) || !(tailTailGroup.Tail is ScriptInvalid))
                            throw new ScriptCompilerException(group.Line, $"Unexpected expression near '{group}'.");

                        // Three-tier fallback matching hs_parse_inequality
                        var firstArgHandle = CompileExpression(HsType.Unparsed, tailGroup.Head);
                        var firstExpr = ScriptExpressions[firstArgHandle.Index];

                        if (firstExpr.ValueType != HsType.Unparsed && firstExpr.ValueType != HsType.Invalid
                            && IsNumericOrAllowedEnum(firstExpr.ValueType))
                        {
                            firstExpr.NextExpressionHandle = CompileExpression(firstExpr.ValueType, tailTailGroup.Head);
                        }
                        else
                        {
                            var secondArgHandle = CompileExpression(HsType.Unparsed, tailTailGroup.Head);
                            var secondExpr = ScriptExpressions[secondArgHandle.Index];

                            if (secondExpr.ValueType != HsType.Unparsed && secondExpr.ValueType != HsType.Invalid
                                && IsNumericOrAllowedEnum(secondExpr.ValueType))
                            {
                                firstArgHandle = CompileExpression(secondExpr.ValueType, tailGroup.Head);
                                firstExpr = ScriptExpressions[firstArgHandle.Index];
                                firstExpr.NextExpressionHandle = secondArgHandle;
                            }
                            else
                            {
                                firstArgHandle = CompileExpression(HsType.Real, tailGroup.Head);
                                firstExpr = ScriptExpressions[firstArgHandle.Index];
                                firstExpr.NextExpressionHandle = CompileExpression(HsType.Real, tailTailGroup.Head);
                            }
                        }

                        functionNameExpr.NextExpressionHandle = firstArgHandle;
                        return handle;
                    }

                case "sleep":
                    {
                        var builtin = Cache.ScriptDefinitions.Scripts.First(x => x.Value.Name == functionNameSymbol.Value);

                        var handle = AllocateExpression(builtin.Value.Type, HsSyntaxNodeFlags.Group, (ushort)builtin.Key, (short)group.Line);
                        var expr = ScriptExpressions[handle.Index];

                        var functionNameHandle = AllocateExpression(HsType.FunctionName, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, (ushort)builtin.Key, (short)functionNameSymbol.Line);
                        var functionNameExpr = ScriptExpressions[functionNameHandle.Index];
                        functionNameExpr.StringAddress = CompileStringAddress(functionNameSymbol.Value);

                        Array.Copy(BitConverter.GetBytes(functionNameHandle.Value), expr.Data, 4);
                        Array.Copy(BitConverter.GetBytes(0), functionNameExpr.Data, 4);

                        if (!(group.Tail is ScriptGroup tailGroup))
                            throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");

                        functionNameExpr.NextExpressionHandle = CompileExpression(HsType.Short, tailGroup.Head);

                        if (tailGroup.Tail is ScriptInvalid)
                            return handle;

                        var lengthExpr = ScriptExpressions[functionNameExpr.NextExpressionHandle.Index];

                        if (!(tailGroup.Tail is ScriptGroup tailTailGroup) || !(tailTailGroup.Tail is ScriptInvalid))
                            throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");

                        lengthExpr.NextExpressionHandle = CompileExpression(HsType.Script, tailTailGroup.Head);

                        return handle;
                    }

                case "sleep_forever":
                    {
                        var builtin = Cache.ScriptDefinitions.Scripts.First(x => x.Value.Name == functionNameSymbol.Value);

                        var handle = AllocateExpression(builtin.Value.Type, HsSyntaxNodeFlags.Group, (ushort)builtin.Key, (short)group.Line);
                        var expr = ScriptExpressions[handle.Index];

                        var functionNameHandle = AllocateExpression(HsType.FunctionName, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, (ushort)builtin.Key, (short)functionNameSymbol.Line);
                        var functionNameExpr = ScriptExpressions[functionNameHandle.Index];
                        functionNameExpr.StringAddress = CompileStringAddress(functionNameSymbol.Value);

                        Array.Copy(BitConverter.GetBytes(functionNameHandle.Value), expr.Data, 4);
                        Array.Copy(BitConverter.GetBytes(0), functionNameExpr.Data, 4);

                        if (group.Tail is ScriptInvalid)
                            return handle;

                        if (!(group.Tail is ScriptGroup tailGroup) || !(tailGroup.Tail is ScriptInvalid))
                            throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");

                        functionNameExpr.NextExpressionHandle = CompileExpression(HsType.Script, tailGroup.Head);

                        return handle;
                    }

                case "sleep_until":
                    {
                        var builtin = Cache.ScriptDefinitions.Scripts.First(x => x.Value.Name == functionNameSymbol.Value);

                        var handle = AllocateExpression(type == HsType.Boolean ? HsType.Boolean : HsType.Void, HsSyntaxNodeFlags.Group, (ushort)builtin.Key, (short)group.Line);
                        var expr = ScriptExpressions[handle.Index];

                        var functionNameHandle = AllocateExpression(HsType.FunctionName, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, (ushort)builtin.Key, (short)functionNameSymbol.Line);
                        var functionNameExpr = ScriptExpressions[functionNameHandle.Index];
                        functionNameExpr.StringAddress = CompileStringAddress(functionNameSymbol.Value);

                        Array.Copy(BitConverter.GetBytes(functionNameHandle.Value), expr.Data, 4);
                        Array.Copy(BitConverter.GetBytes(0), functionNameExpr.Data, 4);

                        if (!(group.Tail is ScriptGroup tailGroup))
                            throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");

                        functionNameExpr.NextExpressionHandle = CompileExpression(HsType.Boolean, tailGroup.Head);

                        if (tailGroup.Tail is ScriptGroup tailTailGroup)
                        {
                            var booleanExpr = ScriptExpressions[functionNameExpr.NextExpressionHandle.Index];
                            booleanExpr.NextExpressionHandle = CompileExpression(HsType.Short, tailTailGroup.Head);

                            if (tailTailGroup.Tail is ScriptGroup tailTailTailGroup)
                            {
                                if (!(tailTailTailGroup.Tail is ScriptInvalid))
                                    throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");

                                var tickExpr = ScriptExpressions[booleanExpr.NextExpressionHandle.Index];
                                tickExpr.NextExpressionHandle = CompileExpression(HsType.Long, tailTailTailGroup.Head);
                            }
                            else if (!(tailTailGroup.Tail is ScriptInvalid))
                            {
                                throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");
                            }
                        }
                        else if (!(tailGroup.Tail is ScriptInvalid))
                        {
                            throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");
                        }

                        return handle;
                    }

                case "wake":
                    {
                        var builtin = Cache.ScriptDefinitions.Scripts.First(x => x.Value.Name == functionNameSymbol.Value);

                        var handle = AllocateExpression(builtin.Value.Type, HsSyntaxNodeFlags.Group, (ushort)builtin.Key, (short)group.Line);
                        var expr = ScriptExpressions[handle.Index];

                        var functionNameHandle = AllocateExpression(HsType.FunctionName, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, (ushort)builtin.Key, (short)functionNameSymbol.Line);
                        var functionNameExpr = ScriptExpressions[functionNameHandle.Index];
                        functionNameExpr.StringAddress = CompileStringAddress(functionNameSymbol.Value);

                        Array.Copy(BitConverter.GetBytes(functionNameHandle.Value), expr.Data, 4);
                        Array.Copy(BitConverter.GetBytes(0), functionNameExpr.Data, 4);

                        if (!(group.Tail is ScriptGroup tailGroup) || !(tailGroup.Tail is ScriptInvalid))
                            throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");

                        functionNameExpr.NextExpressionHandle = CompileExpression(HsType.Script, tailGroup.Head);

                        return handle;
                    }

                case "inspect":
                    {
                        var builtin = Cache.ScriptDefinitions.Scripts.First(x => x.Value.Name == functionNameSymbol.Value);

                        var handle = AllocateExpression(builtin.Value.Type, HsSyntaxNodeFlags.Group, (ushort)builtin.Key, (short)group.Line);
                        var expr = ScriptExpressions[handle.Index];

                        var functionNameHandle = AllocateExpression(HsType.FunctionName, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, (ushort)builtin.Key, (short)functionNameSymbol.Line);
                        var functionNameExpr = ScriptExpressions[functionNameHandle.Index];
                        functionNameExpr.StringAddress = CompileStringAddress(functionNameSymbol.Value);

                        Array.Copy(BitConverter.GetBytes(functionNameHandle.Value), expr.Data, 4);
                        Array.Copy(BitConverter.GetBytes(0), functionNameExpr.Data, 4);

                        if (!(group.Tail is ScriptGroup tailGroup))
                            throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");

                        functionNameExpr.NextExpressionHandle = CompileExpression(HsType.Unparsed, tailGroup.Head);

                        return handle;
                    }

                case "unit":
                    {
                        var builtin = Cache.ScriptDefinitions.Scripts.First(x => x.Value.Name == functionNameSymbol.Value);

                        var handle = AllocateExpression(builtin.Value.Type, HsSyntaxNodeFlags.Group, (ushort)builtin.Key, (short)group.Line);
                        var expr = ScriptExpressions[handle.Index];

                        var functionNameHandle = AllocateExpression(HsType.FunctionName, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, (ushort)builtin.Key, (short)functionNameSymbol.Line);
                        var functionNameExpr = ScriptExpressions[functionNameHandle.Index];
                        functionNameExpr.StringAddress = CompileStringAddress(functionNameSymbol.Value);

                        Array.Copy(BitConverter.GetBytes(functionNameHandle.Value), expr.Data, 4);
                        Array.Copy(BitConverter.GetBytes(0), functionNameExpr.Data, 4);

                        if (!(group.Tail is ScriptGroup tailGroup))
                            throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");

                        functionNameExpr.NextExpressionHandle = CompileExpression(HsType.Object, tailGroup.Head);

                        return handle;
                    }
            }

            //
            // Check if function name is a built-in function
            //

            // Count the arguments supplied at this call site so we can resolve overloads
            // (e.g. object_set_velocity exists with 1 and 3 real parameters).
            var argCount = 0;
            for (IScriptSyntax argNode = group.Tail; argNode is ScriptGroup; argNode = ((ScriptGroup)argNode).Tail)
                argCount++;

            // First pass: try to find an exact name+parameter-count match.
            // Second pass: fall back to name-only match for functions with no overloads.
            foreach (var pass in new[] { true, false })
            {
                foreach (var entry in Cache.ScriptDefinitions.Scripts)
                {
                    if (functionNameSymbol.Value != entry.Value.Name)
                        continue;

                    if (pass && entry.Value.Parameters.Count != argCount)
                        continue;

                    // Emit the Group node with the calling context type when a valid implicit cast
                    // exists from the function's natural return type (e.g. player_get returns Unit,
                    // but the caller expects Object or ObjectList — both are valid downcasts).
                    var builtinEmitType = (type == HsType.Void && entry.Value.Type != HsType.Void)
                        ? HsType.Void
                        : (type != HsType.Unparsed && IsImplicitlyCastable(entry.Value.Type, type))
                            ? type
                            : entry.Value.Type;
                    var handle = AllocateExpression(builtinEmitType, HsSyntaxNodeFlags.Group, (ushort)entry.Key, (short)functionNameSymbol.Line);
                    var expr = ScriptExpressions[handle.Index];

                    var functionNameHandle = AllocateExpression(HsType.FunctionName, HsSyntaxNodeFlags.Expression, (ushort)entry.Key, (short)functionNameSymbol.Line);
                    var functionNameExpr = ScriptExpressions[functionNameHandle.Index];
                    functionNameExpr.StringAddress = CompileStringAddress(functionNameSymbol.Value);

                    Array.Copy(BitConverter.GetBytes(functionNameHandle.Value), expr.Data, 4);
                    Array.Copy(BitConverter.GetBytes(0), functionNameExpr.Data, 4);

                    IScriptSyntax parameters = group.Tail;
                    var prevExpr = functionNameExpr;

                    foreach (var parameter in entry.Value.Parameters)
                    {
                        if (!(parameters is ScriptGroup parametersGroup))
                            throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");

                        prevExpr.NextExpressionHandle = CompileExpression(parameter.Type, parametersGroup.Head);
                        prevExpr = ScriptExpressions[prevExpr.NextExpressionHandle.Index];

                        parameters = parametersGroup.Tail;
                    }

                    return handle;
                }
            }

            //
            // Check if function name is a script
            //

            foreach (var script in Scripts)
            {
                if (functionNameSymbol.Value != script.ScriptName)
                    continue;

                if (script.Type == HsScriptType.Extern)
                    return CompileExternMethodReference(group, functionNameSymbol, script, type);

                // Promote the return type when the calling context requires it
                // (e.g. Unit returned where Object is expected). Matches bungie behavior.
                var scriptEmitType = (type == HsType.Void && script.ReturnType != HsType.Void)
                    ? HsType.Void
                    : (type != HsType.Unparsed && IsImplicitlyCastable(script.ReturnType, type))
                        ? type
                        : script.ReturnType;
                var handle = AllocateExpression(
                    scriptEmitType,
                    HsSyntaxNodeFlags.ScriptReference,
                    (ushort)Scripts.IndexOf(script),
                    (short)functionNameSymbol.Line);

                var expr = ScriptExpressions[handle.Index];

                var functionNameHandle = AllocateExpression(
                    HsType.FunctionName,
                    HsSyntaxNodeFlags.Expression,
                    (ushort)Scripts.IndexOf(script),
                    (short)functionNameSymbol.Line);

                var functionNameExpr = ScriptExpressions[functionNameHandle.Index];
                functionNameExpr.StringAddress = CompileStringAddress(functionNameSymbol.Value);

                Array.Copy(BitConverter.GetBytes(functionNameHandle.Value), expr.Data, 4);
                Array.Copy(BitConverter.GetBytes(0), functionNameExpr.Data, 4);

                IScriptSyntax parameters = group.Tail;
                var prevExpr = functionNameExpr;

                foreach (var parameter in script.Parameters)
                {
                    if (!(parameters is ScriptGroup parametersGroup))
                        throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");

                    prevExpr.NextExpressionHandle = CompileExpression(parameter.Type, parametersGroup.Head);
                    prevExpr = ScriptExpressions[prevExpr.NextExpressionHandle.Index];

                    parameters = parametersGroup.Tail;
                }

                return handle;
            }

            throw new ScriptCompilerException(functionNameSymbol.Line, $"Unknown function or script: '{functionNameSymbol.Value}'.");
        }

        private DatumHandle CompileExternMethodReference(ScriptGroup group, ScriptSymbol functionNameSymbol, HsScript script, HsType type = HsType.Unparsed)
        {
            var builtin = Cache.ScriptDefinitions.Scripts.First(x => x.Value.Name == "dew_method_stub");
            var scriptIndex = (short)Scripts.IndexOf(script);

            var externEmitType = (type != HsType.Unparsed && IsImplicitlyCastable(script.ReturnType, type))
                ? type
                : script.ReturnType;
            var handle = AllocateExpression(externEmitType, HsSyntaxNodeFlags.Group | HsSyntaxNodeFlags.Extern, (ushort)builtin.Key, scriptIndex);
            var expr = ScriptExpressions[handle.Index];

            var functionNameHandle = AllocateExpression(HsType.FunctionName, HsSyntaxNodeFlags.Expression | HsSyntaxNodeFlags.Extern, (ushort)builtin.Key, scriptIndex);
            var functionNameExpr = ScriptExpressions[functionNameHandle.Index];
            functionNameExpr.StringAddress = CompileStringAddress(functionNameSymbol.Value);

            Array.Copy(BitConverter.GetBytes(functionNameHandle.Value), expr.Data, 4);
            Array.Copy(BitConverter.GetBytes(0), functionNameExpr.Data, 4);

            IScriptSyntax parameters = group.Tail;
            var prevExpr = functionNameExpr;

            foreach (var parameter in script.Parameters)
            {
                if (!(parameters is ScriptGroup parametersGroup))
                    throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");

                prevExpr.NextExpressionHandle = CompileExpression(parameter.Type, parametersGroup.Head);
                prevExpr = ScriptExpressions[prevExpr.NextExpressionHandle.Index];

                parameters = parametersGroup.Tail;
            }

            // Compile variadic parameters
            for (IScriptSyntax current = parameters;
                current is ScriptGroup currentGroup;
                current = currentGroup.Tail)
            {
                prevExpr.NextExpressionHandle = CompileExpression(HsType.Unparsed, currentGroup.Head);
                prevExpr = ScriptExpressions[prevExpr.NextExpressionHandle.Index];
            }

            return handle;
        }

        private DatumHandle CompileGlobalReference(ScriptSymbol symbol, HsGlobal global)
            => CompileGlobalReference(symbol, global, global.Type);

        private DatumHandle CompileGlobalReference(ScriptSymbol symbol, HsGlobal global, HsType emitType)
            => CompileGlobalReference(symbol, global, emitType, false);

        private DatumHandle CompileGlobalReference(ScriptSymbol symbol, HsGlobal global, HsType emitType, bool explicitType)
        {
            // Opcode is set to the type integer when the calling context explicitly requests a
            // fixed type (e.g. if->boolean). When the context is flexible and the global resolves
            // to its natural type (e.g. <= numeric params compiled as Unparsed), opcode stays 0.
            ushort? opcode = explicitType ? GetHsTypeAsInteger(emitType) : (ushort?)0;
            var handle = AllocateExpression(emitType, HsSyntaxNodeFlags.GlobalsReference, opcode, line: (short)symbol.Line);

            var expr = ScriptExpressions[handle.Index];
            expr.StringAddress = CompileStringAddress(global.Name);
            Array.Copy(BitConverter.GetBytes(Globals.IndexOf(global)), expr.Data, 4);

            return handle;
        }

        private DatumHandle CompileGlobalReference(ScriptSymbol symbol, HsType type, string name, ushort opcode)
        {
            var handle = AllocateExpression(type, HsSyntaxNodeFlags.GlobalsReference, line: (short)symbol.Line);

            var expr = ScriptExpressions[handle.Index];
            expr.StringAddress = CompileStringAddress(name);
            Array.Copy(BitConverter.GetBytes(opcode), expr.Data, 2);

            return handle;
        }

        private DatumHandle CompileParameterReference(ScriptSymbol symbol, HsScriptParameter parameter)
            => CompileParameterReference(symbol, parameter, parameter.Type);

        private DatumHandle CompileParameterReference(ScriptSymbol symbol, HsScriptParameter parameter, HsType emitType)
        {
            var handle = AllocateExpression(emitType, HsSyntaxNodeFlags.ParameterReference, line: (short)symbol.Line);

            var expr = ScriptExpressions[handle.Index];
            expr.StringAddress = CompileStringAddress(parameter.Name);
            Array.Copy(BitConverter.GetBytes(CurrentScript.Parameters.IndexOf(parameter)), expr.Data, 4);

            return handle;
        }

        private static bool IsNumericOrAllowedEnum(HsType type)
        {
            if (type == HsType.Unparsed || type == HsType.Invalid)
                return false;
            if (type >= HsType.Real && type <= HsType.Long)
                return true;
            if (type >= HsType.GameDifficulty && type <= HsType.SecondarySkull)
                return true;
            return false;
        }

        private DatumHandle CompileEnumExpression<TEnum>(HsType type, ScriptSymbol symbol) where TEnum : struct, Enum
        {
            var handle = AllocateExpression(type, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)symbol.Line);
            if (handle != DatumHandle.None)
            {
                short value;
                if (short.TryParse(symbol.Value, out var rawIndex))
                {
                    var maxIndex = (short)(Enum.GetValues(typeof(TEnum)).Length - 1);
                    if (rawIndex < 0 || rawIndex > maxIndex)
                        throw new ScriptCompilerException(symbol.Line, $"Index {rawIndex} is out of range (0-{maxIndex}) for {typeof(TEnum).Name}.");
                    value = rawIndex;
                }
                else if (Enum.TryParse<TEnum>(symbol.Value, true, out var enumVal))
                {
                    value = Convert.ToInt16(enumVal);
                }
                else
                {
                    throw new ScriptCompilerException(symbol.Line, $"Unknown {typeof(TEnum).Name} value: '{symbol.Value}'.");
                }
                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(symbol.Value);
                Array.Copy(BitConverter.GetBytes(value), expr.Data, 2);
            }
            return handle;
        }

        private DatumHandle CompileTagExpression<TTag>(HsType type, ScriptString tagString) where TTag : TagStructure
        {
            var handle = AllocateExpression(type, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)tagString.Line);
            if (handle != DatumHandle.None)
            {
                var expr = ScriptExpressions[handle.Index];
                if (tagString.Value == "none")
                {
                    expr.StringAddress = 0;
                    Array.Copy(BitConverter.GetBytes(-1), expr.Data, 4);
                }
                else
                {
                    if (!Cache.TagCache.TryGetTag<TTag>(tagString.Value, out var instance))
                        throw new ScriptCompilerException(tagString.Line, $"Could not find {typeof(TTag).Name} tag: '{tagString.Value}'.");
                    WriteTagToSourceFileReferences(new ScriptString { Value = tagString.Value + "." + instance.Group.ToString() });
                    expr.StringAddress = CompileStringAddress(tagString.Value);
                    Array.Copy(BitConverter.GetBytes(instance.Index), expr.Data, 4);
                }
            }
            return handle;
        }

        private DatumHandle CompileScenarioIndexExpression(HsType type, ScriptString str, Func<string, int> findIndex, int dataSize)
        {
            var handle = AllocateExpression(type, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)str.Line);
            if (handle != DatumHandle.None)
            {
                var expr = ScriptExpressions[handle.Index];
                if (str.Value == "none")
                {
                    expr.StringAddress = 0;
                    if (dataSize == 2)
                        Array.Copy(BitConverter.GetBytes((short)-1), expr.Data, 2);
                    else
                        Array.Copy(BitConverter.GetBytes(-1), expr.Data, 4);
                }
                else
                {
                    var index = findIndex(str.Value);
                    if (index == -1)
                        throw new ScriptCompilerException(str.Line, $"Value not found or invalid: '{str.Value}'.");
                    expr.StringAddress = CompileStringAddress(str.Value);
                    if (dataSize == 2)
                        Array.Copy(BitConverter.GetBytes((short)index), expr.Data, 2);
                    else
                        Array.Copy(BitConverter.GetBytes(index), expr.Data, 4);
                }
            }
            return handle;
        }

        private DatumHandle CompileBooleanExpression(ScriptBoolean boolValue)
        {
            var handle = AllocateExpression(HsType.Boolean, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)boolValue.Line);

            if (handle != DatumHandle.None)
            {
                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(boolValue.Value.ToString().ToLower());
                Array.Copy(BitConverter.GetBytes(boolValue.Value), expr.Data, 1);
            }

            return handle;
        }

        private DatumHandle CompileRealExpression(ScriptReal realValue)
        {
            var handle = AllocateExpression(HsType.Real, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)realValue.Line);

            if (handle != DatumHandle.None)
                Array.Copy(BitConverter.GetBytes((float)realValue.Value), ScriptExpressions[handle.Index].Data, 4);

            return handle;
        }

        private DatumHandle CompileShortExpression(ScriptInteger shortValue)
        {
            var handle = AllocateExpression(HsType.Short, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)shortValue.Line);

            if (handle != DatumHandle.None)
                Array.Copy(BitConverter.GetBytes((short)shortValue.Value), ScriptExpressions[handle.Index].Data, 2);

            return handle;
        }

        private DatumHandle CompileLongExpression(ScriptInteger longValue)
        {
            var handle = AllocateExpression(HsType.Long, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)longValue.Line);

            if (handle != DatumHandle.None)
                Array.Copy(BitConverter.GetBytes((int)longValue.Value), ScriptExpressions[handle.Index].Data, 4);

            return handle;
        }

        private DatumHandle CompileStringExpression(ScriptString stringValue)
        {
            var handle = AllocateExpression(HsType.String, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)stringValue.Line);

            if (handle != DatumHandle.None)
            {
                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(stringValue.Value);
                Array.Copy(BitConverter.GetBytes(expr.StringAddress), expr.Data, 4);
            }

            return handle;
        }

        private DatumHandle CompileScriptExpression(ScriptSymbol scriptSymbol, HsType type = HsType.Script, HsScriptType? scriptTypeFilter = null)
        {
            var handle = AllocateExpression(type, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)scriptSymbol.Line);

            if (handle != DatumHandle.None)
            {
                var scriptIndex = Scripts.FindIndex(s =>
                    string.Equals(s.ScriptName, scriptSymbol.Value, StringComparison.OrdinalIgnoreCase) &&
                    (scriptTypeFilter == null || s.Type == scriptTypeFilter.Value));

                if (scriptIndex == -1)
                    throw new ScriptCompilerException(scriptSymbol.Line, $"Script not defined: '{scriptSymbol.Value}'.");

                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(scriptSymbol.Value);
                Array.Copy(BitConverter.GetBytes((short)scriptIndex), expr.Data, 2);
            }

            return handle;
        }

        private DatumHandle CompileStringIdExpression(ScriptString stringIdString, HsType type = HsType.StringId)
        {
            var handle = AllocateExpression(type, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)stringIdString.Line);

            if (handle != DatumHandle.None)
            {
                var expr = ScriptExpressions[handle.Index];
                if (stringIdString.Value == "none")
                {
                    expr.StringAddress = 0;
                    Array.Copy(BitConverter.GetBytes(0u), expr.Data, 4);
                }
                else
                {
                    var stringId = Cache.StringTable.GetStringId(stringIdString.Value);
                    expr.StringAddress = CompileStringAddress(stringIdString.Value);
                    Array.Copy(BitConverter.GetBytes(stringId.Value), expr.Data, 4);
                }
            }

            return handle;
        }

        private DatumHandle CompileUnitSeatMappingExpression(ScriptString unitSeatMappingString)
        {
            var handle = AllocateExpression(HsType.UnitSeatMapping, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)unitSeatMappingString.Line);

            if (handle != DatumHandle.None)
            {
                // Empty string or "none" means "all seats for any unit" - encode data as 0.
                if (string.IsNullOrEmpty(unitSeatMappingString.Value) || unitSeatMappingString.Value == "none")
                {
                    var noneExpr = ScriptExpressions[handle.Index];
                    noneExpr.StringAddress = CompileStringAddress(unitSeatMappingString.Value);
                    Array.Copy(BitConverter.GetBytes(-1), noneExpr.Data, 4);
                    return handle;
                }

                using (var stream = Cache.OpenCacheRead())
                {
                    // Build the list of per-unit seat mapping blocks that match the substring.
                    // By Bungie design, seat label strings always start with the vehicle/unit name
                    // so a well-formed substring will only match seats on the intended unit tag.
                    // Correctness of the substring is intentionally left to the script author.
                    var seatsStack = new List<Scenario.UnitSeatsMappingBlock>();

                    foreach (var unitTag in Cache.TagCache.FindAllInGroup("unit"))
                    {
                        var unitSeatMapping = new Scenario.UnitSeatsMappingBlock
                        {
                            Unit = unitTag,
                        };

                        var unitDefinition = Cache.Deserialize<Unit>(stream, unitTag);

                        // Accumulate ALL seats on this unit whose label contains the substring.
                        // The old code broke after the first match, discarding every subsequent
                        // matching seat on the same unit.
                        for (int seatIndex = 0; seatIndex < unitDefinition.Seats.Count; seatIndex++)
                        {
                            var seatName = Cache.StringTable.GetString(unitDefinition.Seats[seatIndex].Label);
                            if (!seatName.Contains(unitSeatMappingString.Value))
                                seatName = Cache.StringTable.GetString(unitDefinition.Seats[seatIndex].MarkerName);
                            if (!seatName.Contains(unitSeatMappingString.Value))
                                continue;

                            if (!seatName.Contains(unitSeatMappingString.Value))
                                continue;

                            if (seatIndex < 32)
                                unitSeatMapping.Seats1 |= (Scenario.UnitSeatFlags)(1 << seatIndex);
                            else
                                unitSeatMapping.Seats2 |= (Scenario.UnitSeatFlags)(1 << (seatIndex - 32));
                        }

                        // Only add a block if at least one seat matched on this unit.
                        if (unitSeatMapping.Seats1 != 0 || unitSeatMapping.Seats2 != 0)
                        {
                            // Cap at 256 entries (count field is 16-bit, and this is a sanity
                            // guard against runaway matches from an overly-broad substring).
                            if (seatsStack.Count >= 256)
                            {
                                Log.Warning($"Unit seat mapping '{ unitSeatMappingString.Value }': more than 256 units match; truncating.");
                                break;
                            }

                            seatsStack.Add(unitSeatMapping);
                        }
                    }

                    int unitSeatMappingCount = seatsStack.Count;

                    if (unitSeatMappingCount == 0)
                        throw new ScriptCompilerException(unitSeatMappingString.Line, $"No unit seats found matching '{unitSeatMappingString.Value}'. Check that the substring matches a seat label on a unit tag in the cache.");

                    // Check whether this exact contiguous run of blocks already exists in the
                    // scenario's UnitSeatsMapping block array from a previous compile pass.
                    // We must verify the full run, not just a single entry.
                    int unitSeatStartIndex = -1;

                    for (int scenarioIndex = 0; scenarioIndex <= Definition.UnitSeatsMapping.Count - unitSeatMappingCount; scenarioIndex++)
                    {
                        bool runMatches = true;

                        for (int stackIndex = 0; stackIndex < unitSeatMappingCount; stackIndex++)
                        {
                            var s = seatsStack[stackIndex];
                            var m = Definition.UnitSeatsMapping[scenarioIndex + stackIndex];

                            if (s.Unit != m.Unit || s.Seats1 != m.Seats1 || s.Seats2 != m.Seats2)
                            {
                                runMatches = false;
                                break;
                            }
                        }

                        if (runMatches)
                        {
                            unitSeatStartIndex = scenarioIndex;
                            break;
                        }
                    }

                    // If no matching run was found, append the new blocks to the scenario array
                    // and use the newly-appended start index.  This is the normal path on a
                    // fresh compile; the dedup path above handles recompile/append workflows.
                    if (unitSeatStartIndex == -1)
                    {
                        unitSeatStartIndex = Definition.UnitSeatsMapping.Count;
                        Definition.UnitSeatsMapping.AddRange(seatsStack);
                    }

                    // Pack as: high 16 bits = count, low 16 bits = start index.
                    var data = ((unitSeatMappingCount & 0xFFFF) << 16) | (unitSeatStartIndex & 0xFFFF);

                    var expr = ScriptExpressions[handle.Index];
                    expr.StringAddress = CompileStringAddress(unitSeatMappingString.Value);
                    Array.Copy(BitConverter.GetBytes(data), expr.Data, 4);
                }
            }

            return handle;
        }

        private DatumHandle CompileAiExpression(ScriptString aiString, HsType emitType = HsType.Ai)
        {
            // The expression ValueType reflects the slot context (e.g. Object, Unit) so the
            // engine places the value correctly, but the opcode must always be HsType.Ai (0x13)
            // so the engine knows to interpret the encoded value as an AI reference.
            var handle = AllocateExpression(emitType, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)aiString.Line);

            if (handle != DatumHandle.None)
            {
                var expr = ScriptExpressions[handle.Index];
                expr.Opcode = GetHsTypeAsInteger(HsType.Ai);

                var tokens = aiString.Value.Split('/');
                var value = 0;

                switch (tokens.Length)
                {
                    case 1:
                        {
                            if (aiString.Value == "none")
                            {
                                value = -1;
                                break;
                            }

                            //
                            // type 1: squad
                            //

                            var squadIndex = Definition.Squads.FindIndex(s => string.Equals(s.Name, tokens[0], StringComparison.OrdinalIgnoreCase));

                            if (squadIndex != -1)
                            {
                                value = (1 << 29) | (squadIndex & 0xFFFF);
                                break;
                            }

                            //
                            // type 2: squad group
                            //

                            var squadGroupIndex = Definition.SquadGroups.FindIndex(sg => string.Equals(sg.Name, tokens[0], StringComparison.OrdinalIgnoreCase));

                            if (squadGroupIndex != -1)
                            {
                                value = (2 << 29) | (squadGroupIndex & 0xFFFF);
                                break;
                            }

                            //
                            // type 2: actor datum index
                            //  TODO?
                            //

                            //
                            // type 6: objective (without task)
                            //

                            var objectiveIndex = Definition.AiObjectives.FindIndex(o => string.Equals(tokens[0], Cache.StringTable.GetString(o.Name), StringComparison.OrdinalIgnoreCase));

                            if (objectiveIndex != -1)
                            {
                                value = (6 << 29) | (0x1FFF << 16) | (objectiveIndex & 0xFFFF);
                                break;
                            }

                            goto default;
                        }

                    case 2:
                        {
                            var squadIndex = Definition.Squads.FindIndex(s => string.Equals(s.Name, tokens[0], StringComparison.OrdinalIgnoreCase));

                            if (squadIndex != -1)
                            {
                                var squad = Definition.Squads[squadIndex];

                                //
                                // type 4: spawn point
                                //

                                var spawnPointIndex = squad.SpawnPoints.FindIndex(sp => string.Equals(tokens[1], Cache.StringTable.GetString(sp.Name), StringComparison.OrdinalIgnoreCase));

                                if (spawnPointIndex != -1)
                                {
                                    value = (4 << 29) | ((squadIndex & 0x1FFF) << 16) | (spawnPointIndex & 0xFF);
                                    break;
                                }

                                //
                                // type 5: spawn formation
                                //

                                var spawnFormationIndex = squad.SpawnFormations.FindIndex(sf => string.Equals(tokens[1], Cache.StringTable.GetString(sf.Name), StringComparison.OrdinalIgnoreCase));

                                if (spawnFormationIndex != -1)
                                {
                                    value = (5 << 29) | ((squadIndex & 0x1FFF) << 16) | (spawnFormationIndex & 0xFF);
                                    break;
                                }

                                goto default;
                            }

                            //
                            // type 6: objective task
                            //

                            var objectiveIndex = Definition.AiObjectives.FindIndex(o => string.Equals(tokens[0], Cache.StringTable.GetString(o.Name), StringComparison.OrdinalIgnoreCase));

                            if (objectiveIndex != -1)
                            {
                                var taskIndex = Definition.AiObjectives[objectiveIndex].Tasks.FindIndex(t => string.Equals(tokens[1], Cache.StringTable.GetString(t.Name), StringComparison.OrdinalIgnoreCase));

                                if (taskIndex != -1)
                                {
                                    value = (6 << 29) | ((taskIndex & 0x1FFF) << 16) | (objectiveIndex & 0xFFFF);
                                    break;
                                }
                            }

                            goto default;
                        }

                    default:
                        throw new ScriptCompilerException(aiString.Line, $"No AI reference named '{aiString.Value}' found in the scenario. Expected format: 'squad', 'squad_group', 'objective', 'squad/spawn_point', 'squad/spawn_formation', or 'objective/task'.");
                }

                expr.StringAddress = CompileStringAddress(aiString.Value);
                Array.Copy(BitConverter.GetBytes(value), expr.Data, 4);
            }

            return handle;
        }

        private DatumHandle CompileStartingProfileExpression(ScriptString startingProfileString)
        {
            var handle = AllocateExpression(HsType.StartingProfile, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)startingProfileString.Line);

            if (handle != DatumHandle.None)
            {
                var expr = ScriptExpressions[handle.Index];
                if (startingProfileString.Value == "none")
                {
                    expr.StringAddress = 0;
                    expr.Data = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF };
                }
                else
                {
                    var startingProfileIndex = Definition.PlayerStartingProfile.FindIndex(sp => string.Equals(sp.Name, startingProfileString.Value, StringComparison.OrdinalIgnoreCase));
                    if (startingProfileIndex == -1)
                        throw new ScriptCompilerException(startingProfileString.Line, $"No starting profile named '{startingProfileString.Value}' found in the scenario.");
                    expr.StringAddress = CompileStringAddress(startingProfileString.Value);
                    expr.Data = new byte[] { (byte)((startingProfileIndex & 0xFF)), (byte)(startingProfileIndex >> 8), 0xFF, 0xFF };
                }
            }

            return handle;
        }

        private DatumHandle CompilePointReferenceExpression(ScriptString pointReferenceString)
        {
            var handle = AllocateExpression(HsType.PointReference, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)pointReferenceString.Line);

            if (handle != DatumHandle.None)
            {
                var expr = ScriptExpressions[handle.Index];
                if (pointReferenceString.Value == "none")
                {
                    expr.StringAddress = 0;
                    Array.Copy(BitConverter.GetBytes(-1), expr.Data, 4);
                }
                else
                {
                    var tokens = pointReferenceString.Value.Split('/');
                    if (tokens.Length == 1)
                    {
                        var pointSetIndex = Definition.ScriptingData[0].PointSets.FindIndex(ps => string.Equals(ps.Name, tokens[0], StringComparison.OrdinalIgnoreCase));
                        if (pointSetIndex == -1)
                            throw new ScriptCompilerException(pointReferenceString.Line, $"No point set named '{pointReferenceString.Value}' found.");
                        expr.StringAddress = CompileStringAddress(pointReferenceString.Value);
                        Array.Copy(BitConverter.GetBytes((pointSetIndex << 16) | 0xFFFF), expr.Data, 4);
                    }
                    else if (tokens.Length == 2)
                    {
                        var pointSetIndex = Definition.ScriptingData[0].PointSets.FindIndex(ps => string.Equals(ps.Name, tokens[0], StringComparison.OrdinalIgnoreCase));
                        if (pointSetIndex == -1)
                            throw new ScriptCompilerException(pointReferenceString.Line, $"No point reference named '{pointReferenceString.Value}' found. Expected format: 'point_set/point_name'.");
                        var pointIndex = Definition.ScriptingData[0].PointSets[pointSetIndex].Points.FindIndex(p => string.Equals(p.Name, tokens[1], StringComparison.OrdinalIgnoreCase));
                        if (pointIndex == -1)
                            throw new ScriptCompilerException(pointReferenceString.Line, $"No point reference named '{pointReferenceString.Value}' found. Expected format: 'point_set/point_name'.");
                        expr.StringAddress = CompileStringAddress(pointReferenceString.Value);
                        Array.Copy(BitConverter.GetBytes((pointSetIndex << 16) | pointIndex), expr.Data, 4);
                    }
                    else
                    {
                        throw new ScriptCompilerException(pointReferenceString.Line, $"Invalid point reference '{pointReferenceString.Value}'. Expected format: 'point_set' or 'point_set/point_name'.");
                    }
                }
            }

            return handle;
        }

        private DatumHandle CompileObjectListExpression(ScriptString objectListString)
        {
            ushort? objectOpcode = objectListString.Value == "none" ? null : GetHsTypeAsInteger(HsType.ObjectName);
            var handle = AllocateExpression(HsType.ObjectList, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, objectOpcode, line: (short)objectListString.Line);

            if (handle != DatumHandle.None)
            {
                var objectIndex = objectListString.Value == "none" ? -1 :
                    Definition.ObjectNames.FindIndex(on => string.Equals(on.Name, objectListString.Value, StringComparison.OrdinalIgnoreCase));

                if (objectListString.Value != "none" && objectIndex == -1)
                    return CompileAiExpression(objectListString, HsType.ObjectList);

                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(objectListString.Value);
                Array.Copy(BitConverter.GetBytes((short)objectIndex), expr.Data, 2);
            }

            return handle;
        }

        private DatumHandle CompileUntypedTagExpression(HsType type, ScriptString tagString, string groupFilter = null)
        {
            var handle = AllocateExpression(type, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)tagString.Line);
            if (handle != DatumHandle.None)
            {
                var expr = ScriptExpressions[handle.Index];
                if (tagString.Value == "none")
                {
                    expr.StringAddress = 0;
                    Array.Copy(BitConverter.GetBytes(-1), expr.Data, 4);
                }
                else
                {
                    if (!Cache.TagCache.TryGetTag(tagString.Value, out var instance))
                        throw new ScriptCompilerException(tagString.Line, $"Value not found or invalid: '{tagString.Value}'.");
                    if (groupFilter != null && !instance.IsInGroup(groupFilter))
                        throw new ScriptCompilerException(tagString.Line, $"Value not found or invalid: '{tagString.Value}'.");
                    WriteTagToSourceFileReferences(new ScriptString { Value = tagString.Value + "." + instance.Group.ToString() });
                    expr.StringAddress = CompileStringAddress(tagString.Value);
                    Array.Copy(BitConverter.GetBytes(instance.Index), expr.Data, 4);
                }
            }
            return handle;
        }

        private DatumHandle CompileObjectExpression(ScriptString objectString, HsType hsType)
        {
            ushort? opcode = objectString.Value == "none" ? null :
                GetHsTypeAsInteger(Enum.Parse<HsType>(hsType.ToString() + "Name"));
            var handle = AllocateExpression(hsType, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, opcode, line: (short)objectString.Line);

            if (handle != DatumHandle.None)
            {
                var index = objectString.Value == "none" ? -1 :
                    Definition.ObjectNames.FindIndex(on => string.Equals(on.Name, objectString.Value, StringComparison.OrdinalIgnoreCase));

                if (objectString.Value != "none" && index == -1)
                    return CompileAiExpression(objectString, hsType);

                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(objectString.Value);
                Array.Copy(BitConverter.GetBytes(index), expr.Data, 2);
            }

            return handle;
        }

        private DatumHandle CompileObjectNameExpression(ScriptString objectNameString, HsType hsType, params GameObjectTypeHaloOnline[] allowedTypes)
        {
            var handle = AllocateExpression(hsType, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)objectNameString.Line);

            if (handle != DatumHandle.None)
            {
                var objectNameIndex = Definition.ObjectNames.FindIndex(on => string.Equals(on.Name, objectNameString.Value, StringComparison.OrdinalIgnoreCase));

                if (objectNameIndex == -1)
                    throw new ScriptCompilerException(objectNameString.Line, $"No object named '{objectNameString.Value}' found in the scenario.");

                if (allowedTypes.Length > 0 && !allowedTypes.Contains(Definition.ObjectNames[objectNameIndex].ObjectType.HaloOnline))
                    throw new ScriptCompilerException(objectNameString.Line, $"No object named '{objectNameString.Value}' found in the scenario.");

                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(objectNameString.Value);
                Array.Copy(BitConverter.GetBytes((short)objectNameIndex), expr.Data, 2);
            }

            return handle;
        }

        private void WriteTagToSourceFileReferences(ScriptString tagString)
        {
            if (Cache.TagCache.TryGetTag(tagString.Value, out var instance))
            {
                TagReferenceBlock tagReference = new TagReferenceBlock
                {
                    Instance = instance
                };

                bool hasReference = false;
                foreach(var tagEntry in ScriptSourceFileReferences)
                {
                    if(tagEntry.Instance.Index == tagReference.Instance.Index)
                    {
                        hasReference = true;
                        break;
                    }
                }

                if (!hasReference)
                    ScriptSourceFileReferences.Add(tagReference);
            }
        }
    }
}