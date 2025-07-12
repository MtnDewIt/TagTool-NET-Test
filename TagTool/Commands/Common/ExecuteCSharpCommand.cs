using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TagTool.Scripting.CSharp;

namespace TagTool.Commands.Common
{
    public class ExecuteCSharpCommand : Command
    {
        private CommandContextStack ContextStack;
        private ScriptEvaluator Evaluator;

        public ExecuteCSharpCommand(CommandContextStack contextStack) :
            base(false,

                "CS",
                "Compile and evaluate csharp code",

                "CS [code]",

                "CS - Start an interactive shell.\n" +
                "CS <statement> - Executes the given statement.\n" +
                "CS < \"path to .cs file\" [Arguments] - Executes the given file.\n" +
                "CS ! - Clear the current state\n\n" + BuildHelpText()
                )
        {
            ContextStack = contextStack;
            Evaluator = ContextStack.ScriptEvaluator;
        }

        public override object Execute(List<string> args)
        {
            var evalContext = new ScriptEvaluationContext(ContextStack);

            string input = CommandRunner.CommandLine.Substring(CommandRunner.CommandLine.IndexOf(' ') + 1);
            try
            {
                if (args.Count == 0)
                {
                    return RunInteractiveShell(evalContext);
                }
                else if (args.Count > 1 && args[0].Trim() == "<")
                {
                    string filePath = args[1];

                    if (!File.Exists(filePath))
                        return new TagToolError(CommandError.FileNotFound, filePath);

                    Evaluator.ExecuteScriptFile(evalContext, filePath, args[2..]);
                    return true;
                }
                else if (args.Count == 1 && args[0].Trim() == "!")
                {
                    Evaluator.ClearState();
                    Console.WriteLine("State cleared.");
                    return true;
                }
                else
                {

                    object result = Evaluator.EvaluateScript(evalContext, input, inline: false);
                    if (result != null)
                        PrintReplResult(result);

                    return true;
                }
            }
            catch (Exception ex)
            {
                return new TagToolError(CommandError.CustomError, ex.Message);
            }
        }

        public static bool OutputIsRedirectable(List<string> args)
        {
            return args.Count > 0 && args[0] == "<";
        }

        private object RunInteractiveShell(ScriptEvaluationContext evalContext)
        {
            Console.WriteLine("C# Shell Started.");
            Console.WriteLine("Type :x to Execute, :q to Quit.");
            string lines = "";

            while (true)
            {
                Console.Write("> ");
                string line = Console.ReadLine()?.TrimEnd();
                if (line == ":q")
                    break;
                if (line == ":x")
                    return Evaluator.EvaluateScript(evalContext, lines);

                lines += $"{line}\r\n";
            }

            return true;
        }


        private static void PrintReplResult(object value)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(FormatReplResult(value));
            }
            finally
            {
                Console.ResetColor();
            }
        }

        private static string FormatReplResult(object value)
        {
            switch (value)
            {
                case string s:
                    return $"\"{value}\"";
                case null:
                    return "null";
                default:
                    return value.ToString();
            }
        }

        public static string BuildHelpText()
        {
            Type contextType = typeof(ScriptEvaluationContext);

            var sb = new StringBuilder();
            sb.AppendLine("Globals:");

            var properties = contextType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.GetCustomAttribute<DescriptionAttribute>() != null)
                .OrderBy(p => p.Name);

            foreach (var prop in properties)
            {
                var desc = prop.GetCustomAttribute<DescriptionAttribute>().Description;
                var propType = prop.PropertyType;
                string typeName = propType.GetFriendlyTypeName();
                sb.AppendLine($"  {prop.Name,-16} {typeName,-40} : {desc}");
            }

            sb.AppendLine();

            //sb.AppendLine("Methods:");

            //var methods = contextType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            //    .Where(m => m.GetCustomAttribute<DescriptionAttribute>() != null)
            //    .OrderBy(m => m.Name);

            //foreach (var method in methods)
            //{
            //    var desc = method.GetCustomAttribute<DescriptionAttribute>().Description;
            //    var paramString = string.Join(", ", method.GetParameters().Select(p => $"{p.Name}: {p.ParameterType.Name}"));
            //    sb.AppendLine($"  {method.Name}({paramString}) : {desc}");
            //}

            return sb.ToString();
        }
    }
}
