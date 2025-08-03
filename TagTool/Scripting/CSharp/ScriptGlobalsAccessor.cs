using TagTool.Commands;

namespace TagTool.Scripting.CSharp
{
    public class ScriptGlobalsAccessor
    {
        private CommandContextStack _contextStack;

        public ScriptGlobalsAccessor(CommandContextStack contextStack)
        {
            _contextStack = contextStack;
        }

        public T Get<T>(string key, T defaultVal = default)
        {
            // walk up the context stack trying to find the global for given key
            var context = _contextStack.Context;
            while (context != null)
            {
                if (context.ScriptGlobals.TryGetValue(key, out var val))
                    return (T)val;
                context = context.Parent;
            }
            return defaultVal;
        }
    }
}
