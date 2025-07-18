using TagTool.Common.Logging;

namespace TagTool.Commands.Common
{
    public enum CommandError
    {
        None,
        CustomMessage,
        CustomError,
        ArgCount,
        ArgInvalid,
        OperationFailed,
        TagInvalid,
        SyntaxInvalid,
        DirectoryNotFound,
        FileNotFound,
        FileIO,
        FileType,
        CacheUnsupported,
        YesNoSyntax,
    }

    /// <remarks>
    /// Prefer using <see cref="Log.Error(string)"/> directly when outside of commands
    /// </remarks>
    class TagToolError
    {
        public TagToolError(CommandError cmdError, string customMessage = null)
        {
            Log.Error(FormatErrorMessage(cmdError, customMessage));
        }

        private static string FormatErrorMessage(CommandError cmdError, string customMessage)
        {
            bool showHelpMessage = true;
            string output = "";

            if (cmdError != CommandError.CustomMessage && cmdError != CommandError.CustomError)
            {
                switch (cmdError)
                {
                    case CommandError.ArgCount:
                        output += "Incorrect amount of arguments supplied";
                        break;
                    case CommandError.ArgInvalid:
                        output += "An invalid argument was specified";
                        break;
                    case CommandError.OperationFailed:
                        output += "An internal operation failed to evaluate";
                        showHelpMessage = false;
                        break;
                    case CommandError.TagInvalid:
                        output += "The specified tag does not exist in the current tag cache";
                        break;
                    case CommandError.SyntaxInvalid:
                        output += "Invalid syntax used";
                        break;
                    case CommandError.DirectoryNotFound:
                        output += "The specified directory could not be found!";
                        break;
                    case CommandError.FileNotFound:
                        output += "The specified file could not be found!";
                        break;
                    case CommandError.FileIO:
                        output += "A file IO operation could not be completed";
                        showHelpMessage = false;
                        break;
                    case CommandError.FileType:
                        output += "The specified file is of the incorrect type";
                        break;
                    case CommandError.CacheUnsupported:
                        output += "The specified blam cache is not supported";
                        showHelpMessage = false;
                        break;
                    case CommandError.YesNoSyntax:
                        output += "A response option other than \"y\" or \"n\" was given";
                        showHelpMessage = false;
                        break;
                }
            }

            bool hasCustomMessage = !string.IsNullOrEmpty(customMessage);

            if (cmdError == CommandError.CustomError && hasCustomMessage)
            {
                output = customMessage;
                showHelpMessage = false;
            }
            else if (hasCustomMessage)
                output += $"\n> {customMessage}";

            if (showHelpMessage)
                output += $"\nEnter \"Help {CommandRunner.CurrentCommandName}\" for command syntax.";

            return output;
        }
    }
}
