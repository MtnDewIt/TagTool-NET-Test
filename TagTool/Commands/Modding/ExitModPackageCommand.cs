using TagTool.Cache;
using System.Collections.Generic;
using System;
using TagTool.Commands.Common;
using TagTool.Commands.Tags;
using System.IO;
using System.ComponentModel.Design.Serialization;

namespace TagTool.Commands.Modding
{
    public class ExitModPackageCommand : Command
    {
        public CommandContextStack ContextStack { get; }
        public GameCacheModPackage ModCache;

        public ExitModPackageCommand(CommandContextStack contextStack, GameCacheModPackage cache) :
            base(true,

                "ExitModPackage",
                "Exits the current mod package context.",

                "ExitModPackage",

                "Exits the current mod package context.")
        {
            ContextStack = contextStack;
            ModCache = cache;
        }

        public override object Execute(List<string> args) 
        {
            if (ContextStack.IsModPackage())
            {
                ModCache.BaseModPackage.Dispose();
                ContextStack.Pop();
            }
            else 
            {
                new TagToolWarning("Use 'exit' to leave standard contexts.");
            }

            return true;
        }
    }
}
