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
