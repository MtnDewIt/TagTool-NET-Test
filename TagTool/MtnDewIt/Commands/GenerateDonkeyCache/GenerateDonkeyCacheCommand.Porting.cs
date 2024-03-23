using System;
using TagTool.Cache;
using TagTool.Commands;
using TagTool.MtnDewIt.Porting;
using TagTool.Tags;

namespace TagTool.MtnDewIt.Commands.GenerateDonkeyCache
{
    partial class GenerateDonkeyCacheCommand : Command
    {
        public void PortTagData() 
        {
            InitializePortingContext();
        }

        public void InitializePortingContext()
        {
            // These need to be defined after the new cache has been generated, otherwise it gets given the wrong cache context

            haloOnline = new PortingContext(CacheContext, haloOnlineCache, CacheStream);

            h3MainMenu = new PortingContext(CacheContext, h3MainMenuCache, CacheStream);
            intro = new PortingContext(CacheContext, introCache, CacheStream);
            jungle = new PortingContext(CacheContext, jungleCache, CacheStream);
            crows = new PortingContext(CacheContext, crowsCache, CacheStream);
            outskirts = new PortingContext(CacheContext, outskirtsCache, CacheStream);
            voi = new PortingContext(CacheContext, voiCache, CacheStream);
            floodvoi = new PortingContext(CacheContext, floodvoiCache, CacheStream);
            waste = new PortingContext(CacheContext, wasteCache, CacheStream);
            citadel = new PortingContext(CacheContext, citadelCache, CacheStream);
            highCharity = new PortingContext(CacheContext, highCharityCache, CacheStream);
            halo = new PortingContext(CacheContext, haloCache, CacheStream);
            epilogue = new PortingContext(CacheContext, epilogueCache, CacheStream);

            mythicMainMenu = new PortingContext(CacheContext, mythicMainMenuCache, CacheStream);
            armory = new PortingContext(CacheContext, armoryCache, CacheStream);
            bunkerworld = new PortingContext(CacheContext, bunkerworldCache, CacheStream);
            chill = new PortingContext(CacheContext, chillCache, CacheStream);
            chillout = new PortingContext(CacheContext, chilloutCache, CacheStream);
            construct = new PortingContext(CacheContext, constructCache, CacheStream);
            cyberdyne = new PortingContext(CacheContext, cyberdyneCache, CacheStream);
            deadlock = new PortingContext(CacheContext, deadlockCache, CacheStream);
            descent = new PortingContext(CacheContext, descentCache, CacheStream);
            docks = new PortingContext(CacheContext, docksCache, CacheStream);
            fortress = new PortingContext(CacheContext, fortressCache, CacheStream);
            ghosttown = new PortingContext(CacheContext, ghosttownCache, CacheStream);
            guardian = new PortingContext(CacheContext, guardianCache, CacheStream);
            isolation = new PortingContext(CacheContext, isolationCache, CacheStream);
            lockout = new PortingContext(CacheContext, lockoutCache, CacheStream);
            midship = new PortingContext(CacheContext, midshipCache, CacheStream);
            riverworld = new PortingContext(CacheContext, riverworldCache, CacheStream);
            salvation = new PortingContext(CacheContext, salvationCache, CacheStream);
            sandbox = new PortingContext(CacheContext, sandboxCache, CacheStream);
            shrine = new PortingContext(CacheContext, shrineCache, CacheStream);
            sidewinder = new PortingContext(CacheContext, sidewinderCache, CacheStream);
            snowbound = new PortingContext(CacheContext, snowboundCache, CacheStream);
            spacecamp = new PortingContext(CacheContext, spacecampCache, CacheStream);
            warehouse = new PortingContext(CacheContext, warehouseCache, CacheStream);
            zanzibar = new PortingContext(CacheContext, zanzibarCache, CacheStream);

            odstMainMenu = new PortingContext(CacheContext, odstMainMenuCache, CacheStream);
            h100 = new PortingContext(CacheContext, h100Cache, CacheStream);
            c100 = new PortingContext(CacheContext, c100Cache, CacheStream);
            c200 = new PortingContext(CacheContext, c200Cache, CacheStream);
            l200 = new PortingContext(CacheContext, l200Cache, CacheStream);
            l300 = new PortingContext(CacheContext, l300Cache, CacheStream);
            sc100 = new PortingContext(CacheContext, sc100Cache, CacheStream);
            sc110 = new PortingContext(CacheContext, sc110Cache, CacheStream);
            sc120 = new PortingContext(CacheContext, sc120Cache, CacheStream);
            sc130 = new PortingContext(CacheContext, sc130Cache, CacheStream);
            sc140 = new PortingContext(CacheContext, sc140Cache, CacheStream);
            sc150 = new PortingContext(CacheContext, sc150Cache, CacheStream);
        }

        public void UpdateData<T>() where T : Tags.TagFile
        {
            object[] args = { Cache, CacheContext, CacheStream };

            var tagData = Activator.CreateInstance(typeof(T), args);
        }

        public void GenerateTag<T>(string tagName) where T : TagStructure
        {
            var tag = CacheContext.TagCache.AllocateTag<T>(tagName);
            var definition = Activator.CreateInstance<T>();
            CacheContext.Serialize(CacheStream, tag, definition);
        }

        public void DuplicateTag(CachedTag tag, string newName)
        {
            var newTag = CacheContext.TagCache.AllocateTag(tag.Group, newName);
            var defintion = CacheContext.Deserialize(CacheStream, tag);
            CacheContext.Serialize(CacheStream, newTag, defintion);
            CacheContext.SaveTagNames();
        }

        public void RenameTag(CachedTag currentTag, string newName)
        {
            currentTag.Name = newName;
            CacheContext.SaveTagNames();
        }
    }
}