using System.Collections.Generic;
using System.ComponentModel;
using TagTool.Cache;
using TagTool.Commands;
using TagTool.Commands.Common;
using TagTool.Porting;

namespace TagTool.Scripting.CSharp
{
    public class ScriptEvaluationContext
    {
        private readonly CommandContextStack _contextStack;
        private readonly ScriptGlobalsAccessor _contextGlobals;

        public ScriptEvaluationContext(CommandContextStack contextStack)
        {
            _contextStack = contextStack;
            _contextGlobals = new ScriptGlobalsAccessor(contextStack);
        }

        //
        // Globals
        //

        [Description("File path of the currently executing script")]
        public string ScriptFile { get; set; } = null;

        [Description("List of arguments passed to the script")]
        public IReadOnlyList<string> Args { get; set; } = [];

        [Description("Dictionary of user defined variables")]
        public IReadOnlyDictionary<string, string> UserVars => _contextStack.ArgumentVariables;

        [Description("Command context stack")]
        public CommandContextStack ContextStack => _contextStack;

        [Description("Current cache")]
        public GameCache Cache => _contextGlobals.Get<GameCache>(nameof(Cache));

        [Description("Current porting cache")]
        public GameCache PortingCache => _contextGlobals.Get<GameCache>(nameof(PortingCache));

        [Description("Current porting context")]
        public PortingContext PortingContext => _contextGlobals.Get<PortingContext>(nameof(PortingContext));

        [Description("Current tag being edited")]
        public CachedTag Tag => _contextGlobals.Get<CachedTag>(nameof(Tag));

        [Description("Current definition being edited")]
        public dynamic Definition => _contextGlobals.Get<dynamic>(nameof(Definition));

        [Description("Current block element being edited")]
        public dynamic Element => _contextGlobals.Get<dynamic>(nameof(Element));

        //
        // Methods
        //

        //[Description("Runs a tagtool command")]
        //public void RunCommand(string command)
        //{
        //    CommandRunner.Current.RunCommand(command);
        //}
    }
}
