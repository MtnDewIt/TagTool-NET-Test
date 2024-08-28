using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.JSON 
{
    public class ResourceParser 
    {
        public void UpdateResourceData(TagStructure tagDefinition, TagStructure tagObjectData) 
        {
            // Tag Resource References:
            // List<TagResourceReference> HardwareTextures
            // List<TagResourceReference> InterleavedHardwareTextures

            if (tagDefinition is Bitmap && tagObjectData is Bitmap) 
            {
                var bitmDefinition = tagDefinition as Bitmap;
                var bitmObjectData = tagObjectData as Bitmap;
            }

            // Tag Resource Groups:
            // List<ResourceGroup> ResourceGroups

            if (tagDefinition is ModelAnimationGraph && tagObjectData is ModelAnimationGraph)
            {
                var jmadDefinition = tagDefinition as ModelAnimationGraph;
                var jmadObjectData = tagObjectData as ModelAnimationGraph;
            }

            // Tag Geometry References:
            // RenderGeometry Geometry

            if (tagDefinition is ParticleModel && tagObjectData is ParticleModel)
            {
                var pmdfDefinition = tagDefinition as ParticleModel;
                var pmdfObjectData = tagObjectData as ParticleModel;
            }

            // Tag Geometry References:
            // RenderGeometry Geometry

            if (tagDefinition is RenderModel && tagObjectData is RenderModel) 
            {
                var modeDefinition = tagDefinition as RenderModel;
                var modeObjectData = tagObjectData as RenderModel;
            }

            // Questionable as technically the script data is stored in the hsc file, and is generated when the tag data gets serialized
            // This would probably only be required if the scenario tag object doesn't contain a script file reference :/
            // byte[] ScriptStrings
            // List<HsScript> Scripts
            // List<HsGlobal> Globals
            // List<TagReferenceBlock> ScriptSourceFileReferences
            // List<HsSyntaxNode> ScriptExpressions

            if (tagDefinition is Scenario && tagObjectData is Scenario)
            {
                var scnrDefinition = tagDefinition as Scenario;
                var scnrObjectData = tagObjectData as Scenario;
            }

            // Tag Geometry References:
            // RenderGeometry Geometry

            if (tagDefinition is ScenarioLightmapBspData && tagObjectData is ScenarioLightmapBspData)
            {
                var lbspDefinition = tagDefinition as ScenarioLightmapBspData;
                var lbspObjectData = tagObjectData as ScenarioLightmapBspData;
            }

            // Tag Resource and Geometry References:
            // RenderGeometry DecoratorGeometry
            // RenderGeometry Geometry
            // TagResourceReference CollisionBspResource
            // TagResourceReference PathfindingResource

            if (tagDefinition is ScenarioStructureBsp && tagObjectData is ScenarioStructureBsp)
            {
                var sbspDefinition = tagDefinition as ScenarioStructureBsp;
                var sbspObjectData = tagObjectData as ScenarioStructureBsp;
            }

            // Tag Resource References:
            //TagResourceReference Resource

            if (tagDefinition is Sound && tagObjectData is Sound)
            {
                var sndDefinition = tagDefinition as Sound;
                var sndObjectData = tagObjectData as Sound;
            }
        }
    }
}