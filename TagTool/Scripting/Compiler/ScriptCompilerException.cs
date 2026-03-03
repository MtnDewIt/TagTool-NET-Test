using System;

namespace TagTool.Scripting.Compiler
{
    //
    // Thrown when the script compiler encounters an error in the user's input.
    // Carries the source line number and a human-readable description.
    //
    public class ScriptCompilerException : Exception
    {
        public int Line { get; }

        public ScriptCompilerException(int line, string message)
            : base(line > 0 ? $"Line {line}: {message}" : message)
        {
            Line = line;
        }
    }
}
