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

            switch (type)
            {
                case HsType.Unparsed:
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
                    break;

                case HsType.Boolean:
                    if (node is ScriptBoolean boolValue)
                        return CompileBooleanExpression(boolValue);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.Real:
                    if (node is ScriptReal realValue)
                        return CompileRealExpression(realValue);
                    else if (node is ScriptInteger realIntegerValue)
                        return CompileRealExpression(new ScriptReal
                        {
                            Value = (double)realIntegerValue.Value,
                            Line = realIntegerValue.Line
                        });
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.Short:
                    if (node is ScriptInteger shortValue)
                        return CompileShortExpression(shortValue);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.Long:
                    if (node is ScriptInteger longValue)
                        return CompileLongExpression(longValue);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.String:
                    if (node is ScriptSymbol stringNoneSymbol && stringNoneSymbol.Value == "none")
                        return CompileStringExpression(new ScriptString { Value = "none", Line = stringNoneSymbol.Line });
                    else if (node is ScriptString stringValue)
                        return CompileStringExpression(stringValue);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.Script:
                    if (node is ScriptSymbol scriptSymbol)
                        return CompileScriptExpression(scriptSymbol);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.StringId:
                    if (node is ScriptSymbol stringIdNoneSymbol && stringIdNoneSymbol.Value == "none")
                        return CompileStringIdExpression(new ScriptString { Value = "none", Line = stringIdNoneSymbol.Line });
                    else if (node is ScriptString stringIdString)
                        return CompileStringIdExpression(stringIdString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.UnitSeatMapping:
                    if (node is ScriptSymbol unitSeatMappingSymbol && unitSeatMappingSymbol.Value == "none")
                        return CompileUnitSeatMappingExpression(new ScriptString { Value = "none" });
                    else if (node is ScriptString unitSeatMappingString)
                        return CompileUnitSeatMappingExpression(unitSeatMappingString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.TriggerVolume:
                    if (node is ScriptString triggerVolumeString)
                        return CompileScenarioIndexExpression(HsType.TriggerVolume, triggerVolumeString,
                            name => Definition.TriggerVolumes.FindIndex(tv => name == Cache.StringTable.GetString(tv.Name)), 2);
                    else if (node is ScriptSymbol triggerVolumeSymbolString)
                        return CompileScenarioIndexExpression(HsType.TriggerVolume, new ScriptString { Value = triggerVolumeSymbolString.Value },
                            name => Definition.TriggerVolumes.FindIndex(tv => name == Cache.StringTable.GetString(tv.Name)), 2);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.CutsceneFlag:
                    if (node is ScriptSymbol cutsceneFlagNoneSymbol && cutsceneFlagNoneSymbol.Value == "none")
                        return CompileScenarioIndexExpression(HsType.CutsceneFlag, new ScriptString { Value = "none" },
                            name => Definition.CutsceneFlags.FindIndex(cf => name == Cache.StringTable.GetString(cf.Name)), 2);
                    else if (node is ScriptString cutsceneFlagString)
                        return CompileScenarioIndexExpression(HsType.CutsceneFlag, cutsceneFlagString,
                            name => Definition.CutsceneFlags.FindIndex(cf => name == Cache.StringTable.GetString(cf.Name)), 2);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.CutsceneCameraPoint:
                    if (node is ScriptSymbol cutsceneCameraPointNoneSymbol && cutsceneCameraPointNoneSymbol.Value == "none")
                        return CompileScenarioIndexExpression(HsType.CutsceneCameraPoint, new ScriptString { Value = "none" },
                            name => Definition.CutsceneCameraPoints.FindIndex(ccp => name == ccp.Name), 2);
                    else if (node is ScriptString cutsceneCameraPointString)
                        return CompileScenarioIndexExpression(HsType.CutsceneCameraPoint, cutsceneCameraPointString,
                            name => Definition.CutsceneCameraPoints.FindIndex(ccp => name == ccp.Name), 2);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.CutsceneTitle:
                    if (node is ScriptSymbol cutsceneTitleSymbol)
                        return CompileCutsceneTitleExpression(cutsceneTitleSymbol);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.CutsceneRecording:
                    throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"The type 'CutsceneRecording' is not yet supported by the compiler.");

                case HsType.DeviceGroup:
                    if (node is ScriptSymbol deviceGroupNoneSymbol && deviceGroupNoneSymbol.Value == "none")
                        return CompileScenarioIndexExpression(HsType.DeviceGroup, new ScriptString { Value = "none" },
                            name => Definition.DeviceGroups.FindIndex(dg => dg.Name == name), 4);
                    else if (node is ScriptString deviceGroupString)
                        return CompileScenarioIndexExpression(HsType.DeviceGroup, deviceGroupString,
                            name => Definition.DeviceGroups.FindIndex(dg => dg.Name == name), 4);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.Ai:
                    if (node is ScriptSymbol aiSymbol && aiSymbol.Value == "none")
                        return CompileAiExpression(new ScriptString { Value = "none" }, type);
                    else if (node is ScriptString aiString)
                        return CompileAiExpression(aiString, type);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.AiCommandList:
                    if (node is ScriptSymbol aiCommandListNoneSymbol && aiCommandListNoneSymbol.Value == "none")
                        return CompileAiCommandListExpression(new ScriptString { Value = "none" });
                    else if (node is ScriptString aiCommandListString)
                        return CompileAiCommandListExpression(aiCommandListString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.AiCommandScript:
                    if (node is ScriptSymbol aiCommandScriptSymbol)
                        return CompileAiCommandScriptExpression(aiCommandScriptSymbol);
                    else if (node is ScriptString aiCommandScriptString)
                        return CompileAiCommandScriptExpression(new ScriptSymbol { Value = aiCommandScriptString.Value, Line = aiCommandScriptString.Line });
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.AiBehavior:
                    throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"The type 'AiBehavior' is not yet supported by the compiler.");

                case HsType.AiOrders:
                    throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"The type 'AiOrders' is not yet supported by the compiler.");

                case HsType.AiLine:
                    if (node is ScriptSymbol aiLineNoneSymbol && aiLineNoneSymbol.Value == "none")
                        return CompileAiLineExpression(new ScriptString { Value = "none" });
                    else if (node is ScriptString aiLineString)
                        return CompileAiLineExpression(aiLineString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.StartingProfile:
                    if (node is ScriptSymbol startingProfileNoneSymbol && startingProfileNoneSymbol.Value == "none")
                        return CompileStartingProfileExpression(new ScriptString { Value = "none" });
                    else if (node is ScriptString startingProfileString)
                        return CompileStartingProfileExpression(startingProfileString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.Conversation:
                    throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"The type 'Conversation' is not yet supported by the compiler.");

                case HsType.ZoneSet:
                    if (node is ScriptSymbol zoneSetNoneSymbol && zoneSetNoneSymbol.Value == "none")
                        return CompileScenarioIndexExpression(HsType.ZoneSet, new ScriptString { Value = "none" },
                            name => Definition.ZoneSets.FindIndex(zs => name == Cache.StringTable.GetString(zs.Name)), 2);
                    else if (node is ScriptString zoneSetString)
                        return CompileScenarioIndexExpression(HsType.ZoneSet, zoneSetString,
                            name => Definition.ZoneSets.FindIndex(zs => name == Cache.StringTable.GetString(zs.Name)), 2);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.DesignerZone:
                    if (node is ScriptSymbol designerZoneNoneSymbol && designerZoneNoneSymbol.Value == "none")
                        return CompileScenarioIndexExpression(HsType.ZoneSet, new ScriptString { Value = "none" },
                            name => Definition.DesignerZoneSets.FindIndex(dz => name == Cache.StringTable.GetString(dz.Name)), 2);
                    else if (node is ScriptString designerZoneString)
                        return CompileScenarioIndexExpression(HsType.ZoneSet, designerZoneString,
                            name => Definition.DesignerZoneSets.FindIndex(dz => name == Cache.StringTable.GetString(dz.Name)), 2);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.PointReference:
                    if (node is ScriptSymbol pointReferenceNoneSymbol && pointReferenceNoneSymbol.Value == "none")
                        return CompilePointReferenceExpression(new ScriptString { Value = "none" });
                    else if (node is ScriptString pointReferenceString)
                        return CompilePointReferenceExpression(pointReferenceString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.Style:
                    if (node is ScriptSymbol styleNoneSymbol && styleNoneSymbol.Value == "none")
                        return CompileStyleExpression(new ScriptString { Value = "none" });
                    else if (node is ScriptString styleString)
                        return CompileStyleExpression(styleString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.ObjectList:
                    if (node is ScriptSymbol objectListNoneSymbol && objectListNoneSymbol.Value == "none")
                        return CompileObjectListExpression(new ScriptString { Value = "none" });
                    else if (node is ScriptString objectListString)
                        return CompileObjectListExpression(objectListString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.Folder:
                    if (node is ScriptSymbol folderSymbol && folderSymbol.Value == "none")
                        return CompileFolderExpression(new ScriptString { Value = "none" });
                    else if (node is ScriptString folderString)
                        return CompileFolderExpression(folderString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.Sound:
                    if (node is ScriptSymbol soundSymbol && soundSymbol.Value == "none")
                        return CompileTagExpression<Sound>(HsType.Sound, new ScriptString { Value = "none" });
                    else if (node is ScriptString soundString)
                        return CompileTagExpression<Sound>(HsType.Sound, soundString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.Effect:
                    if (node is ScriptSymbol effectSymbol && effectSymbol.Value == "none")
                        return CompileTagExpression<Effect>(HsType.Effect, new ScriptString { Value = "none" });
                    else if (node is ScriptString effectString)
                        return CompileTagExpression<Effect>(HsType.Effect, effectString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.Damage:
                    if (node is ScriptSymbol damageSymbol && damageSymbol.Value == "none")
                        return CompileTagExpression<DamageEffect>(HsType.Damage, new ScriptString { Value = "none" });
                    else if (node is ScriptString damageString)
                        return CompileTagExpression<DamageEffect>(HsType.Damage, damageString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.LoopingSound:
                    if (node is ScriptSymbol loopingSoundSymbol && loopingSoundSymbol.Value == "none")
                        return CompileTagExpression<SoundLooping>(HsType.LoopingSound, new ScriptString { Value = "none" });
                    else if (node is ScriptString loopingSoundString)
                        return CompileTagExpression<SoundLooping>(HsType.LoopingSound, loopingSoundString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.AnimationGraph:
                    if (node is ScriptSymbol animationGraphSymbol && animationGraphSymbol.Value == "none")
                        return CompileTagExpression<ModelAnimationGraph>(HsType.AnimationGraph, new ScriptString { Value = "none" });
                    else if (node is ScriptString animationGraphString)
                        return CompileTagExpression<ModelAnimationGraph>(HsType.AnimationGraph, animationGraphString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.DamageEffect:
                    if (node is ScriptSymbol damageEffectSymbol && damageEffectSymbol.Value == "none")
                        return CompileTagExpression<DamageEffect>(HsType.DamageEffect, new ScriptString { Value = "none" });
                    else if (node is ScriptString damageEffectString)
                        return CompileTagExpression<DamageEffect>(HsType.DamageEffect, damageEffectString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.ObjectDefinition:
                    if (node is ScriptSymbol objectDefinitionSymbol && objectDefinitionSymbol.Value == "none")
                        return CompileObjectDefinitionExpression(new ScriptString { Value = "none" });
                    else if (node is ScriptString objectDefinitionString)
                        return CompileObjectDefinitionExpression(objectDefinitionString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.Bitmap:
                    if (node is ScriptSymbol bitmapSymbol && bitmapSymbol.Value == "none")
                        return CompileTagExpression<Bitmap>(HsType.Bitmap, new ScriptString { Value = "none" });
                    else if (node is ScriptString bitmapString)
                        return CompileTagExpression<Bitmap>(HsType.Bitmap, bitmapString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.Shader:
                    if (node is ScriptSymbol shaderSymbol && shaderSymbol.Value == "none")
                        return CompileTagExpression<RenderMethod>(HsType.Shader, new ScriptString { Value = "none" });
                    else if (node is ScriptString shaderString)
                        return CompileTagExpression<RenderMethod>(HsType.Shader, shaderString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.RenderModel:
                    if (node is ScriptSymbol renderModelSymbol && renderModelSymbol.Value == "none")
                        return CompileTagExpression<RenderModel>(HsType.RenderModel, new ScriptString { Value = "none" });
                    else if (node is ScriptString renderModelString)
                        return CompileTagExpression<RenderModel>(HsType.RenderModel, renderModelString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.StructureDefinition:
                    if (node is ScriptSymbol structureDefinitionSymbol && structureDefinitionSymbol.Value == "none")
                        return CompileTagExpression<ScenarioStructureBsp>(HsType.StructureDefinition, new ScriptString { Value = "none" });
                    else if (node is ScriptString structureDefinitionString)
                        return CompileTagExpression<ScenarioStructureBsp>(HsType.StructureDefinition, structureDefinitionString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.LightmapDefinition:
                    if (node is ScriptSymbol lightmapDefinitionSymbol && lightmapDefinitionSymbol.Value == "none")
                        throw new ScriptCompilerException(lightmapDefinitionSymbol.Line, $"The type 'LightmapDefinition' is not yet supported by the compiler.");
                    else if (node is ScriptString lightmapDefinitionString)
                        throw new ScriptCompilerException(lightmapDefinitionString.Line, $"The type 'LightmapDefinition' is not yet supported by the compiler.");
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.CinematicDefinition:
                    if (node is ScriptSymbol cinematicDefinitionSymbol && cinematicDefinitionSymbol.Value == "none")
                        return CompileTagExpression<Cinematic>(HsType.CinematicDefinition, new ScriptString { Value = "none" });
                    else if (node is ScriptString cinematicDefinitionString)
                        return CompileTagExpression<Cinematic>(HsType.CinematicDefinition, cinematicDefinitionString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.CinematicSceneDefinition:
                    if (node is ScriptSymbol cinematicSceneSymbol && cinematicSceneSymbol.Value == "none")
                        return CompileTagExpression<CinematicScene>(HsType.CinematicSceneDefinition, new ScriptString { Value = "none" });
                    else if (node is ScriptString cinematicSceneDefinitionString)
                        return CompileTagExpression<CinematicScene>(HsType.CinematicSceneDefinition, cinematicSceneDefinitionString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.BinkDefinition:
                    if (node is ScriptSymbol binkDefinitionSymbol && binkDefinitionSymbol.Value == "none")
                        return CompileTagExpression<Bink>(HsType.BinkDefinition, new ScriptString { Value = "none" });
                    else if (node is ScriptString binkDefinitionString)
                        return CompileTagExpression<Bink>(HsType.BinkDefinition, binkDefinitionString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.AnyTag:
                    if (node is ScriptSymbol anyTagSymbol && anyTagSymbol.Value == "none")
                        return CompileUntypedTagExpression(HsType.AnyTag, new ScriptString { Value = "none" });
                    else if (node is ScriptString anyTagString)
                        return CompileUntypedTagExpression(HsType.AnyTag, anyTagString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.AnyTagNotResolving:
                    if (node is ScriptSymbol anyTagNotResolvingSymbol && anyTagNotResolvingSymbol.Value == "none")
                        return CompileUntypedTagExpression(HsType.AnyTagNotResolving, new ScriptString { Value = "none" });
                    else if (node is ScriptString anyTagNotResolvingString)
                        return CompileUntypedTagExpression(HsType.AnyTagNotResolving, anyTagNotResolvingString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.GameDifficulty:
                {
                    if (node is ScriptSymbol s) return CompileEnumExpression<GameDifficulty>(HsType.GameDifficulty, s);
                    else if (node is ScriptInteger i) return CompileEnumExpression<GameDifficulty>(HsType.GameDifficulty, new ScriptSymbol { Value = i.Value.ToString(), Line = i.Line });
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");
                }

                case HsType.Team:
                {
                    if (node is ScriptSymbol s) return CompileEnumExpression<GameTeam>(HsType.Team, s);
                    else if (node is ScriptInteger i) return CompileEnumExpression<GameTeam>(HsType.Team, new ScriptSymbol { Value = i.Value.ToString(), Line = i.Line });
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");
                }

                case HsType.MpTeam:
                {
                    if (node is ScriptSymbol s) return CompileEnumExpression<GameMultiplayerTeam>(HsType.MpTeam, s);
                    else if (node is ScriptInteger i) return CompileEnumExpression<GameMultiplayerTeam>(HsType.MpTeam, new ScriptSymbol { Value = i.Value.ToString(), Line = i.Line });
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");
                }

                case HsType.Controller:
                {
                    if (node is ScriptSymbol s) return CompileEnumExpression<GameController>(HsType.Controller, s);
                    else if (node is ScriptInteger i) return CompileEnumExpression<GameController>(HsType.Controller, new ScriptSymbol { Value = i.Value.ToString(), Line = i.Line });
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");
                }

                case HsType.ButtonPreset:
                {
                    if (node is ScriptSymbol s) return CompileEnumExpression<GameControllerButtonPreset>(HsType.ButtonPreset, s);
                    else if (node is ScriptInteger i) return CompileEnumExpression<GameControllerButtonPreset>(HsType.ButtonPreset, new ScriptSymbol { Value = i.Value.ToString(), Line = i.Line });
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");
                }

                case HsType.JoystickPreset:
                {
                    if (node is ScriptSymbol s) return CompileEnumExpression<GameControllerJoystickPreset>(HsType.JoystickPreset, s);
                    else if (node is ScriptInteger i) return CompileEnumExpression<GameControllerJoystickPreset>(HsType.JoystickPreset, new ScriptSymbol { Value = i.Value.ToString(), Line = i.Line });
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");
                }

                //case HsType.PlayerColor:
                //    if (node is ScriptSymbol playerColorSymbol)
                //        return CompilePlayerColorExpression(playerColorSymbol);
                //    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.PlayerCharacterType:
                {
                    if (node is ScriptSymbol s) return CompileEnumExpression<GamePlayerCharacterType>(HsType.PlayerCharacterType, s);
                    else if (node is ScriptInteger i) return CompileEnumExpression<GamePlayerCharacterType>(HsType.PlayerCharacterType, new ScriptSymbol { Value = i.Value.ToString(), Line = i.Line });
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");
                }

                case HsType.VoiceOutputSetting:
                {
                    if (node is ScriptSymbol s) return CompileEnumExpression<GameVoiceOutputSetting>(HsType.VoiceOutputSetting, s);
                    else if (node is ScriptInteger i) return CompileEnumExpression<GameVoiceOutputSetting>(HsType.VoiceOutputSetting, new ScriptSymbol { Value = i.Value.ToString(), Line = i.Line });
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");
                }

                case HsType.VoiceMask:
                {
                    if (node is ScriptSymbol s) return CompileEnumExpression<GameVoiceMask>(HsType.VoiceMask, s);
                    else if (node is ScriptInteger i) return CompileEnumExpression<GameVoiceMask>(HsType.VoiceMask, new ScriptSymbol { Value = i.Value.ToString(), Line = i.Line });
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");
                }

                case HsType.SubtitleSetting:
                {
                    if (node is ScriptSymbol s) return CompileEnumExpression<GameSubtitleSetting>(HsType.SubtitleSetting, s);
                    else if (node is ScriptInteger i) return CompileEnumExpression<GameSubtitleSetting>(HsType.SubtitleSetting, new ScriptSymbol { Value = i.Value.ToString(), Line = i.Line });
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");
                }

                case HsType.ActorType:
                {
                    if (node is ScriptSymbol s) return CompileEnumExpression<ActorTypeEnum>(HsType.ActorType, s);
                    else if (node is ScriptInteger i) return CompileEnumExpression<ActorTypeEnum>(HsType.ActorType, new ScriptSymbol { Value = i.Value.ToString(), Line = i.Line });
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");
                }

                case HsType.ModelState:
                {
                    if (node is ScriptSymbol s) return CompileEnumExpression<GameModelState>(HsType.ModelState, s);
                    else if (node is ScriptInteger i) return CompileEnumExpression<GameModelState>(HsType.ModelState, new ScriptSymbol { Value = i.Value.ToString(), Line = i.Line });
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");
                }

                case HsType.Event:
                {
                    if (node is ScriptSymbol s) return CompileEnumExpression<GameEventType>(HsType.Event, s);
                    else if (node is ScriptInteger i) return CompileEnumExpression<GameEventType>(HsType.Event, new ScriptSymbol { Value = i.Value.ToString(), Line = i.Line });
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");
                }

                case HsType.CharacterPhysics:
                {
                    if (node is ScriptSymbol s) return CompileEnumExpression<GameCharacterPhysics>(HsType.CharacterPhysics, s);
                    else if (node is ScriptInteger i) return CompileEnumExpression<GameCharacterPhysics>(HsType.CharacterPhysics, new ScriptSymbol { Value = i.Value.ToString(), Line = i.Line });
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");
                }

                case HsType.PrimarySkull:
                {
                    if (node is ScriptSymbol s) return CompileEnumExpression<GamePrimarySkull>(HsType.PrimarySkull, s);
                    else if (node is ScriptInteger i) return CompileEnumExpression<GamePrimarySkull>(HsType.PrimarySkull, new ScriptSymbol { Value = i.Value.ToString(), Line = i.Line });
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");
                }

                case HsType.SecondarySkull:
                {
                    if (node is ScriptSymbol s) return CompileEnumExpression<GameSecondarySkull>(HsType.SecondarySkull, s);
                    else if (node is ScriptInteger i) return CompileEnumExpression<GameSecondarySkull>(HsType.SecondarySkull, new ScriptSymbol { Value = i.Value.ToString(), Line = i.Line });
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");
                }

                case HsType.Object:
                    if (node is ScriptSymbol objectSymbol && objectSymbol.Value == "none")
                        return CompileObjectExpression(new ScriptString { Value = "none" });
                    else if (node is ScriptString objectString)
                        return CompileObjectExpression(objectString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.Unit:
                    if (node is ScriptSymbol unitSymbol && unitSymbol.Value == "none")
                        return CompileUnitExpression(new ScriptString { Value = "none" });
                    else if (node is ScriptString unitString)
                        return CompileUnitExpression(unitString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.Vehicle:
                    if (node is ScriptSymbol vehicleSymbol && vehicleSymbol.Value == "none")
                        return CompileVehicleExpression(new ScriptString { Value = "none" });
                    else if (node is ScriptString vehicleString)
                        return CompileVehicleExpression(vehicleString);
                    else if (node is ScriptSymbol vehicleSymbolString)
                        return CompileVehicleExpression(new ScriptString { Value = vehicleSymbolString.Value });
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.Weapon:
                    if (node is ScriptSymbol weaponSymbol && weaponSymbol.Value == "none")
                        return CompileWeaponExpression(new ScriptString { Value = "none" });
                    else if (node is ScriptString weaponString)
                        return CompileWeaponExpression(weaponString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.Device:
                    if (node is ScriptSymbol deviceSymbol && deviceSymbol.Value == "none")
                        return CompileDeviceExpression(new ScriptString { Value = "none" });
                    else if (node is ScriptString deviceString)
                        return CompileDeviceExpression(deviceString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.Scenery:
                    if (node is ScriptSymbol scenerySymbol && scenerySymbol.Value == "none")
                        return CompileSceneryExpression(new ScriptString { Value = "none" });
                    else if (node is ScriptString sceneryString)
                        return CompileSceneryExpression(sceneryString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.EffectScenery:
                    if (node is ScriptSymbol effectScenerySymbol && effectScenerySymbol.Value == "none")
                        return CompileEffectSceneryExpression(new ScriptString { Value = "none" });
                    else if (node is ScriptString effectSceneryString)
                        return CompileEffectSceneryExpression(effectSceneryString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.ObjectName:
                    if (node is ScriptString objectNameString)
                        return CompileObjectNameExpression(objectNameString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.UnitName:
                    if (node is ScriptString unitNameString)
                        return CompileUnitNameExpression(unitNameString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.VehicleName:
                    if (node is ScriptString vehicleNameString)
                        return CompileVehicleNameExpression(vehicleNameString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.WeaponName:
                    if (node is ScriptString weaponNameString)
                        return CompileWeaponNameExpression(weaponNameString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.DeviceName:
                    if (node is ScriptString deviceNameString)
                        return CompileDeviceNameExpression(deviceNameString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.SceneryName:
                    if (node is ScriptString sceneryNameString)
                        return CompileSceneryNameExpression(sceneryNameString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.EffectSceneryName:
                    if (node is ScriptString effectSceneryNameString)
                        return CompileEffectSceneryNameExpression(effectSceneryNameString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.CinematicLightprobe:
                    if (node is ScriptSymbol cinematicLightprobeSymbol)
                        return CompileCinematicLightprobeExpression(cinematicLightprobeSymbol);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.AnimationBudgetReference:
                    if (node is ScriptString animationBudgetReferenceString)
                        return CompileAnimationBudgetReferenceExpression(animationBudgetReferenceString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.LoopingSoundBudgetReference:
                    if (node is ScriptString loopingSoundBudgetReferenceString)
                        return CompileLoopingSoundBudgetReferenceExpression(loopingSoundBudgetReferenceString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");

                case HsType.SoundBudgetReference:
                    if (node is ScriptString soundBudgetReferenceString)
                        return CompileSoundBudgetReferenceExpression(soundBudgetReferenceString);
                    else throw new ScriptCompilerException((node as IScriptSyntax)?.Line ?? 0, $"Unexpected expression \'{node}\'.");
            }

            throw new ScriptCompilerException(node.Line, $"Cannot compile expression '{node}' as type '{type}'. Check that the return type matches the script declaration.");
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
                            throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");

                        // Match hs_parse_equality: parse first arg as Unparsed so it resolves
                        // to its own type. Bare literals have no type so fall back to Real,
                        // matching the engine's own fallback path in hs_parse_equality.
                        var firstArgType = (tailGroup.Head is ScriptInteger || tailGroup.Head is ScriptReal)
                            ? HsType.Real
                            : HsType.Unparsed;
                        functionNameExpr.NextExpressionHandle = CompileExpression(firstArgType, tailGroup.Head);

                        var firstExpr = ScriptExpressions[functionNameExpr.NextExpressionHandle.Index];

                        if (!(tailGroup.Tail is ScriptGroup tailTailGroup) || !(tailTailGroup.Tail is ScriptInvalid))
                            throw new ScriptCompilerException(group.Line, $"Unexpected expression near \'{group}\'.");

                        // Second arg matches first's resolved type. If first resolved to Unparsed
                        // (e.g. a sub-expression group), compile second as Unparsed too.
                        firstExpr.NextExpressionHandle = (tailTailGroup.Head is ScriptGroup)
                            ? CompileExpression(HsType.Unparsed, tailTailGroup.Head)
                            : CompileExpression(firstExpr.ValueType, tailTailGroup.Head);

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
                if (!Cache.TagCache.TryGetTag<TTag>(tagString.Value, out var instance))
                    throw new ScriptCompilerException(tagString.Line, $"Could not find {typeof(TTag).Name} tag: '{tagString.Value}'.");
                WriteTagToSourceFileReferences(new ScriptString { Value = tagString.Value + "." + instance.Group.ToString() });
                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(tagString.Value);
                Array.Copy(BitConverter.GetBytes(instance.Index), expr.Data, 4);
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

        private DatumHandle CompileScriptExpression(ScriptSymbol scriptSymbol)
        {
            var handle = AllocateExpression(HsType.Script, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)scriptSymbol.Line);

            if (handle != DatumHandle.None)
            {
                var scriptIndex = Scripts.FindIndex(s => s.ScriptName == scriptSymbol.Value);

                if (scriptIndex == -1)
                    throw new ScriptCompilerException(scriptSymbol.Line, $"Script not defined: '{scriptSymbol.Value}'.");

                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(scriptSymbol.Value);
                Array.Copy(BitConverter.GetBytes((short)scriptIndex), expr.Data, 2);
            }

            return handle;
        }

        private DatumHandle CompileStringIdExpression(ScriptString stringIdString)
        {
            var handle = AllocateExpression(HsType.StringId, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)stringIdString.Line);

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

        private DatumHandle CompileCutsceneTitleExpression(ScriptSymbol cutsceneTitleSymbol)
        {
            var handle = AllocateExpression(HsType.CutsceneTitle, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)cutsceneTitleSymbol.Line);

            if (handle != DatumHandle.None)
            {
                var expr = ScriptExpressions[handle.Index];
                if (cutsceneTitleSymbol.Value == "none")
                {
                    expr.StringAddress = 0;
                    Array.Copy(BitConverter.GetBytes((short)-1), expr.Data, 2);
                }
                else
                {
                    var cutsceneTitleIndex = Definition.CutsceneTitles.FindIndex(ct => cutsceneTitleSymbol.Value == Cache.StringTable.GetString(ct.Name));
                    if (cutsceneTitleIndex == -1)
                        throw new ScriptCompilerException(cutsceneTitleSymbol.Line, $"Value not found or invalid: '{(cutsceneTitleSymbol.Value)}'.");
                    expr.StringAddress = CompileStringAddress(cutsceneTitleSymbol.Value);
                    Array.Copy(BitConverter.GetBytes((short)cutsceneTitleIndex), expr.Data, 2);
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

                            var squadIndex = Definition.Squads.FindIndex(s => s.Name == tokens[0]);

                            if (squadIndex != -1)
                            {
                                value = (1 << 29) | (squadIndex & 0xFFFF);
                                break;
                            }

                            //
                            // type 2: squad group
                            //

                            var squadGroupIndex = Definition.SquadGroups.FindIndex(sg => sg.Name == tokens[0]);

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

                            var objectiveIndex = Definition.AiObjectives.FindIndex(o => tokens[0] == Cache.StringTable.GetString(o.Name));

                            if (objectiveIndex != -1)
                            {
                                value = (6 << 29) | (0x1FFF << 16) | (objectiveIndex & 0xFFFF);
                                break;
                            }

                            goto default;
                        }

                    case 2:
                        {
                            var squadIndex = Definition.Squads.FindIndex(s => s.Name == tokens[0]);

                            if (squadIndex != -1)
                            {
                                var squad = Definition.Squads[squadIndex];

                                //
                                // type 4: spawn point
                                //

                                var spawnPointIndex = squad.SpawnPoints.FindIndex(sp => tokens[1] == Cache.StringTable.GetString(sp.Name));

                                if (spawnPointIndex != -1)
                                {
                                    value = (4 << 29) | ((squadIndex & 0x1FFF) << 16) | (spawnPointIndex & 0xFF);
                                    break;
                                }

                                //
                                // type 5: spawn formation
                                //

                                var spawnFormationIndex = squad.SpawnFormations.FindIndex(sf => tokens[1] == Cache.StringTable.GetString(sf.Name));

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

                            var objectiveIndex = Definition.AiObjectives.FindIndex(o => tokens[0] == Cache.StringTable.GetString(o.Name));

                            if (objectiveIndex != -1)
                            {
                                var taskIndex = Definition.AiObjectives[objectiveIndex].Tasks.FindIndex(t => tokens[1] == Cache.StringTable.GetString(t.Name));

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

        private DatumHandle CompileAiCommandListExpression(ScriptString aiCommandListString) =>
            throw new ScriptCompilerException(aiCommandListString.Line, $"The type 'AiCommandList' is not yet supported by the compiler.");

        private DatumHandle CompileAiCommandScriptExpression(ScriptSymbol aiCommandScriptSymbol)
        {
            // An ai_command_script reference is the name of a command_script-type script defined
            // in the same scenario. It encodes identically to the Script type: a 2-byte index into
            // the Scripts list. The node uses Flags Expression (not Primitive), matching the
            // 2-byte script index in Data, script name as StringAddress.
            var handle = AllocateExpression(HsType.AiCommandScript, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)aiCommandScriptSymbol.Line);

            if (handle != DatumHandle.None)
            {
                var scriptIndex = Scripts.FindIndex(s =>
                    s.ScriptName == aiCommandScriptSymbol.Value &&
                    s.Type == HsScriptType.Command_Script);

                if (scriptIndex == -1)
                    throw new ScriptCompilerException(aiCommandScriptSymbol.Line, $"No command_script named '{aiCommandScriptSymbol.Value}' is defined.");

                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(aiCommandScriptSymbol.Value);
                Array.Copy(BitConverter.GetBytes((short)scriptIndex), expr.Data, 2);
            }

            return handle;
        }

        private DatumHandle CompileAiLineExpression(ScriptString aiLineString)
        {
            var handle = AllocateExpression(HsType.AiLine, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)aiLineString.Line);

            if (handle != DatumHandle.None)
            {
                var expr = ScriptExpressions[handle.Index];
                if (aiLineString.Value == "none")
                {
                    expr.StringAddress = 0;
                    Array.Copy(BitConverter.GetBytes(0u), expr.Data, 4);
                }
                else
                {
                    var lineStringId = Cache.StringTable.GetStringId(aiLineString.Value);
                    expr.StringAddress = CompileStringAddress(aiLineString.Value);
                    Array.Copy(BitConverter.GetBytes(lineStringId.Value), expr.Data, 4);
                }
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
                    var startingProfileIndex = Definition.PlayerStartingProfile.FindIndex(sp => sp.Name == startingProfileString.Value);
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
                        var pointSetIndex = Definition.ScriptingData[0].PointSets.FindIndex(ps => ps.Name == tokens[0]);
                        if (pointSetIndex == -1)
                            throw new ScriptCompilerException(pointReferenceString.Line, $"No point set named '{pointReferenceString.Value}' found.");
                        expr.StringAddress = CompileStringAddress(pointReferenceString.Value);
                        Array.Copy(BitConverter.GetBytes((pointSetIndex << 16) | 0xFFFF), expr.Data, 4);
                    }
                    else if (tokens.Length == 2)
                    {
                        var pointSetIndex = Definition.ScriptingData[0].PointSets.FindIndex(ps => ps.Name == tokens[0]);
                        if (pointSetIndex == -1)
                            throw new ScriptCompilerException(pointReferenceString.Line, $"No point reference named '{pointReferenceString.Value}' found. Expected format: 'point_set/point_name'.");
                        var pointIndex = Definition.ScriptingData[0].PointSets[pointSetIndex].Points.FindIndex(p => p.Name == tokens[1]);
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

        private DatumHandle CompileStyleExpression(ScriptString styleString)
        {
            var handle = AllocateExpression(HsType.Style, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)styleString.Line);

            if (handle != DatumHandle.None)
            {
                if (styleString.Value == "none")
                {
                    var expr = ScriptExpressions[handle.Index];
                    expr.StringAddress = CompileStringAddress(styleString.Value);
                    Array.Copy(BitConverter.GetBytes(-1), expr.Data, 4);
                    return handle;
                }

                if (!Cache.TagCache.TryGetTag<Style>(styleString.Value, out var instance))
                    throw new ScriptCompilerException(styleString.Line, $"Could not find Style tag: '{(styleString.Value)}'.");

                WriteTagToSourceFileReferences(new ScriptString { Value = styleString.Value + "." + instance.Group.ToString() });

                var expr2 = ScriptExpressions[handle.Index];
                expr2.StringAddress = CompileStringAddress(styleString.Value);
                Array.Copy(BitConverter.GetBytes(instance.Index), expr2.Data, 4);
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
                    Definition.ObjectNames.FindIndex(on => on.Name == objectListString.Value);

                if (objectListString.Value != "none" && objectIndex == -1)
                    return CompileAiExpression(objectListString, HsType.ObjectList);

                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(objectListString.Value);
                Array.Copy(BitConverter.GetBytes((short)objectIndex), expr.Data, 2);
            }

            return handle;
        }

        private DatumHandle CompileFolderExpression(ScriptString folderString)
        {
            var handle = AllocateExpression(HsType.Folder, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)folderString.Line);

            if (handle != DatumHandle.None)
            {
                var folderIndex = folderString.Value == "none" ? -1 : Definition.EditorFolders.FindIndex(ef => ef.Name == folderString.Value);

                if (folderString.Value != "none" && folderIndex == -1)
                    throw new ScriptCompilerException(folderString.Line, $"Value not found or invalid: '{(folderString.Value)}'.");

                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(folderString.Value);
                Array.Copy(BitConverter.GetBytes(folderIndex), expr.Data, 4);
            }

            return handle;
        }

        private DatumHandle CompileObjectDefinitionExpression(ScriptString objectDefinitionString)
        {
            var handle = AllocateExpression(HsType.ObjectDefinition, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)objectDefinitionString.Line);

            if (handle != DatumHandle.None)
            {
                // Specifically because of object_list_children which will return all objects when passed none (-1)
                if (objectDefinitionString.Value == "none")
                {
                    var expr = ScriptExpressions[handle.Index];
                    expr.StringAddress = 0;
                    Array.Copy(BitConverter.GetBytes(-1), expr.Data, 4);
                }
                else
                {
                    if (!Cache.TagCache.TryGetTag(objectDefinitionString.Value, out var instance) || !instance.IsInGroup("obje"))
                        throw new ScriptCompilerException(objectDefinitionString.Line, $"Value not found or invalid: '{(objectDefinitionString.Value)}'.");

                    WriteTagToSourceFileReferences(new ScriptString { Value = objectDefinitionString.Value + "." + instance.Group.ToString() });

                    var expr = ScriptExpressions[handle.Index];
                    expr.StringAddress = CompileStringAddress(objectDefinitionString.Value);
                    Array.Copy(BitConverter.GetBytes(instance.Index), expr.Data, 4);
                }
            }

            return handle;
        }

        private DatumHandle CompileUntypedTagExpression(HsType type, ScriptString tagString)
        {
            var handle = AllocateExpression(type, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)tagString.Line);
            if (handle != DatumHandle.None)
            {
                if (!Cache.TagCache.TryGetTag(tagString.Value, out var instance))
                    throw new ScriptCompilerException(tagString.Line, $"Value not found or invalid: '{tagString.Value}'.");
                WriteTagToSourceFileReferences(new ScriptString { Value = tagString.Value + "." + instance.Group.ToString() });
                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(tagString.Value);
                Array.Copy(BitConverter.GetBytes(instance.Index), expr.Data, 4);
            }
            return handle;
        }

        private DatumHandle CompileObjectExpression(ScriptString objectString)
        {
            ushort? objectOpcode = objectString.Value == "none" ? null : GetHsTypeAsInteger(HsType.ObjectName);
            var handle = AllocateExpression(HsType.Object, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, objectOpcode, line: (short)objectString.Line);

            if (handle != DatumHandle.None)
            {
                var objectIndex = objectString.Value == "none" ? -1 :
                    Definition.ObjectNames.FindIndex(on => on.Name == objectString.Value);

                if (objectString.Value != "none" && objectIndex == -1)
                    return CompileAiExpression(objectString, HsType.Object);

                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(objectString.Value);
                Array.Copy(BitConverter.GetBytes((short)objectIndex), expr.Data, 2);
            }

            return handle;
        }

        private DatumHandle CompileUnitExpression(ScriptString unitString)
        {
            ushort? unitOpcode = unitString.Value == "none" ? null : GetHsTypeAsInteger(HsType.UnitName);
            var handle = AllocateExpression(HsType.Unit, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, unitOpcode, line: (short)unitString.Line);

            if (handle != DatumHandle.None)
            {
                var unitIndex = unitString.Value == "none" ? -1 :
                    Definition.ObjectNames.FindIndex(on => on.Name == unitString.Value);

                if (unitString.Value != "none" && unitIndex == -1)
                    return CompileAiExpression(unitString, HsType.Unit);

                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(unitString.Value);
                Array.Copy(BitConverter.GetBytes((short)unitIndex), expr.Data, 2);
            }

            return handle;
        }

        private DatumHandle CompileVehicleExpression(ScriptString vehicleString)
        {
            ushort? vehicleOpcode = vehicleString.Value == "none" ? null : GetHsTypeAsInteger(HsType.VehicleName);
            var handle = AllocateExpression(HsType.Vehicle, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, vehicleOpcode, line: (short)vehicleString.Line);

            if (handle != DatumHandle.None)
            {
                
                var vehicleIndex = vehicleString.Value == "none" ? -1 :
                    Definition.ObjectNames.FindIndex(on => on.Name == vehicleString.Value);

                if (vehicleString.Value != "none" && vehicleIndex == -1)
                    return CompileAiExpression(vehicleString, HsType.Vehicle);

                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(vehicleString.Value);
                Array.Copy(BitConverter.GetBytes((short)vehicleIndex), expr.Data, 2);
            }

            return handle;
        }

        private DatumHandle CompileWeaponExpression(ScriptString weaponString)
        {
            var handle = AllocateExpression(HsType.Weapon, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)weaponString.Line);

            if (handle != DatumHandle.None)
            {
                var weaponIndex = weaponString.Value == "none" ? -1 :
                    Definition.ObjectNames.Find(on => on.Name == weaponString.Value).PlacementIndex;

                if (weaponString.Value != "none" && weaponIndex == -1)
                    throw new ScriptCompilerException(weaponString.Line, $"Value not found or invalid: '{(weaponString.Value)}'.");

                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(weaponString.Value);
                Array.Copy(BitConverter.GetBytes((short)weaponIndex), expr.Data, 2);
            }

            return handle;
        }

        private DatumHandle CompileDeviceExpression(ScriptString deviceString)
        {
            ushort? deviceOpcode = deviceString.Value == "none" ? null : GetHsTypeAsInteger(HsType.DeviceName);
            var handle = AllocateExpression(HsType.Device, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, deviceOpcode, line: (short)deviceString.Line);

            if (handle != DatumHandle.None)
            {
                var deviceIndex = deviceString.Value == "none" ? -1 :
                    Definition.ObjectNames.FindIndex(on => on.Name == deviceString.Value);

                if (deviceString.Value != "none" && deviceIndex == -1)
                    throw new ScriptCompilerException(deviceString.Line, $"Value not found or invalid: '{(deviceString.Value)}'.");

                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(deviceString.Value);
                Array.Copy(BitConverter.GetBytes((short)deviceIndex), expr.Data, 2);
            }

            return handle;
        }

        private DatumHandle CompileSceneryExpression(ScriptString sceneryString)
        {
            ushort? sceneryOpcode = sceneryString.Value == "none" ? null : GetHsTypeAsInteger(HsType.SceneryName);
            var handle = AllocateExpression(HsType.Scenery, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, sceneryOpcode, line: (short)sceneryString.Line);

            if (handle != DatumHandle.None)
            {
                var sceneryIndex = sceneryString.Value == "none" ? -1 :
                    Definition.ObjectNames.FindIndex(on => on.Name == sceneryString.Value);

                if (sceneryString.Value != "none" && sceneryIndex == -1)
                    throw new ScriptCompilerException(sceneryString.Line, $"Value not found or invalid: '{(sceneryString.Value)}'.");

                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(sceneryString.Value);
                Array.Copy(BitConverter.GetBytes((short)sceneryIndex), expr.Data, 2);
            }

            return handle;
        }

        private DatumHandle CompileEffectSceneryExpression(ScriptString effectSceneryString)
        {
            var handle = AllocateExpression(HsType.EffectScenery, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)effectSceneryString.Line);

            if (handle != DatumHandle.None)
            {
                var effectSceneryIndex = effectSceneryString.Value == "none" ? -1 :
                    Definition.ObjectNames.Find(on => on.Name == effectSceneryString.Value).PlacementIndex;

                if (effectSceneryString.Value != "none" && effectSceneryIndex == -1)
                    throw new ScriptCompilerException(effectSceneryString.Line, $"Value not found or invalid: '{(effectSceneryString.Value)}'.");

                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(effectSceneryString.Value);
                Array.Copy(BitConverter.GetBytes(effectSceneryIndex), expr.Data, 4);
            }

            return handle;
        }

        private DatumHandle CompileObjectNameExpression(ScriptString objectNameString)
        {
            var handle = AllocateExpression(HsType.ObjectName, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)objectNameString.Line);

            if (handle != DatumHandle.None)
            {
                var objectNameIndex = Definition.ObjectNames.FindIndex(on => on.Name == objectNameString.Value);

                if (objectNameIndex == -1)
                    throw new ScriptCompilerException(objectNameString.Line, $"No object named '{objectNameString.Value}' found in the scenario.");

                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(objectNameString.Value);
                Array.Copy(BitConverter.GetBytes((short)objectNameIndex), expr.Data, 2);
            }

            return handle;
        }

        private DatumHandle CompileUnitNameExpression(ScriptString objectNameString)
        {
            var handle = AllocateExpression(HsType.UnitName, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)objectNameString.Line);

            if (handle != DatumHandle.None)
            {
                var objectNameIndex = Definition.ObjectNames.FindIndex(on => on.Name == objectNameString.Value);

                if (objectNameIndex == -1)
                    throw new ScriptCompilerException(objectNameString.Line, $"No object named '{objectNameString.Value}' found in the scenario.");

                var unitObjType = Definition.ObjectNames[objectNameIndex].ObjectType.HaloOnline;
                if (unitObjType != GameObjectTypeHaloOnline.Biped &&
                    unitObjType != GameObjectTypeHaloOnline.Giant &&
                    unitObjType != GameObjectTypeHaloOnline.Vehicle)
                {
                    throw new ScriptCompilerException(objectNameString.Line, $"No object named '{objectNameString.Value}' found in the scenario.");
                }

                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(objectNameString.Value);
                Array.Copy(BitConverter.GetBytes((short)objectNameIndex), expr.Data, 2);
            }

            return handle;
        }

        private DatumHandle CompileVehicleNameExpression(ScriptString objectNameString)
        {
            var handle = AllocateExpression(HsType.VehicleName, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)objectNameString.Line);

            if (handle != DatumHandle.None)
            {
                var objectNameIndex = Definition.ObjectNames.FindIndex(on => on.Name == objectNameString.Value);

                if (objectNameIndex == -1)
                    throw new ScriptCompilerException(objectNameString.Line, $"No object named '{objectNameString.Value}' found in the scenario.");

                if (Definition.ObjectNames[objectNameIndex].ObjectType.HaloOnline != GameObjectTypeHaloOnline.Vehicle)
                    throw new ScriptCompilerException(objectNameString.Line, $"No object named '{objectNameString.Value}' found in the scenario.");

                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(objectNameString.Value);
                Array.Copy(BitConverter.GetBytes((short)objectNameIndex), expr.Data, 2);
            }

            return handle;
        }

        private DatumHandle CompileWeaponNameExpression(ScriptString objectNameString)
        {
            var handle = AllocateExpression(HsType.WeaponName, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)objectNameString.Line);

            if (handle != DatumHandle.None)
            {
                var objectNameIndex = Definition.ObjectNames.FindIndex(on => on.Name == objectNameString.Value);

                if (objectNameIndex == -1)
                    throw new ScriptCompilerException(objectNameString.Line, $"No object named '{objectNameString.Value}' found in the scenario.");

                if (Definition.ObjectNames[objectNameIndex].ObjectType.HaloOnline != GameObjectTypeHaloOnline.Weapon)
                    throw new ScriptCompilerException(objectNameString.Line, $"No object named '{objectNameString.Value}' found in the scenario.");

                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(objectNameString.Value);
                Array.Copy(BitConverter.GetBytes((short)objectNameIndex), expr.Data, 2);
            }

            return handle;
        }

        private DatumHandle CompileDeviceNameExpression(ScriptString objectNameString)
        {
            var handle = AllocateExpression(HsType.DeviceName, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)objectNameString.Line);

            if (handle != DatumHandle.None)
            {
                var objectNameIndex = Definition.ObjectNames.FindIndex(on => on.Name == objectNameString.Value);

                if (objectNameIndex == -1)
                    throw new ScriptCompilerException(objectNameString.Line, $"No object named '{objectNameString.Value}' found in the scenario.");

                var deviceObjType = Definition.ObjectNames[objectNameIndex].ObjectType.HaloOnline;
                if (deviceObjType != GameObjectTypeHaloOnline.AlternateRealityDevice &&
                    deviceObjType != GameObjectTypeHaloOnline.Control &&
                    deviceObjType != GameObjectTypeHaloOnline.Machine)
                {
                    throw new ScriptCompilerException(objectNameString.Line, $"No object named '{objectNameString.Value}' found in the scenario.");
                }

                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(objectNameString.Value);
                Array.Copy(BitConverter.GetBytes((short)objectNameIndex), expr.Data, 2);
            }

            return handle;
        }

        private DatumHandle CompileSceneryNameExpression(ScriptString objectNameString)
        {
            var handle = AllocateExpression(HsType.SceneryName, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)objectNameString.Line);

            if (handle != DatumHandle.None)
            {
                var objectNameIndex = Definition.ObjectNames.FindIndex(on => on.Name == objectNameString.Value);

                if (objectNameIndex == -1)
                    throw new ScriptCompilerException(objectNameString.Line, $"No object named '{objectNameString.Value}' found in the scenario.");

                if (Definition.ObjectNames[objectNameIndex].ObjectType.HaloOnline != GameObjectTypeHaloOnline.Scenery)
                    throw new ScriptCompilerException(objectNameString.Line, $"No object named '{objectNameString.Value}' found in the scenario.");

                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(objectNameString.Value);
                Array.Copy(BitConverter.GetBytes((short)objectNameIndex), expr.Data, 2);
            }

            return handle;
        }

        private DatumHandle CompileEffectSceneryNameExpression(ScriptString objectNameString)
        {
            var handle = AllocateExpression(HsType.EffectSceneryName, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)objectNameString.Line);

            if (handle != DatumHandle.None)
            {
                var objectNameIndex = Definition.ObjectNames.FindIndex(on => on.Name == objectNameString.Value);

                if (objectNameIndex == -1)
                    throw new ScriptCompilerException(objectNameString.Line, $"No object named '{objectNameString.Value}' found in the scenario.");

                if (Definition.ObjectNames[objectNameIndex].ObjectType.HaloOnline != GameObjectTypeHaloOnline.EffectScenery)
                    throw new ScriptCompilerException(objectNameString.Line, $"No object named '{objectNameString.Value}' found in the scenario.");

                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(objectNameString.Value);
                Array.Copy(BitConverter.GetBytes((short)objectNameIndex), expr.Data, 2);
            }

            return handle;
        }

        private DatumHandle CompileCinematicLightprobeExpression(ScriptSymbol cinematicLightprobeSymbol)
        {
            var handle = AllocateExpression(HsType.CinematicLightprobe, HsSyntaxNodeFlags.Primitive | HsSyntaxNodeFlags.DoNotGC, line: (short)cinematicLightprobeSymbol.Line);

            if (handle != DatumHandle.None)
            {
                var cinematicLightprobeIndex = Definition.CinematicLighting.FindIndex(cl => cinematicLightprobeSymbol.Value == Cache.StringTable.GetString(cl.Name));

                if (cinematicLightprobeIndex == -1)
                    throw new ScriptCompilerException(cinematicLightprobeSymbol.Line, $"Value not found or invalid: '{(cinematicLightprobeSymbol.Value)}'.");

                var expr = ScriptExpressions[handle.Index];
                expr.StringAddress = CompileStringAddress(cinematicLightprobeSymbol.Value);
                Array.Copy(BitConverter.GetBytes(cinematicLightprobeIndex), expr.Data, 4);
            }

            return handle;
        }

        private DatumHandle CompileAnimationBudgetReferenceExpression(ScriptString animationBudgetReferenceString) =>
            throw new ScriptCompilerException(animationBudgetReferenceString.Line, $"The type 'AnimationBudgetReference' is not yet supported by the compiler.");

        private DatumHandle CompileLoopingSoundBudgetReferenceExpression(ScriptString loopingSoundBudgetReferenceString) =>
            throw new ScriptCompilerException(loopingSoundBudgetReferenceString.Line, $"The type 'LoopingSoundBudgetReference' is not yet supported by the compiler.");

        private DatumHandle CompileSoundBudgetReferenceExpression(ScriptString soundBudgetReferenceString) =>
            throw new ScriptCompilerException(soundBudgetReferenceString.Line, $"The type 'SoundBudgetReference' is not yet supported by the compiler.");

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