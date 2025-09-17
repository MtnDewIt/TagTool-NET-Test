using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Porting;

namespace TagTool.Commands.Porting
{
    class IgnoreBlamTagCommand : Command
    {
        private readonly PortingContext PortContext;

        public IgnoreBlamTagCommand(PortingContext portContext)
               : base(true,

                     "IgnoreBlamTag",
                     "Prevents the specified tags from being ported when porting tags.",

                     "IgnoreBlamTag <tag name> | regex: <pattern>",

                     "Prevents the specified tags from being ported.\n" +
                     "")
        {
            PortContext = portContext;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count < 1)
                return new TagToolError(CommandError.ArgCount);

            switch (args[0].ToLower())
            {
                case "regex:":
                    {
                        if (args.Count < 2)
                            return new TagToolError(CommandError.ArgCount);

                        Regex regex;
                        try
                        {
                            regex = new Regex(args[1]);
                        }
                        catch (Exception ex)
                        {
                            return new TagToolError(CommandError.ArgInvalid, ex.Message);
                        }

                        foreach (CachedTag tag in PortContext.BlamCache.TagCache.TagTable)
                        {
                            if (tag != null && regex.IsMatch(tag.ToString()))
                                PortContext.IgnoreBlamTags.Add(tag.Index);
                        }
                    }
                    break;
                default:
                    {
                        if (!PortContext.BlamCache.TagCache.TryGetCachedTag(args[0], out CachedTag tagInstance))
                            return new TagToolError(CommandError.TagInvalid);

                        PortContext.IgnoreBlamTags.Add(tagInstance.Index);
                    }
                    break;
            }

            return true;
        }
    }
}
