using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.JSON 
{
    public class ResourceParser 
    {
        public void UpdateResourceData(TagStructure tagDefinition, TagStructure tagObjectData) 
        {
            switch (tagDefinition, tagObjectData) 
            {
                case (Bitmap bitmDefinition, Bitmap bitmObjectData):
                    UpdateBitmapData(bitmDefinition, bitmObjectData);
                    break;

                case (ModelAnimationGraph jmadDefinition, ModelAnimationGraph jmadObjectData):
                    UpdateModelAnimationGraphData(jmadDefinition, jmadObjectData);
                    break;

                case (ParticleModel pmdfDefinition, ParticleModel pmdfObjectData):
                    UpdateParticleModelData(pmdfDefinition, pmdfObjectData);
                    break;

                case (RenderModel modeDefinition, RenderModel modeObjectData):
                    UpdateRenderModelData(modeDefinition, modeObjectData);
                    break;

                case (Scenario scnrDefinition, Scenario scnrObjectData):
                    UpdateScenarioData(scnrDefinition, scnrObjectData);
                    break;

                case (ScenarioLightmapBspData lbspDefinition, ScenarioLightmapBspData lbspObjectData):
                    UpdateLightmapBspData(lbspDefinition, lbspObjectData);
                    break;

                case (ScenarioStructureBsp sbspDefinition, ScenarioStructureBsp sbspObjectData):
                    UpdateStructureBspData(sbspDefinition, sbspObjectData);
                    break;

                case (Sound sndDefinition, Sound sndObjectData):
                    UpdateSoundData(sndDefinition, sndObjectData);
                    break;
            }
        }

        private void UpdateBitmapData(Bitmap bitmDefinition, Bitmap bitmObjectData) 
        {
            bitmObjectData.HardwareTextures = bitmDefinition.HardwareTextures;
            bitmObjectData.InterleavedHardwareTextures = bitmDefinition.InterleavedHardwareTextures;
        }

        private void UpdateModelAnimationGraphData(ModelAnimationGraph jmadDefinition, ModelAnimationGraph jmadObjectData) 
        {
            jmadObjectData.ResourceGroups = jmadDefinition.ResourceGroups;
        }

        private void UpdateParticleModelData(ParticleModel pmdfDefinition, ParticleModel pmdfObjectData) 
        {
            pmdfObjectData.Geometry = pmdfDefinition.Geometry;
        }

        private void UpdateRenderModelData(RenderModel modeDefinition, RenderModel modeObjectData) 
        {
            modeObjectData.Geometry = modeDefinition.Geometry;
        }

        private void UpdateScenarioData(Scenario scnrDefinition, Scenario scnrObjectData) 
        {
            scnrObjectData.ScriptStrings = scnrDefinition.ScriptStrings;
            scnrObjectData.Scripts = scnrDefinition.Scripts;
            scnrObjectData.Globals = scnrDefinition.Globals;
            scnrObjectData.ScriptSourceFileReferences = scnrDefinition.ScriptSourceFileReferences;
            scnrObjectData.ScriptExpressions = scnrDefinition.ScriptExpressions;
        }

        private void UpdateLightmapBspData(ScenarioLightmapBspData lbspDefinition, ScenarioLightmapBspData lbspObjectData) 
        {
            lbspObjectData.Geometry = lbspDefinition.Geometry;
        }

        private void UpdateStructureBspData(ScenarioStructureBsp sbspDefinition, ScenarioStructureBsp sbspObjectData) 
        {
            sbspObjectData.DecoratorGeometry = sbspDefinition.DecoratorGeometry;
            sbspObjectData.Geometry = sbspDefinition.Geometry;
            sbspObjectData.CollisionBsp = sbspDefinition.CollisionBsp;
            sbspObjectData.PathfindingResource = sbspDefinition.PathfindingResource;
        }

        private void UpdateSoundData(Sound sndDefinition, Sound sndObjectData) 
        {
            sndObjectData.Resource = sndDefinition.Resource;
        }
    }
}