using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_characters_masterchief_mp_masterchief_action_camera_camera_track : TagFile
    {
        public objects_characters_masterchief_mp_masterchief_action_camera_camera_track(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<CameraTrack>($@"objects\characters\masterchief\mp_masterchief\action_camera");
            var trak = CacheContext.Deserialize<CameraTrack>(Stream, tag);
            trak.ControlPoints = new List<CameraTrack.CameraPoint>
            {
                new CameraTrack.CameraPoint
                {
                    Position = new RealVector3d(3.934E-08f, 0f, 0.9f),
                    Orientation = new RealQuaternion(0f, -0.7071069f, 0f, -0.7071068f),
                },
                new CameraTrack.CameraPoint
                {
                    Position = new RealVector3d(-0.1732779f, 0f, 0.9380214f),
                    Orientation = new RealQuaternion(0f, -0.6234899f, 0f, -0.7818315f),
                },
                new CameraTrack.CameraPoint
                {
                    Position = new RealVector3d(-0.3668045f, 0f, 0.9310074f),
                    Orientation = new RealQuaternion(0f, -0.5320321f, 0f, -0.8467242f),
                },
                new CameraTrack.CameraPoint
                {
                    Position = new RealVector3d(-0.5661401f, 0f, 0.8719415f),
                    Orientation = new RealQuaternion(0f, -0.4338837f, 0f, -0.9009689f),
                },
                new CameraTrack.CameraPoint
                {
                    Position = new RealVector3d(-0.7549486f, 0f, 0.7586696f),
                    Orientation = new RealQuaternion(0f, -0.3302791f, 0f, -0.9438834f),
                },
                new CameraTrack.CameraPoint
                {
                    Position = new RealVector3d(-0.9165863f, 0f, 0.5943015f),
                    Orientation = new RealQuaternion(0f, -0.222521f, 0f, -0.9749279f),
                },
                new CameraTrack.CameraPoint
                {
                    Position = new RealVector3d(-1.035744f, 0f, 0.3871195f),
                    Orientation = new RealQuaternion(0f, -0.1119645f, 0f, -0.9937123f),
                },
                new CameraTrack.CameraPoint
                {
                    Position = new RealVector3d(-1.1f, 0f, 0.1500001f),
                    Orientation = new RealQuaternion(0f, -5.96E-08f, 0f, -1f),
                },
                new CameraTrack.CameraPoint
                {
                    Position = new RealVector3d(-1.083231f, 0f, -0.09652288f),
                    Orientation = new RealQuaternion(0f, 0.1119645f, 0f, -0.9937123f),
                },
                new CameraTrack.CameraPoint
                {
                    Position = new RealVector3d(-0.9699321f, 0f, -0.3141978f),
                    Orientation = new RealQuaternion(0f, 0.2225208f, 0f, -0.974928f),
                },
                new CameraTrack.CameraPoint
                {
                    Position = new RealVector3d(-0.7783985f, 0f, -0.4641338f),
                    Orientation = new RealQuaternion(0f, 0.330279f, 0f, -0.9438834f),
                },
                new CameraTrack.CameraPoint
                {
                    Position = new RealVector3d(-0.5408726f, 0f, -0.5162081f),
                    Orientation = new RealQuaternion(0f, 0.4338836f, 0f, -0.900969f),
                },
                new CameraTrack.CameraPoint
                {
                    Position = new RealVector3d(-0.2999597f, 0f, -0.4535427f),
                    Orientation = new RealQuaternion(0f, 0.532032f, 0f, -0.8467243f),
                },
                new CameraTrack.CameraPoint
                {
                    Position = new RealVector3d(-0.103738f, 0f, -0.2756643f),
                    Orientation = new RealQuaternion(0f, 0.6234898f, 0f, -0.7818316f),
                },
                new CameraTrack.CameraPoint
                {
                    Position = new RealVector3d(0f, 0f, 1.9073E-08f),
                    Orientation = new RealQuaternion(0f, 0.7071067f, 0f, -0.7071069f),
                },
            };
            CacheContext.Serialize(Stream, tag, trak);
        }
    }
}
