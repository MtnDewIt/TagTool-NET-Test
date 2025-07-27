using System.Collections.Generic;
using TagTool.Common.Logging;

namespace TagTool.Commands.Common
{
    public class SuppressErrorsCommand : Command
    {
        private static readonly Stack<bool> _stack = [];

        public SuppressErrorsCommand()
            : base(true,

                  "SuppressErrors",
                  "Suppresses errors that would otherwise cause the script to terminate",

                  "SuppressErrors [push|pop] [true|false]",

                  "This should really only be used as a last resort if you cannot find another way.\n" +
                  "No guarantees are made that tagtool will not crash.")
        {

        }

        public override object Execute(List<string> args)
        {
            for (int i = 0; i < args.Count; i++)
            {
                string arg = args[i].ToLower();
                switch (arg)
                {
                    case "push":
                        {
                            args.RemoveAt(i--);
                            _stack.Push(CommandRunner.Current.SuppressErrors);
                        }
                        break;
                    case "pop":
                        {
                            args.RemoveAt(i--);
                            if (!_stack.TryPop(out bool oldEnable))
                                return new TagToolError(CommandError.OperationFailed, "Nothing to pop");
                            else
                                Toggle(oldEnable);
                        }
                        break;
                }
            }

            if (args.Count == 0)
                return true;

            if (!bool.TryParse(args[0], out bool enable))
                return new TagToolError(CommandError.ArgInvalid);

            Toggle(enable);
            return true;
        }

        private void Toggle(bool enable)
        {
            string statusString = enable ? "ON" : "OFF";
            Log.Warning($"Error Suppression: {statusString}");

            CommandRunner.Current.SuppressErrors = enable;
        }
    }
}
