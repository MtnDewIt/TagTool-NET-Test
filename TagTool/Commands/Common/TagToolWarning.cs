using TagTool.Common.Logging;

namespace TagTool.Commands.Common
{
    /// <remarks>
    /// Prefer using <see cref="Log.Warning(string)"/> directly when outside of commands
    /// </remarks>
    public class TagToolWarning
    {
        public TagToolWarning(string customMessage = null)
        {
            Log.Warning(customMessage);
        }
    }
}
