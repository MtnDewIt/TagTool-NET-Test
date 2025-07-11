using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags.Definitions;
using System;
using System.Collections.Generic;
using TagTool.Porting;

namespace TagTool.Commands.Porting
{
    public class PortMultiplayerEventsCommand : Command
    {
        private GameCacheHaloOnlineBase HoCache { get; }
        private GameCache BlamCache;

        public PortMultiplayerEventsCommand(GameCacheHaloOnlineBase cache, GameCache blamCache) :
            base(true,

                "PortMultiplayerEvents",
                "Ports events from multiplayer_globals.",

                "PortMultiplayerEvents",
                "Ports events from multiplayer_globals.")
        {
            HoCache = cache;
            BlamCache = blamCache;
        }

        private void CopyEvents(List<MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock> events1, List<MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock> events2)
        {
            for (var i = 0; i < events1.Count; i++)
            {
                var e1 = events1[i];
                var e2 = events2.Find(item => item.DisplayString == e1.DisplayString);

                if (e2 == null)
                    continue;

                e1.EnglishSound = e2.EnglishSound;
                e1.JapaneseSound = e2.JapaneseSound;
                e1.GermanSound = e2.GermanSound;
                e1.FrenchSound = e2.FrenchSound;
                e1.SpanishSound = e2.SpanishSound;
                e1.LatinAmericanSpanishSound = e2.LatinAmericanSpanishSound;
                e1.ItalianSound = e2.ItalianSound;
                e1.KoreanSound = e2.KoreanSound;
                e1.ChineseTraditionalSound = e2.ChineseTraditionalSound;
                e1.ChineseSimplifiedSound = e2.ChineseSimplifiedSound;
                e1.PortugueseSound = e2.PortugueseSound;
                e1.PolishSound = e2.PolishSound;
            }
        }

        public override object Execute(List<string> args)
        {
            if (args.Count != 0)
                return new TagToolError(CommandError.ArgCount);

            MultiplayerGlobals oldMulgDefinition;

            using (var stream = HoCache.OpenCacheRead())
            {
                if (!HoCache.TagCache.TryGetTag<MultiplayerGlobals>(@"multiplayer\multiplayer_globals", out var edTag))
                    return new TagToolError(CommandError.TagInvalid, "ElDorado multiplayer_globals tag does not exist");

                oldMulgDefinition = HoCache.Deserialize<MultiplayerGlobals>(stream, edTag);
            }

            using var portingContext = PortingContext.Create(HoCache, BlamCache);
            new PortTagCommand(HoCache, BlamCache, portingContext).Execute(new List<string> { "replace", "mulg", @"multiplayer\multiplayer_globals" });

            using (var stream = HoCache.OpenCacheReadWrite())
            {
                if (!HoCache.TagCache.TryGetTag<MultiplayerGlobals>(@"multiplayer\multiplayer_globals", out var edTag))
                    return new TagToolError(CommandError.TagInvalid, "ElDorado multiplayer_globals tag does not exist");

                var mulgDefinition = HoCache.Deserialize<MultiplayerGlobals>(stream, edTag);

                CopyEvents(oldMulgDefinition.Runtime[0].GeneralEvents, mulgDefinition.Runtime[0].GeneralEvents);
                CopyEvents(oldMulgDefinition.Runtime[0].FlavorEvents, mulgDefinition.Runtime[0].FlavorEvents);
                CopyEvents(oldMulgDefinition.Runtime[0].SlayerEvents, mulgDefinition.Runtime[0].SlayerEvents);
                CopyEvents(oldMulgDefinition.Runtime[0].CtfEvents, mulgDefinition.Runtime[0].CtfEvents);
                CopyEvents(oldMulgDefinition.Runtime[0].OddballEvents, mulgDefinition.Runtime[0].OddballEvents);
                CopyEvents(oldMulgDefinition.Runtime[0].KingOfTheHillEvents, mulgDefinition.Runtime[0].KingOfTheHillEvents);
                CopyEvents(oldMulgDefinition.Runtime[0].VipEvents, mulgDefinition.Runtime[0].VipEvents);
                CopyEvents(oldMulgDefinition.Runtime[0].JuggernautEvents, mulgDefinition.Runtime[0].JuggernautEvents);
                CopyEvents(oldMulgDefinition.Runtime[0].TerritoriesEvents, mulgDefinition.Runtime[0].TerritoriesEvents);
                CopyEvents(oldMulgDefinition.Runtime[0].AssaultEvents, mulgDefinition.Runtime[0].AssaultEvents);
                CopyEvents(oldMulgDefinition.Runtime[0].InfectionEvents, mulgDefinition.Runtime[0].InfectionEvents);

                HoCache.Serialize(stream, edTag, oldMulgDefinition);
            }

            return true;
        }
    }
}

