using System;
using System.Collections.Generic;
using System.Linq;

namespace TagTool.Scripting.CSharp
{
    public class ScriptPreprocessor
    {
        public ScriptPreprocessResult PreprocessScript(string input)
        {
            var result = new ScriptPreprocessResult();
            var lines = input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
                .Select(line => line.Trim())
                .ToArray();

            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if (line.StartsWith("#import"))
                {
                    var importName = line.Substring(line.IndexOf(' ') + 1).Trim();
                    result.Imports.Add(importName);
                    line = $"// {line}";
                }
                result.Source += $"{line}\n";
            }

            return result;
        }
    }

    public class ScriptPreprocessResult
    {
        public string Source { get; set; }
        public List<string> Imports { get; set; } = new List<string>();
    }
}
