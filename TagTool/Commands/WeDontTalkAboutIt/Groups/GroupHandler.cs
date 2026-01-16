using Assimp;
using System;
using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Cache.Gen3;
using TagTool.Cache.HaloOnline;
using TagTool.Commands.Zeus;
using TagTool.Common;

namespace TagTool.Commands.WeDontTalkAboutIt.Groups
{
    public class GroupHandler
    {
        public static List<TagGroupGen3> GetTagGroups(ZeusVersion build) 
        {
            GameCache cache;

            switch (build) 
            {
                case ZeusVersion.Halo3Xenon:
                    cache = GameCache.Open(Halo3Xenon.CachePath);
                    return (cache as GameCacheGen3).TagCacheGen3.Groups;
                case ZeusVersion.Halo3ODSTXenon:
                    cache = GameCache.Open(Halo3ODSTXenon.CachePath);
                    return (cache as GameCacheGen3).TagCacheGen3.Groups;
                case ZeusVersion.Halo3Ares:
                    cache = GameCache.Open(Halo3Ares.CachePath);
                    return (cache as GameCacheGen3).TagCacheGen3.Groups;
                case ZeusVersion.Halo3Latest:
                    cache = GameCache.Open(Halo3Latest.CachePath);
                    return (cache as GameCacheGen3).TagCacheGen3.Groups;
                case ZeusVersion.Halo3ODSTLatest:
                    cache = GameCache.Open(Halo3ODSTLatest.CachePath);
                    return (cache as GameCacheGen3).TagCacheGen3.Groups;
                case ZeusVersion.HaloOnlineMS23:
                    cache = GameCache.Open(HaloOnlineMS23.CachePath);
                    List<TagGroupGen3> groups = [];
                    foreach (var pair in HaloOnlineMS23.HaloOnlineMS23Groups) 
                    {
                        var tagGroup = (cache as GameCacheHaloOnline).TagCacheGenHO.TagDefinitions.GetTagGroupFromTag(pair.Key);

                        if (tagGroup != null) 
                        {
                            groups.Add(new TagGroupGen3
                            {
                                Name = pair.Value,
                                Tag = tagGroup.Tag,
                                ParentTag = tagGroup.ParentTag,
                                GrandParentTag = tagGroup.GrandParentTag,
                            });
                        }
                        else 
                        {
                            groups.Add(new TagGroupGen3
                            {
                                Name = pair.Value,
                                Tag = pair.Key,
                            });
                        }
                    }
                    return groups;
                default:
                    return null;
            }
        }

        public static Dictionary<Tag, string> GetGroups(ZeusVersion build) 
        {
            return build switch
            {
                ZeusVersion.Halo3Xenon => Halo3Xenon.Halo3XenonGroups,
                ZeusVersion.Halo3ODSTXenon => Halo3ODSTXenon.Halo3ODSTXenonGroups,
                ZeusVersion.Halo3Ares => Halo3Ares.Halo3AresGroups,
                ZeusVersion.Halo3Latest => Halo3Latest.Halo3LatestGroups,
                ZeusVersion.Halo3ODSTLatest => Halo3ODSTLatest.Halo3ODSTLatestGroups,
                ZeusVersion.HaloOnlineMS23 => HaloOnlineMS23.HaloOnlineMS23Groups,
                _ => null,
            };
        }

        public static Type GetType(ZeusVersion build, string tag) 
        {
            GameCache cache;

            switch (build) 
            {
                case ZeusVersion.Halo3Xenon:
                    cache = GameCache.Open(Halo3Xenon.CachePath);
                    return (cache as GameCacheGen3).TagCacheGen3.TagDefinitions.GetTagDefinitionType(tag);
                case ZeusVersion.Halo3ODSTXenon:
                    cache = GameCache.Open(Halo3ODSTXenon.CachePath);
                    return (cache as GameCacheGen3).TagCacheGen3.TagDefinitions.GetTagDefinitionType(tag);
                case ZeusVersion.Halo3Ares:
                    cache = GameCache.Open(Halo3Ares.CachePath);
                    return (cache as GameCacheGen3).TagCacheGen3.TagDefinitions.GetTagDefinitionType(tag);
                case ZeusVersion.Halo3Latest:
                    cache = GameCache.Open(Halo3Latest.CachePath);
                    return (cache as GameCacheGen3).TagCacheGen3.TagDefinitions.GetTagDefinitionType(tag);
                case ZeusVersion.Halo3ODSTLatest:
                    cache = GameCache.Open(Halo3ODSTLatest.CachePath);
                    return (cache as GameCacheGen3).TagCacheGen3.TagDefinitions.GetTagDefinitionType(tag);
                case ZeusVersion.HaloOnlineMS23:
                    cache = GameCache.Open(HaloOnlineMS23.CachePath);
                    return (cache as GameCacheHaloOnline).TagCacheGenHO.TagDefinitions.GetTagDefinitionType(tag);
                default:
                    return null;
            }
        }
    }
}
