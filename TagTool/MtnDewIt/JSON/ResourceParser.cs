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
            // Tag Resource References:
            // List<TagResourceReference> HardwareTextures
            // List<TagResourceReference> InterleavedHardwareTextures
        }

        private void UpdateModelAnimationGraphData(ModelAnimationGraph jmadDefinition, ModelAnimationGraph jmadObjectData) 
        {
            // Tag Resource Groups:
            // List<ResourceGroup> ResourceGroups
        }

        private void UpdateParticleModelData(ParticleModel pmdfDefinition, ParticleModel pmdfObjectData) 
        {
            // Tag Geometry References:
            // RenderGeometry Geometry
        }

        private void UpdateRenderModelData(RenderModel modeDefinition, RenderModel modeObjectData) 
        {
            // Tag Geometry References:
            // RenderGeometry Geometry
        }

        private void UpdateScenarioData(Scenario scnrDefinition, Scenario scnrObjectData) 
        {
            // Questionable as technically the script data is stored in the hsc file, and is generated when the tag data gets serialized
            // This would probably only be required if the scenario tag object doesn't contain a script file reference :/
            // byte[] ScriptStrings
            // List<HsScript> Scripts
            // List<HsGlobal> Globals
            // List<TagReferenceBlock> ScriptSourceFileReferences
            // List<HsSyntaxNode> ScriptExpressions
        }

        private void UpdateLightmapBspData(ScenarioLightmapBspData lbspDefinition, ScenarioLightmapBspData lbspObjectData) 
        {
            // Tag Geometry References:
            // RenderGeometry Geometry
        }

        private void UpdateStructureBspData(ScenarioStructureBsp sbspDefinition, ScenarioStructureBsp sbspObjectData) 
        {
            // Tag Resource and Geometry References:
            // RenderGeometry DecoratorGeometry
            // RenderGeometry Geometry
            // TagResourceReference CollisionBspResource
            // TagResourceReference PathfindingResource
        }

        private void UpdateSoundData(Sound sndDefinition, Sound sndObjectData) 
        {
            // Tag Resource References:
            // TagResourceReference Resource
        }
    }
}