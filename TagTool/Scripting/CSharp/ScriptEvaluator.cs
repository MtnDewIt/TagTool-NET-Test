﻿using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TagTool.Commands;
using TagTool.Commands.Common;

namespace TagTool.Scripting.CSharp
{
    public class ScriptEvaluator
    {
        private ScriptState<object> _state;
        private readonly AssemblyResolver _assemblyResolver = new AssemblyResolver();

        static string[] DefaultImports =
        [
            "System",
            "System.IO",
            "System.Text",
            "System.Linq",
            "System.Collections.Generic",
            "System.Collections",
            "TagTool",
            "TagTool.Common",
            "TagTool.IO",
            "TagTool.Serialization",
            "TagTool.Extensions",
            "TagTool.Cache",
            "TagTool.Tags",
            "TagTool.Tags.Definitions",
            "TagTool.Tags.Resources",
            "TagTool.Commands",
            "TagTool.Commands.Common",
            "TagTool.Porting"
        ];

        public void ClearState()
        {
            _state = null;
        }

        public object EvaluateScript(object context, string input, bool inline = false, bool isolate = false, DirectoryInfo sourceDirectory = null)
        {
            sourceDirectory ??= new DirectoryInfo(Program.TagToolDirectory);
            var preprocessResult = new ScriptPreprocessor().PreprocessScript(input);
            var references = GetScriptReferences(preprocessResult.Imports, sourceDirectory);

            var scriptOptions = ScriptOptions.Default
                .WithAllowUnsafe(true)
                .WithOptimizationLevel(Microsoft.CodeAnalysis.OptimizationLevel.Debug)
                .WithReferences(references)
                .WithEmitDebugInformation(true)
                .WithImports(DefaultImports);

            try
            {
                ScriptState<object> newState = _state == null || isolate
                    ? CSharpScript.RunAsync(preprocessResult.Source, scriptOptions, context).GetAwaiter().GetResult()
                    : _state.ContinueWithAsync(preprocessResult.Source, scriptOptions).GetAwaiter().GetResult();

                if (!isolate)
                    _state = newState;

                return newState.ReturnValue;
            }
            catch (Exception ex)
            {
                new TagToolError(CommandError.CustomError, ex.Message);
                return null;
            }
        }

        public string EvaluateInlineExpressions(object context, string input, int offset = 0)
        {
            int startIndex = -1;
            var stack = new Stack<int>();

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == '{' && input[i - 1] == '^')
                {
                    stack.Push(i - 1);
                    startIndex = i - 1;
                }
                else if (input[i] == '}' && stack.Count > 0)
                {
                    if (startIndex == stack.Peek())
                    {
                        var before = input.Substring(0, startIndex);
                        var expression = input.Substring(startIndex + 2, i - startIndex - 2);
                        var after = EvaluateInlineExpressions(context, input.Substring(i + 1), offset + i + 1);
                        if (after == null)
                            return null;

                        var result = EvaluateScript(context, expression, inline: true);
                        return before + result + after;
                    }
                    stack.Pop();
                }
            }

            if (stack.Count != 0 && startIndex != -1)
            {
                new TagToolError(CommandError.CustomError, $"(0:{offset + startIndex + 1}): Unmatched brace.");
                return null;
            }

            return input;
        }

        private List<Assembly> GetScriptReferences(List<string> imports, DirectoryInfo sourceDirectory)
        {
            var references = new List<Assembly> { typeof(ExecuteCSharpCommand).Assembly };
            foreach (var importName in imports)
            {
                try
                {
                    var assemblyName = _assemblyResolver.FindAssembly(sourceDirectory, importName);
                    if (assemblyName == null)
                        throw new FileNotFoundException("Failed to find assembly");

                    references.Add(Assembly.Load(assemblyName));
                }
                catch (Exception ex)
                {
                    new TagToolError(CommandError.CustomError, $"Failed to load assembly `{importName}`. {ex.Message}");
                }
            }
            return references;
        }
    }
}
