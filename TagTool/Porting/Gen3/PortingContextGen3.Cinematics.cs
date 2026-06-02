using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagTool.Cache;
using TagTool.Tags.Definitions;

namespace TagTool.Porting.Gen3
{
    public partial class PortingContextGen3
    {
        private CinematicScene ConvertCinematicScene(CinematicScene cisc)
        {
            if (BlamCache.Version == CacheVersion.Halo3Retail) 
            {
                foreach (var cinematicObject in cisc.Objects)
                {
                    // #TODO: We need to handle cases where the biped names don't match exactly (Only relevant in cases where we have custom bipeds and custom cutscenes)
                    if (cinematicObject.PuppetObject != null && !cinematicObject.ImportName.StartsWith("player"))
                    {
                        if (cinematicObject.PuppetObject.Name.Equals("objects\\characters\\masterchief\\masterchief"))
                        {
                            cinematicObject.Flags |= CinematicScene.ObjectBlock.ObjectFlags.UsePlayer1Appearance;
                        }

                        if (cinematicObject.PuppetObject.Name.Equals("objects\\characters\\dervish\\dervish"))
                        {
                            cinematicObject.Flags |= CinematicScene.ObjectBlock.ObjectFlags.UsePlayer2Appearance;
                        }
                    }
                }
            }

            if (BlamCache.Version == CacheVersion.Halo3ODST)
            {
                foreach (var shot in cisc.Shots)
                {
                    foreach (var frame in shot.CameraFrames)
                    {
                        frame.FocalLength *= 0.65535f; // fov change in ODST affected cisc too it seems
                    }
                }
            }
            return cisc;
        }
    }
}
