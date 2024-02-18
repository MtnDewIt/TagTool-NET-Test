using System;
using TagTool.Audio;
using TagTool.Cache;
using TagTool.Tags;
using TagTool.Tags.Definitions;
using TagTool.Commands;
using TagTool.MtnDewIt.Porting;
using TagTool.Commands.Common;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache
{
    partial class GenerateEnhancedCacheCommand : Command
    {
        public void PortTagData()
        {
            InitializePortingContext();

            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\armory");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\chillout");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\construct");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\descent");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\docks");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\fortress");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\ghosttown");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\isolation");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\lockout");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\midship");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\s3d_lockout");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\s3d_powerhouse");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\s3d_sky_bridgenew");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\s3d_waterfall");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\salvation");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\sandbox");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\sidewinder");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\snowbound");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\spacecamp");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\warehouse");

            h3MainMenu.SetPortingProperties(audioCodec: Compression.OGG);
            h3MainMenu.PortTag($@"replace", $@"ui\halox\common\roster\roster_focused_ui.bitmap");
            h3MainMenu.PortTag($@"replace", $@"ui\halox\common\roster\exp_med_ui.bitmap");
            h3MainMenu.PortTag($@"", $@"levels\ui\mainmenu\objects\monitor_cheap\monitor_cheap.scenery");
            h3MainMenu.PortTag($@"", $@"levels\ui\mainmenu\objects\warthog_cheap\warthog_cheap.scenery");
            h3MainMenu.PortTag($@"", $@"levels\ui\mainmenu\objects\matchmaking_earth\matchmaking_earth.scenery");
            h3MainMenu.PortTag($@"", $@"levels\ui\mainmenu\lights\custom_games.light");
            h3MainMenu.PortTag($@"", $@"levels\ui\mainmenu\lights\editor.light");
            h3MainMenu.PortTag($@"", $@"levels\ui\mainmenu\objects\spartan_cheap\spartan_cheap.biped");

            DuplicateTag(GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x20x20"), $@"objects\eldewrito\reforge\block_01x20x20_black_mainmenu");
            DuplicateTag(GetCachedTag<Model>($@"objects\eldewrito\reforge\block_01x20x20"), $@"objects\eldewrito\reforge\block_01x20x20_black_mainmenu");
            DuplicateTag(GetCachedTag<RenderModel>($@"objects\eldewrito\reforge\block_01x20x20"), $@"objects\eldewrito\reforge\block_01x20x20_black_mainmenu");

            construct.SetPortingProperties(audioCodec: Compression.OGG);
            construct.PortTag($@"!ms30 !elites", $@"*.scnr");
            isolation.SetPortingProperties(audioCodec: Compression.OGG);
            isolation.PortTag($@"!ms30 !elites", $@"*.scnr");
            salvation.SetPortingProperties(audioCodec: Compression.OGG);
            salvation.PortTag($@"!ms30 !elites", $@"*.scnr");
            snowbound.SetPortingProperties(audioCodec: Compression.OGG);
            snowbound.PortTag($@"!ms30 !elites", $@"*.scnr");
            armory.SetPortingProperties(audioCodec: Compression.OGG);
            armory.PortTag($@"!ms30 !elites", $@"*.scnr");
            chillout.SetPortingProperties(audioCodec: Compression.OGG);
            chillout.PortTag($@"!ms30 !elites", $@"*.scnr");
            descent.SetPortingProperties(audioCodec: Compression.OGG);
            descent.PortTag($@"!ms30 !elites", $@"*.scnr");
            docks.SetPortingProperties(audioCodec: Compression.OGG);
            docks.PortTag($@"!ms30 !elites", $@"*.scnr");
            fortress.SetPortingProperties(audioCodec: Compression.OGG);
            fortress.PortTag($@"!ms30 !elites", $@"*.scnr");
            ghosttown.SetPortingProperties(audioCodec: Compression.OGG);
            ghosttown.PortTag($@"!ms30 !elites", $@"*.scnr");
            lockout.SetPortingProperties(audioCodec: Compression.OGG);
            lockout.PortTag($@"!ms30 !elites", $@"*.scnr"); 
            midship.SetPortingProperties(audioCodec: Compression.OGG);
            midship.PortTag($@"!ms30 !elites", $@"*.scnr");
            sandbox.SetPortingProperties(audioCodec: Compression.OGG);
            sandbox.PortTag($@"!ms30 !elites", $@"*.scnr");
            sidewinder.SetPortingProperties(audioCodec: Compression.OGG);
            sidewinder.PortTag($@"!ms30 !elites", $@"*.scnr");
            spacecamp.SetPortingProperties(audioCodec: Compression.OGG);
            spacecamp.PortTag($@"!ms30 !elites", $@"*.scnr");
            warehouse.SetPortingProperties(audioCodec: Compression.OGG);
            warehouse.PortTag($@"!ms30 !elites", $@"*.scnr");
            s3d_waterfall.SetPortingProperties(audioCodec: Compression.OGG);
            s3d_waterfall.PortTag($@"!ms30 !elites", $@"*.scnr");
            s3d_sky_bridgenew.SetPortingProperties(audioCodec: Compression.OGG);
            s3d_sky_bridgenew.PortTag($@"!ms30 !elites", $@"*.scnr");
            s3d_lockout.SetPortingProperties(audioCodec: Compression.OGG);
            s3d_lockout.PortTag($@"!ms30 !elites", $@"*.scnr");
            s3d_powerhouse.SetPortingProperties(audioCodec: Compression.OGG);
            s3d_powerhouse.PortTag($@"!ms30 !elites", $@"*.scnr");
        }

        public void InitializePortingContext()
        {
            h3MainMenu = new PortingContext(CacheContext, h3MainMenuCache);
            intro = new PortingContext(CacheContext, introCache);
            jungle = new PortingContext(CacheContext, jungleCache);
            crows = new PortingContext(CacheContext, crowsCache);
            outskirts = new PortingContext(CacheContext, outskirtsCache);
            voi = new PortingContext(CacheContext, voiCache);
            floodvoi = new PortingContext(CacheContext, floodvoiCache);
            waste = new PortingContext(CacheContext, wasteCache);
            citadel = new PortingContext(CacheContext, citadelCache);
            highCharity = new PortingContext(CacheContext, highCharityCache);
            halo = new PortingContext(CacheContext, haloCache);
            epilogue = new PortingContext(CacheContext, epilogueCache);

            mythicMainMenu = new PortingContext(CacheContext, mythicMainMenuCache);
            armory = new PortingContext(CacheContext, armoryCache);
            bunkerworld = new PortingContext(CacheContext, bunkerworldCache);
            chill = new PortingContext(CacheContext, chillCache);
            chillout = new PortingContext(CacheContext, chilloutCache);
            construct = new PortingContext(CacheContext, constructCache);
            cyberdyne = new PortingContext(CacheContext, cyberdyneCache);
            deadlock = new PortingContext(CacheContext, deadlockCache);
            descent = new PortingContext(CacheContext, descentCache);
            docks = new PortingContext(CacheContext, docksCache);
            fortress = new PortingContext(CacheContext, fortressCache);
            ghosttown = new PortingContext(CacheContext, ghosttownCache);
            guardian = new PortingContext(CacheContext, guardianCache);
            isolation = new PortingContext(CacheContext, isolationCache);
            lockout = new PortingContext(CacheContext, lockoutCache);
            midship = new PortingContext(CacheContext, midshipCache);
            riverworld = new PortingContext(CacheContext, riverworldCache);
            salvation = new PortingContext(CacheContext, salvationCache);
            sandbox = new PortingContext(CacheContext, sandboxCache);
            shrine = new PortingContext(CacheContext, shrineCache);
            sidewinder = new PortingContext(CacheContext, sidewinderCache);
            snowbound = new PortingContext(CacheContext, snowboundCache);
            spacecamp = new PortingContext(CacheContext, spacecampCache);
            warehouse = new PortingContext(CacheContext, warehouseCache);
            zanzibar = new PortingContext(CacheContext, zanzibarCache);

            odstMainMenu = new PortingContext(CacheContext, odstMainMenuCache);
            h100 = new PortingContext(CacheContext, h100Cache);
            c100 = new PortingContext(CacheContext, c100Cache);
            c200 = new PortingContext(CacheContext, c200Cache);
            l200 = new PortingContext(CacheContext, l200Cache);
            l300 = new PortingContext(CacheContext, l300Cache);
            sc100 = new PortingContext(CacheContext, sc100Cache);
            sc110 = new PortingContext(CacheContext, sc110Cache);
            sc120 = new PortingContext(CacheContext, sc120Cache);
            sc130 = new PortingContext(CacheContext, sc130Cache);
            sc140 = new PortingContext(CacheContext, sc140Cache);
            sc150 = new PortingContext(CacheContext, sc150Cache);

            s3d_waterfall = new PortingContext(CacheContext, s3d_waterfallCache);
            s3d_sky_bridgenew = new PortingContext(CacheContext, s3d_sky_bridgenewCache);
            s3d_lockout = new PortingContext(CacheContext, s3d_lockoutCache);
            s3d_powerhouse = new PortingContext(CacheContext, s3d_powerhouseCache);
        }

        //TODO: Figure out how to make all these functions use the same stream, and have it play nicely with the porting context

        public void GenerateTag<T>(string tagName) where T : TagStructure
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                var tag = Cache.TagCache.AllocateTag<T>(tagName);
                var definition = Activator.CreateInstance<T>();
                Cache.Serialize(stream, tag, definition);
            }
        }

        public void DuplicateTag(CachedTag tag, string newName)
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                var newTag = Cache.TagCache.AllocateTag(tag.Group, newName);
                var definition = Cache.Deserialize(stream, tag);
                Cache.Serialize(stream, newTag, definition);
                CacheContext.SaveTagNames();
            }
        }

        public void RenameTag(CachedTag currentTag, string newName)
        {
            currentTag.Name = newName;
            CacheContext.SaveTagNames();
        }

        public CachedTag GetCachedTag<T>(string tagName) where T : TagStructure
        {
            var tagAttribute = TagStructure.GetTagStructureAttribute(typeof(T), CacheContext.Version, CacheContext.Platform);
            var typeName = tagAttribute.Tag;

            if (CacheContext.TagCache.TryGetTag<T>(tagName, out var result))
            {
                return result;
            }
            else
            {
                new TagToolWarning($@"Could not find tag: '{tagName}.{typeName}'. Assigning null tag instead");
                return null;
            }
        }
    }
}