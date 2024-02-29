using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
{
    public class ui_chud_globals_chud_globals_definition : TagFile
    {
        public ui_chud_globals_chud_globals_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
        (
            cache,
            cacheContext,
            stream
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
            TagData();
        }

        public override void TagData()
        {
            var tag = GetCachedTag<ChudGlobalsDefinition>($@"ui\chud\globals");
            var chgd = CacheContext.Deserialize<ChudGlobalsDefinition>(Stream, tag);
            chgd.HudGlobals[0].NavpointFriendly = new ArgbColor(0, 0, 255, 9);
            chgd.HudGlobals[0].NavpointAllyBlue = new ArgbColor(0, 0, 96, 255);
            chgd.HudGlobals[0].HudAttributes[0].ResolutionFlags |= ChudGlobalsDefinition.HudGlobal.HudAttribute.ResolutionFlagValue.StandardFull;
            chgd.HudGlobals[0].HudAttributes[0].StateLeftRightOffset_HO = new RealPoint2d(0f, 0.16f);
            chgd.HudGlobals[0].HudAttributes[0].SurvivalMedalsOffset = new RealPoint2d(0f, 0.64f);
            chgd.HudGlobals[0].HudAttributes[0].Unknown32 = 1;
            chgd.HudGlobals[0].HudAttributes[0].StateMessageScale = 1.5f;
            chgd.HudGlobals[0].HudAttributes[0].MessageScale = 1.5f;
            chgd.HudGlobals[0].DirectionalArrowScale = 50f;
            chgd.HudGlobals[0].ScoreboardSpacingSize = 37;
            chgd.HudGlobals[1].HudAttributes[0].ResolutionFlags |= ChudGlobalsDefinition.HudGlobal.HudAttribute.ResolutionFlagValue.StandardFull;
            chgd.HudGlobals[1].HudAttributes[0].StateLeftRightOffset_HO = new RealPoint2d(0f, 0.16f);
            chgd.HudGlobals[1].HudAttributes[0].SurvivalMedalsOffset = new RealPoint2d(0f, 0.64f);
            chgd.HudGlobals[1].HudAttributes[0].Unknown32 = 1;
            chgd.HudGlobals[1].HudAttributes[0].StateMessageScale = 1.5f;
            chgd.HudGlobals[1].HudAttributes[0].MessageScale = 1.5f;
            chgd.HudGlobals[1].DirectionalArrowScale = 50f;
            chgd.HudGlobals[1].ScoreboardSpacingSize = 37f;
            chgd.HudGlobals[1].GrenadeSchematicsOffset = new RealPoint2d(0f, 0.003f);
            chgd.HudGlobals[2].PrimaryBackground = new ArgbColor(0, 3, 28, 56);
            chgd.HudGlobals[2].SecondaryBackground = new ArgbColor(0, 36, 139, 255);
            chgd.HudGlobals[2].HighlightForeground = new ArgbColor(0, 93, 169, 255);
            chgd.HudGlobals[2].CrosshairNormal = new ArgbColor(0, 55, 149, 255);
            chgd.HudGlobals[2].NavpointFriendly = new ArgbColor(0, 0, 255, 9);
            chgd.HudGlobals[2].NavpointAllyBlue = new ArgbColor(0, 0, 96, 255);
            chgd.HudGlobals[2].HudAttributes[0].ResolutionFlags |= ChudGlobalsDefinition.HudGlobal.HudAttribute.ResolutionFlagValue.StandardFull;
            chgd.HudGlobals[2].HudAttributes[0].StateLeftRightOffset_HO = new RealPoint2d(0f, 0.16f);
            chgd.HudGlobals[2].HudAttributes[0].SurvivalMedalsOffset = new RealPoint2d(0f, 0.64f);
            chgd.HudGlobals[2].HudAttributes[0].Unknown32 = 1;
            chgd.HudGlobals[2].HudAttributes[0].StateMessageScale = 1.5f;
            chgd.HudGlobals[2].HudAttributes[0].MessageScale = 1.5f;
            chgd.HudGlobals[2].DirectionalArrowScale = 50f;
            chgd.HudGlobals[2].ScoreboardSpacingSize = 37f;
            chgd.MotionSensorLevelHeightRange = 1.8f;
            chgd.ShieldMajorThreshold = 0.5f;
            chgd.ShieldCriticalThreshold = 0.25f;
            chgd.HealthMultiplyColor1 = new RealRgbColor(0, 0, 0);
            chgd.ShieldMultiplyColor0 = new RealRgbColor(1, 1, 1);
            chgd.ShieldMultiplyColor1 = new RealRgbColor(-0.362636f, -0.840421f, -0.857739f);
            chgd.ShieldMultiplyColor1Alpha = 0.5f;
            chgd.ShieldAdditiveColor1 = new RealRgbColor(0.121569f, 0.00984327f, 0.0071511f);
            chgd.ShieldAdditiveColor1Alpha = 0.5f;
            CacheContext.Serialize(Stream, tag, chgd);
        }
    }
}
