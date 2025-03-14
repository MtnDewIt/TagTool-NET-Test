using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Models
{
    public class UpdateModelRegionsCommand : Command
    {
        private GameCache CacheContext { get; }
        private Model ModelTag { get; }
        private CachedTag ModelTagDefinition { get; }

        public UpdateModelRegionsCommand(GameCache cacheContext, Model model, CachedTag modelTag)
            : base(false,
                   "UpdateModelRegions",
                   "Updates collision regions (and variant regions, if specified) based on the linked render_model. " +
                   "Collision regions preserve existing indices; new regions get indices -1. " +
                   "Permutation lists are synchronized to match the render_model.",
                   "UpdateModelRegions [variant_index ...] [random]",
                   "Updates the collision regions and, optionally, specified variant regions and permutations to match the linked render_model.")
        {
            CacheContext = cacheContext;
            ModelTag = model;
            ModelTagDefinition = modelTag;
        }

        public override object Execute(List<string> args)
        {
            // Parse variant indices and random flag from the command arguments.
            List<int> variantIndices = new List<int>();
            bool randomFlag = false;
            foreach (string arg in args)
            {
                if (int.TryParse(arg, out int idx))
                    variantIndices.Add(idx);
                else if (arg.Equals("random", StringComparison.OrdinalIgnoreCase))
                    randomFlag = true;
            }

            // Deserialize the linked render_model.
            RenderModel renderModel;
            using (Stream rmStream = CacheContext.OpenCacheRead())
            {
                renderModel = CacheContext.Deserialize<RenderModel>(rmStream, ModelTag.RenderModel);
            }
            if (renderModel == null || renderModel.Regions == null)
            {
                Console.WriteLine("Render model or its regions not found.");
                return false;
            }

            // ================================
            // Update Collision Regions & Permutations
            // ================================
            // Only consider render_model regions with valid names.
            List<RenderModel.Region> validRenderRegions = renderModel.Regions
                .Where(r => r.Name != StringId.Invalid)
                .ToList();

            // Build a lookup of existing collision regions by name.
            Dictionary<StringId, Model.CollisionRegion> existingCollision = new Dictionary<StringId, Model.CollisionRegion>();
            if (ModelTag.CollisionRegions != null)
            {
                foreach (var col in ModelTag.CollisionRegions)
                {
                    if (col.Name != StringId.Invalid)
                        existingCollision[col.Name] = col;
                }
            }
            else
            {
                ModelTag.CollisionRegions = new List<Model.CollisionRegion>();
            }

            // Create a new list for updated collision regions.
            List<Model.CollisionRegion> updatedCollisionRegions = new List<Model.CollisionRegion>();

            // Process each valid render_model region.
            foreach (var rmRegion in validRenderRegions)
            {
                // Check if a collision region with the same name already exists.
                Model.CollisionRegion modelRegion;
                bool exists = existingCollision.TryGetValue(rmRegion.Name, out modelRegion);
                if (!exists)
                {
                    // New collision region.
                    modelRegion = new Model.CollisionRegion
                    {
                        Name = rmRegion.Name,
                        CollisionRegionIndex = -1,
                        PhysicsRegionIndex = -1,
                        Permutations = new List<Model.CollisionRegion.Permutation>()
                    };
                }
                // (If exists, its CollisionRegionIndex/PhysicsRegionIndex remain as they were if not -1.)

                // Process collision region permutations:
                // Build a list of valid render_model permutations (ignoring those with invalid names).
                List<RenderModel.Region.Permutation> validRmPerms = (rmRegion.Permutations != null)
                    ? rmRegion.Permutations.Where(p => p.Name != StringId.Invalid).ToList()
                    : new List<RenderModel.Region.Permutation>();
                int targetPermCount = validRmPerms.Count;

                // Ensure model region permutation list exists.
                if (modelRegion.Permutations == null)
                    modelRegion.Permutations = new List<Model.CollisionRegion.Permutation>();

                // Remove any model permutation with an invalid name.
                modelRegion.Permutations.RemoveAll(p => p.Name == StringId.Invalid);

                bool hasExistingPermData = modelRegion.Permutations.Count > 0;

                // If there are fewer permutations than in render_model, add new ones.
                while (modelRegion.Permutations.Count < targetPermCount)
                {
                    Model.CollisionRegion.Permutation newPerm;
                    if (hasExistingPermData)
                    {
                        // Clone the first existing permutation (to copy its saved index values).
                        newPerm = CloneCollisionPermutation(modelRegion.Permutations[0]);
                        newPerm.Name = validRmPerms[modelRegion.Permutations.Count].Name;
                    }
                    else
                    {
                        // New permutation: indices set to -1.
                        newPerm = new Model.CollisionRegion.Permutation
                        {
                            Name = validRmPerms[modelRegion.Permutations.Count].Name,
                            CollisionPermutationIndex = -1,
                            PhysicsPermutationIndex = -1
                        };
                    }
                    modelRegion.Permutations.Add(newPerm);
                }
                // If there are too many, trim the extra ones.
                while (modelRegion.Permutations.Count > targetPermCount)
                {
                    modelRegion.Permutations.RemoveAt(modelRegion.Permutations.Count - 1);
                }
                // Update permutation indices and names.
                for (int i = 0; i < targetPermCount; i++)
                {
                    var rmPerm = validRmPerms[i];
                    var modelPerm = modelRegion.Permutations[i];

                    modelPerm.Name = rmPerm.Name;
                    if (hasExistingPermData)
                    {
                        var existingPerm = modelRegion.Permutations.FirstOrDefault(p => p.Name == rmPerm.Name);
                        if (existingPerm != null)
                        {
                            modelPerm.CollisionPermutationIndex = existingPerm.CollisionPermutationIndex;
                            modelPerm.PhysicsPermutationIndex = existingPerm.PhysicsPermutationIndex;
                        }
                        else
                        {
                            modelPerm.CollisionPermutationIndex = -1;
                            modelPerm.PhysicsPermutationIndex = -1;
                        }
                    }
                    else
                    {
                        // For a new region, indices remain -1.
                        modelPerm.CollisionPermutationIndex = -1;
                        modelPerm.PhysicsPermutationIndex = -1;
                    }
                }
                updatedCollisionRegions.Add(modelRegion);
            }
            // Replace the model’s collision regions with the updated list.
            ModelTag.CollisionRegions = updatedCollisionRegions;

            // ================================
            // Update Variant Regions & Permutations (if any variant indices provided)
            // ================================
            if (variantIndices.Count > 0 && ModelTag.Variants != null)
            {
                foreach (int variantIndex in variantIndices)
                {
                    if (variantIndex < 0 || variantIndex >= ModelTag.Variants.Count)
                    {
                        Console.WriteLine($"Variant index {variantIndex} is out of range.");
                        continue;
                    }
                    var variant = ModelTag.Variants[variantIndex];
                    // Clear the variant regions
                    variant.Regions.Clear();

                    // Ensure the variant's ModelRegionIndices array is the correct size (16 elements)
                    if (variant.ModelRegionIndices == null || variant.ModelRegionIndices.Length != 16)
                    {
                        variant.ModelRegionIndices = new sbyte[16];
                    }

                    // Initialize ModelRegionIndices to -1
                    for (int i = 0; i < variant.ModelRegionIndices.Length; i++)
                    {
                        variant.ModelRegionIndices[i] = -1;
                    }

                    // Build a lookup of existing variant regions by name.
                    Dictionary<StringId, Model.Variant.Region> existingVariantRegions = variant.Regions
                        .Where(r => r.Name != StringId.Invalid)
                        .ToDictionary(r => r.Name, r => r);

                    // Process each valid render_model region.
                    for (int rmRegionIndex = 0; rmRegionIndex < renderModel.Regions.Count && rmRegionIndex < 16; rmRegionIndex++)
                    {
                        var rmRegion = renderModel.Regions[rmRegionIndex];
                        if (rmRegion.Name == StringId.Invalid)
                            continue;

                        Model.Variant.Region variantRegion;
                        if (!existingVariantRegions.TryGetValue(rmRegion.Name, out variantRegion))
                        {
                            // New variant region.
                            variantRegion = new Model.Variant.Region
                            {
                                Name = rmRegion.Name,
                                RenderModelRegionIndex = (sbyte)rmRegionIndex,
                                RuntimeFlags = 0,
                                ParentVariant = -1,
                                Permutations = new List<Model.Variant.Region.Permutation>()
                            };
                            variant.Regions.Add(variantRegion);
                        }

                        // Update the ModelRegionIndices
                        variant.ModelRegionIndices[rmRegionIndex] = (sbyte)variant.Regions.IndexOf(variantRegion);

                        // Process variant region permutations:
                        List<RenderModel.Region.Permutation> validRmPerms = (rmRegion.Permutations != null)
                            ? rmRegion.Permutations.Where(p => p.Name != StringId.Invalid).ToList()
                            : new List<RenderModel.Region.Permutation>();
                        int targetPermCount = validRmPerms.Count;

                        // Ensure variant region permutation list exists.
                        if (variantRegion.Permutations == null)
                            variantRegion.Permutations = new List<Model.Variant.Region.Permutation>();

                        // Remove any variant permutation with an invalid name.
                        variantRegion.Permutations.RemoveAll(p => p.Name == StringId.Invalid);

                        // If there are fewer permutations than in render_model, add new ones.
                        while (variantRegion.Permutations.Count < targetPermCount)
                        {
                            var rmPerm = validRmPerms[variantRegion.Permutations.Count];
                            // New permutation: RenderModelPermutationIndex set to the render_model permutation index.
                            var newPerm = new Model.Variant.Region.Permutation
                            {
                                Name = rmPerm.Name,
                                RenderModelPermutationIndex = (sbyte)variantRegion.Permutations.Count,
                                Probability = randomFlag ? 0.1f : 0
                            };
                            variantRegion.Permutations.Add(newPerm);
                        }
                        // If there are too many, trim the extra ones.
                        while (variantRegion.Permutations.Count > targetPermCount)
                        {
                            variantRegion.Permutations.RemoveAt(variantRegion.Permutations.Count - 1);
                        }
                        // Update variant permutation indices and force first probability to 1 if random flag is not set.
                        for (int k = 0; k < targetPermCount; k++)
                        {
                            var perm = variantRegion.Permutations[k];
                            perm.RenderModelPermutationIndex = (sbyte)k;
                            if (k == 0 && !randomFlag)
                                perm.Probability = 0.1f;
                        }
                    }
                }
            }

            // Write changes back to the cache.
            using (Stream stream = CacheContext.OpenCacheReadWrite())
            {
                CacheContext.Serialize(stream, ModelTagDefinition, ModelTag);
            }

            Console.WriteLine("Done.");
            return true;
        }

        // Helper: Clone a collision region permutation.
        private Model.CollisionRegion.Permutation CloneCollisionPermutation(Model.CollisionRegion.Permutation perm)
        {
            return new Model.CollisionRegion.Permutation
            {
                Name = perm.Name,
                Flags = perm.Flags,
                CollisionPermutationIndex = perm.CollisionPermutationIndex,
                PhysicsPermutationIndex = perm.PhysicsPermutationIndex,
                Pad = perm.Pad != null ? (byte[])perm.Pad.Clone() : null
            };
        }
    }
}