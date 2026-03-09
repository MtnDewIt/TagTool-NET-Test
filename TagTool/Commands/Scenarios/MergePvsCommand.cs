using System;
using System.Collections.Generic;
using System.Linq;
using TagTool.Cache;
using TagTool.Commands.Common;
using System.Collections.Generic;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Scenarios
{
    class MergePvsCommand : Command
    {
        private GameCache Cache { get; }
        private Scenario Definition { get; }

        public MergePvsCommand(GameCache cache, Scenario definition) :
            base(true,

                "MergePvs",
                "Merges all zone set PVS and audibility data into a single zone set, removing all others.",

                "MergePvs",

                "Merges PVS visibility bit vectors and audibility room/door data from all zone\n" +
                "sets into a single replacement entry using bitwise OR and range union.\n" +
                "All other zone sets, PVS entries, audibility entries, and BSP atlas blocks\n" +
                "are removed since multiplayer only uses one active zone set.")
        {
            Cache = cache;
            Definition = definition;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count != 0)
                return new TagToolError(CommandError.ArgCount);

            if (Definition.ZoneSetPvs == null || Definition.ZoneSetPvs.Count == 0)
                return new TagToolError(CommandError.CustomError, "Scenario has no ZoneSetPvs entries.");

            if (Definition.ZoneSets == null || Definition.ZoneSets.Count == 0)
                return new TagToolError(CommandError.CustomError, "Scenario has no ZoneSets.");

            // ----------------------------------------------------------------
            // 1. Collect all unique PVS and audibility blocks across zone sets
            // ----------------------------------------------------------------
            var pvsBlocks        = new List<Scenario.ZoneSetPvsBlock>();
            var audibilityBlocks = new List<Scenario.ZoneSetAudibilityBlock>();

            foreach (var zs in Definition.ZoneSets)
            {
                if (zs.PvsIndex >= 0 && zs.PvsIndex < Definition.ZoneSetPvs.Count)
                {
                    var pvs = Definition.ZoneSetPvs[zs.PvsIndex];
                    if (!pvsBlocks.Contains(pvs))
                        pvsBlocks.Add(pvs);
                }

                if (Definition.ZoneSetAudibility != null &&
                    zs.AudibilityIndex >= 0 && zs.AudibilityIndex < Definition.ZoneSetAudibility.Count)
                {
                    var aud = Definition.ZoneSetAudibility[zs.AudibilityIndex];
                    if (!audibilityBlocks.Contains(aud))
                        audibilityBlocks.Add(aud);
                }
            }

            if (pvsBlocks.Count == 0)
                return new TagToolError(CommandError.CustomError, "No valid PVS blocks found via ZoneSet.PvsIndex.");

            Console.WriteLine($"Merging {pvsBlocks.Count} PVS block(s) and " +
                              $"{audibilityBlocks.Count} audibility block(s) " +
                              $"from {Definition.ZoneSets.Count} zone set(s)...");

            // ----------------------------------------------------------------
            // 2. Build merged data
            // ----------------------------------------------------------------
            var mergedPvs = BuildMergedPvs(pvsBlocks);

            Scenario.ZoneSetAudibilityBlock mergedAud = null;
            if (audibilityBlocks.Count > 0)
                mergedAud = BuildMergedAudibility(audibilityBlocks);
            else
                Console.WriteLine("Warning: No audibility blocks found; AudibilityIndex will be -1.");

            // ----------------------------------------------------------------
            // 3. Replace all zone sets, PVS entries, and audibility entries
            //    with the single merged result
            // ----------------------------------------------------------------
            Definition.ZoneSetPvs.Clear();
            Definition.ZoneSetPvs.Add(mergedPvs);

            if (Definition.ZoneSetAudibility != null)
                Definition.ZoneSetAudibility.Clear();

            if (mergedAud != null)
            {
                if (Definition.ZoneSetAudibility == null)
                    Definition.ZoneSetAudibility = new List<Scenario.ZoneSetAudibilityBlock>();
                Definition.ZoneSetAudibility.Add(mergedAud);
            }

            // Build the single replacement zone set
            var mergedZoneSet = CreateMergedZoneSet(mergedPvs, mergedAud != null ? 0 : -1);

            Definition.ZoneSets.Clear();
            Definition.ZoneSets.Add(mergedZoneSet);

            // ----------------------------------------------------------------
            // 4. Clear BSP atlas blocks since they are unused in multiplayer
            // ----------------------------------------------------------------
            if (Definition.BspAtlas != null)
            {
                Definition.BspAtlas.Clear();
                Console.WriteLine("BSP atlas blocks cleared.");
            }

            Console.WriteLine($"Zone sets collapsed to 1. Bsps mask: 0x{(uint)mergedPvs.StructureBspMask:X8}");
            Console.WriteLine("Done. Save the tag to commit changes.");
            return true;
        }

        // ====================================================================
        // PVS merge
        // ====================================================================

        private Scenario.ZoneSetPvsBlock BuildMergedPvs(IReadOnlyList<Scenario.ZoneSetPvsBlock> sources)
        {
            var merged = new Scenario.ZoneSetPvsBlock();

            // Union of all BSP masks
            int combinedBspMask = 0;
            foreach (var src in sources)
                combinedBspMask |= (int)src.StructureBspMask;
            merged.StructureBspMask = (Scenario.BspFlags)combinedBspMask;

            merged.Version = sources.Max(s => s.Version);
            merged.Flags   = sources.Aggregate(
                (Scenario.ZoneSetPvsBlock.ZoneSetPvsFlags)0,
                (acc, s) => acc | s.Flags);

            merged.BspChecksums    = MergeBspChecksums(sources);

            merged.StructureBspPvs = MergeBspPvsList(sources, combinedBspMask);

            merged.PortaldeviceMapping = MergePortalDeviceMappings(sources);

            return merged;
        }

        private List<Scenario.ZoneSetPvsBlock.BspChecksum> MergeBspChecksums(
            IReadOnlyList<Scenario.ZoneSetPvsBlock> sources)
        {
            foreach (var src in sources)
                if (src.BspChecksums != null && src.BspChecksums.Count > 0)
                    return src.BspChecksums;
            return new List<Scenario.ZoneSetPvsBlock.BspChecksum>();
        }

        // PortaldeviceMapping is indexed by raw structure_bsp_index, not mask slot.
        // game_get_machine_door_portal_reference reads PortaldeviceMapping[structure_bsp_index]
        // directly, so the list must have one entry per BSP in order with empty placeholders
        // for any BSP that has no device portals.
        private List<Scenario.ZoneSetPvsBlock.PortalDeviceMappingBlock> MergePortalDeviceMappings(
            IReadOnlyList<Scenario.ZoneSetPvsBlock> sources)
        {
            int maxBspIndex = -1;
            foreach (var src in sources)
            {
                if (src.PortaldeviceMapping == null) continue;
                int last = src.PortaldeviceMapping.Count - 1;
                if (last > maxBspIndex) maxBspIndex = last;
            }

            if (maxBspIndex < 0)
                return new List<Scenario.ZoneSetPvsBlock.PortalDeviceMappingBlock>();

            var result = new List<Scenario.ZoneSetPvsBlock.PortalDeviceMappingBlock>(maxBspIndex + 1);

            for (int bspIdx = 0; bspIdx <= maxBspIndex; bspIdx++)
            {
                Scenario.ZoneSetPvsBlock.PortalDeviceMappingBlock entry = null;
                foreach (var src in sources)
                {
                    if (src.PortaldeviceMapping == null || bspIdx >= src.PortaldeviceMapping.Count) continue;
                    var candidate = src.PortaldeviceMapping[bspIdx];
                    if (candidate == null) continue;
                    int candidatePortalCount = candidate.GamePortalToPortalMap?.Count ?? 0;
                    int entryPortalCount = entry?.GamePortalToPortalMap?.Count ?? 0;
                    if (candidatePortalCount > entryPortalCount)
                        entry = candidate;
                }

                result.Add(entry ?? new Scenario.ZoneSetPvsBlock.PortalDeviceMappingBlock
                {
                    DevicePortalAssociations = new List<Scenario.ZoneSetPvsBlock.PortalDeviceMappingBlock.DevicePortalAssociation>(),
                    GamePortalToPortalMap = new List<Scenario.ZoneSetPvsBlock.PortalDeviceMappingBlock.GamePortalToPortalMapping>()
                });
            }

            return result;
        }

        // The runtime indexes StructureBspPvs by popcount(Bsps & ((1 << bspIdx) - 1)),
        // meaning only BSPs present in the mask get a slot and the list must be exactly
        // that length. We iterate set bits in the combined mask in order, find the
        // matching source entry from each PVS block by the same popcount logic, then
        // merge those entries together.
        private List<Scenario.ZoneSetPvsBlock.BspPvsBlock> MergeBspPvsList(
            IReadOnlyList<Scenario.ZoneSetPvsBlock> sources, int combinedBspMask)
        {
            // First pass: build bspIdx -> Bits.Count map by scanning source bit vector data.
            // Every ClusterPvsBitVectors[slot] for target BSP N has Bits.Count == ceil(N.clusters/32).
            // We need this to emit correctly-sized zero blocks for BSPs a given cluster can't see.
            var bspDwordCounts = new Dictionary<int, int>();
            foreach (var src in sources)
            {
                if (src.StructureBspPvs == null) continue;
                foreach (var bspBlock in src.StructureBspPvs)
                {
                    if (bspBlock?.ClusterPvs == null || bspBlock.ClusterPvs.Count == 0) continue;
                    var clBitVecs = bspBlock.ClusterPvs[0].ClusterPvsBitVectors;
                    if (clBitVecs == null) continue;
                    for (int vecSlot = 0; vecSlot < clBitVecs.Count; vecSlot++)
                    {
                        int targetBspIdx = NthSetBit((int)src.StructureBspMask, vecSlot);
                        if (targetBspIdx < 0) break;
                        if (bspDwordCounts.ContainsKey(targetBspIdx)) continue;
                        var bits = clBitVecs[vecSlot].Bits;
                        if (bits != null && bits.Count > 0)
                            bspDwordCounts[targetBspIdx] = bits.Count;
                    }
                }
            }

            var result = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock>();

            for (int bspIdx = 0; bspIdx < 32; bspIdx++)
            {
                if ((combinedBspMask & (1 << bspIdx)) == 0)
                    continue;

                var bspEntries = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock>();
                var bspEntrySrcMasks = new List<int>();
                foreach (var src in sources)
                {
                    if (src.StructureBspPvs == null) continue;
                    if (((int)src.StructureBspMask & (1 << bspIdx)) == 0) continue;

                    int slotIndex = CountBitsBelow((int)src.StructureBspMask, bspIdx);
                    if (slotIndex < src.StructureBspPvs.Count)
                    {
                        bspEntries.Add(src.StructureBspPvs[slotIndex]);
                        bspEntrySrcMasks.Add((int)src.StructureBspMask);
                    }
                }

                if (bspEntries.Count > 0)
                {
                    int clusterCount = bspEntries
                        .Select(e => e.ClusterPvs?.Count ?? 0)
                        .FirstOrDefault(c => c > 0);
                    result.Add(MergeSingleBspPvs(bspEntries, clusterCount,
                        bspEntrySrcMasks, combinedBspMask, bspDwordCounts));
                }
            }

            return result;
        }

        // Returns the index of the nth set bit in mask (0-based), or -1 if not enough bits.
        private static int NthSetBit(int mask, int n)
        {
            int count = 0;
            for (int i = 0; i < 32; i++)
            {
                if ((mask & (1 << i)) != 0)
                {
                    if (count == n) return i;
                    count++;
                }
            }
            return -1;
        }

        // Counts the number of set bits strictly below bitIndex (equivalent to the
        // runtime's count_bits(mask & ((1 << bitIndex) - 1))).
        private static int CountBitsBelow(int mask, int bitIndex)
        {
            int below = mask & ((1 << bitIndex) - 1);
            int count = 0;
            while (below != 0) { count += below & 1; below >>= 1; }
            return count;
        }

        private Scenario.ZoneSetPvsBlock.BspPvsBlock MergeSingleBspPvs(
            IReadOnlyList<Scenario.ZoneSetPvsBlock.BspPvsBlock> sources, int clusterCount,
            IReadOnlyList<int> sourceBspMasks, int mergedBspMask,
            IReadOnlyDictionary<int, int> bspDwordCounts)
        {
            return new Scenario.ZoneSetPvsBlock.BspPvsBlock
            {
                ClusterPvs = MergeClusterPvsList(
                    sources.Select(s => s.ClusterPvs).ToList(), clusterCount,
                    sourceBspMasks, mergedBspMask, bspDwordCounts),

                ClusterPvsDoorsClosed = MergeClusterPvsList(
                    sources.Select(s => s.ClusterPvsDoorsClosed).ToList(), clusterCount,
                    sourceBspMasks, mergedBspMask, bspDwordCounts),

                AttachedSkyIndices = MergeSkyIndicesList(
                    sources.Select(s => s.AttachedSkyIndices).ToList()),

                VisibleSkyIndices = MergeSkyIndicesList(
                    sources.Select(s => s.VisibleSkyIndices).ToList()),

                MutipleSkiesVisibleBitvector = MergeBitVectorDwordLists(
                    sources.Select(s => s.MutipleSkiesVisibleBitvector).ToList()),

                ClusterAudioBitvector = MergeBitVectorDwordLists(
                    sources.Select(s => s.ClusterAudioBitvector).ToList()),

                ClusterMappings = MergeClusterMappings(
                    sources.Select(s => s.ClusterMappings))
            };
        }

        private List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock> MergeClusterPvsList(
            IReadOnlyList<List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock>> sourceLists,
            int clusterCount,
            IReadOnlyList<int> sourceBspMasks, int mergedBspMask,
            IReadOnlyDictionary<int, int> bspDwordCounts)
        {
            int maxClusters = sourceLists
                .Where(l => l != null).Select(l => l.Count).DefaultIfEmpty(0).Max();

            int targetClusters = clusterCount > 0 ? clusterCount : maxClusters;

            if (targetClusters == 0)
                return new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock>();

            var result = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock>(targetClusters);

            // Pre-allocate source entry list once and reuse across clusters to avoid per-cluster allocs
            var sourceEntries = new List<(List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock> BitVecs, int Mask)>(sourceLists.Count);

            for (int clusterIdx = 0; clusterIdx < targetClusters; clusterIdx++)
            {
                sourceEntries.Clear();
                for (int i = 0; i < sourceLists.Count; i++)
                {
                    var l = sourceLists[i];
                    sourceEntries.Add((
                        BitVecs: (l != null && clusterIdx < l.Count) ? l[clusterIdx].ClusterPvsBitVectors : null,
                        Mask: i < sourceBspMasks.Count ? sourceBspMasks[i] : 0));
                }

                result.Add(new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock
                {
                    ClusterPvsBitVectors = MergeBitVectorBlockLists(
                        sourceEntries, mergedBspMask, bspDwordCounts)
                });
            }

            return result;
        }

        // CluserPvsBitVectorBlock.Bits is a flat list of visibility dwords — no header, no pointer.
        // Bits.Count must equal ceil(targetBsp.clusters.count / 32); the engine asserts this.
        // ClusterPvsBitVectors must have exactly popcount(mergedBspMask) entries (one per loaded BSP).
        // For target BSPs where a cluster has no visibility data we emit a zero-filled block so
        // the runtime's CountBitsBelow slot indexing stays consistent.
        private List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock>
            MergeBitVectorBlockLists(
            IReadOnlyList<(List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock> BitVecs, int Mask)> sourceEntries,
            int mergedBspMask,
            IReadOnlyDictionary<int, int> bspDwordCounts)
        {
            var result = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock>();

            for (int targetBspIdx = 0; targetBspIdx < 16; targetBspIdx++)
            {
                if ((mergedBspMask & (1 << targetBspIdx)) == 0)
                    continue;

                var bitLists = new List<List<Scenario.ZoneSetPvsBlock.BitVectorDword>>();
                int dwordsNeeded = 0;

                foreach (var (bitVecs, srcMask) in sourceEntries)
                {
                    if (bitVecs == null || (srcMask & (1 << targetBspIdx)) == 0) continue;

                    int srcSlot = CountBitsBelow(srcMask, targetBspIdx);
                    if (srcSlot >= bitVecs.Count) continue;

                    var bits = bitVecs[srcSlot].Bits;
                    if (bits == null || bits.Count == 0) continue;

                    if (dwordsNeeded == 0)
                        dwordsNeeded = bits.Count; // authoritative count from source

                    bitLists.Add(bits);
                }

                // No source had visibility data for this target BSP — emit a zero block
                // of the correct size so slot count stays == popcount(mergedBspMask)
                if (dwordsNeeded == 0)
                    bspDwordCounts.TryGetValue(targetBspIdx, out dwordsNeeded);

                if (dwordsNeeded == 0)
                    dwordsNeeded = 1; // should never happen on valid tags

                result.Add(new Scenario.ZoneSetPvsBlock.BspPvsBlock.ClusterPvsBlock.CluserPvsBitVectorBlock
                {
                    Bits = MergeBitVectorDwordLists(bitLists, dwordsNeeded)
                });
            }

            return result;
        }


        private List<Scenario.ZoneSetPvsBlock.BitVectorDword> MergeBitVectorDwordLists(
            IReadOnlyList<List<Scenario.ZoneSetPvsBlock.BitVectorDword>> sourceLists,
            int minDwords = 0)
        {
            var validLists = sourceLists.Where(l => l != null && l.Count > 0).ToList();

            int rawLen = validLists.Count > 0 ? validLists.Max(l => l.Count) : 0;

            // pvs_write_row reads exactly ceil(clusterCount/32) dwords from the pointer
            // into our Bits data. If our list is shorter than that it reads off the end.
            // Ensure the list is at least minDwords long, padding with zero dwords.
            int targetLen = minDwords > 0 ? Math.Max(rawLen, minDwords) : rawLen;

            if (targetLen == 0)
                return new List<Scenario.ZoneSetPvsBlock.BitVectorDword>();

            var result = new List<Scenario.ZoneSetPvsBlock.BitVectorDword>(targetLen);

            for (int i = 0; i < targetLen; i++)
            {
                int combined = 0;
                foreach (var list in validLists)
                    if (i < list.Count)
                        combined |= (int)list[i].Bits;

                result.Add(new Scenario.ZoneSetPvsBlock.BitVectorDword
                {
                    Bits = (Scenario.ZoneSetPvsBlock.BitVectorDword.DwordBits)combined
                });
            }

            return result;
        }

        // Per-cluster slot merge: one entry per cluster, take the first valid sky index
        private List<Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock> MergeSkyIndicesList(
            IReadOnlyList<List<Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock>> sourceLists)
        {
            int maxClusters = sourceLists
                .Where(l => l != null).Select(l => l.Count).DefaultIfEmpty(0).Max();

            if (maxClusters == 0)
                return new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock>();

            var result = new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock>(maxClusters);

            for (int i = 0; i < maxClusters; i++)
            {
                sbyte skyIndex = -1;
                foreach (var list in sourceLists)
                    if (list != null && i < list.Count && list[i].SkyIndex >= 0)
                    {
                        skyIndex = list[i].SkyIndex;
                        break;
                    }

                result.Add(new Scenario.ZoneSetPvsBlock.BspPvsBlock.SkyIndicesBlock
                {
                    SkyIndex = skyIndex
                });
            }

            return result;
        }

        // ClusterMappings is indexed directly as ClusterMappings[cluster_index] by the audio
        // system — must be exactly clusterCount entries in original order. Take first valid source.
        private List<Scenario.ZoneSetPvsBlock.BspPvsBlock.BspSeamClusterMapping> MergeClusterMappings(
            IEnumerable<List<Scenario.ZoneSetPvsBlock.BspPvsBlock.BspSeamClusterMapping>> sourceLists)
        {
            foreach (var list in sourceLists)
                if (list != null && list.Count > 0)
                    return list;

            return new List<Scenario.ZoneSetPvsBlock.BspPvsBlock.BspSeamClusterMapping>();
        }

        // ====================================================================
        // Audibility merge
        // ====================================================================

        private Scenario.ZoneSetAudibilityBlock BuildMergedAudibility(
            IReadOnlyList<Scenario.ZoneSetAudibilityBlock> sources)
        {
            var merged = new Scenario.ZoneSetAudibilityBlock();

            // Summed since each source covers a distinct set of BSP rooms/doors
            merged.DoorPortalCount = sources.Sum(s => s.DoorPortalCount);
            merged.RoomCount       = sources.Sum(s => s.RoomCount);

            // Union of all source distance ranges
            merged.RoomDistanceBounds = new TagTool.Common.Bounds<float>(
                sources.Min(s => s.RoomDistanceBounds.Lower),
                sources.Max(s => s.RoomDistanceBounds.Upper));

            // OR-merge so the most permissive attenuation value wins per entry
            merged.EncodedDoorPas = MergeEncodedInt32Blocks(
                sources.Select(s => s.EncodedDoorPas).ToList(),
                (a, b) => a | b);

            merged.RoomDoorPortalEncodedPas = MergeEncodedInt32Blocks(
                sources.Select(s => s.RoomDoorPortalEncodedPas).ToList(),
                (a, b) => a | b);

            merged.AiDeafeningPas = MergeEncodedInt32Blocks(
                sources.Select(s => s.AiDeafeningPas).ToList(),
                (a, b) => a | b);

            // Max per entry so nothing goes mute across the merged set
            merged.RoomDistances = MergeEncodedSbyteBlocks(
                sources.Select(s => s.RoomDistances).ToList(),
                (a, b) => (sbyte)Math.Max(a, b));

            // Concatenate portal->occluder mappings, rebasing FirstDoorOccluderIndex per source
            merged.GamePortalToDoorOccluderMappings = MergePortalToDoorMappings(sources);

            // Concatenate cluster->room mappings, rebasing FirstRoomIndex to match the appended indices list
            merged.BspClusterToRoomBoundsMappings = new List<Scenario.ZoneSetAudibilityBlock.BspClusterToRoomBoundsMapping>();
            merged.BspClusterToRoomIndices        = new List<Scenario.ZoneSetAudibilityBlock.BspClusterToRoomIndex>();

            foreach (var src in sources)
            {
                if (src.BspClusterToRoomBoundsMappings == null) continue;

                int roomIndexOffset = merged.BspClusterToRoomIndices.Count;

                foreach (var mapping in src.BspClusterToRoomBoundsMappings)
                {
                    merged.BspClusterToRoomBoundsMappings.Add(
                        new Scenario.ZoneSetAudibilityBlock.BspClusterToRoomBoundsMapping
                        {
                            FirstRoomIndex = mapping.FirstRoomIndex + roomIndexOffset,
                            RoomIndexCount = mapping.RoomIndexCount
                        });
                }

                if (src.BspClusterToRoomIndices != null)
                    merged.BspClusterToRoomIndices.AddRange(src.BspClusterToRoomIndices);
            }

            return merged;
        }

        private List<Scenario.ZoneSetAudibilityBlock.EncodedDoorPa> MergeEncodedInt32Blocks(
            IReadOnlyList<List<Scenario.ZoneSetAudibilityBlock.EncodedDoorPa>> sourceLists,
            Func<int, int, int> combine)
        {
            var validLists = sourceLists.Where(l => l != null && l.Count > 0).ToList();
            if (validLists.Count == 0)
                return new List<Scenario.ZoneSetAudibilityBlock.EncodedDoorPa>();

            int maxLen = validLists.Max(l => l.Count);
            var result = new List<Scenario.ZoneSetAudibilityBlock.EncodedDoorPa>(maxLen);

            for (int i = 0; i < maxLen; i++)
            {
                int combined = 0;
                foreach (var list in validLists)
                    if (i < list.Count)
                        combined = combine(combined, list[i].EncodedData);

                result.Add(new Scenario.ZoneSetAudibilityBlock.EncodedDoorPa { EncodedData = combined });
            }

            return result;
        }

        private List<Scenario.ZoneSetAudibilityBlock.RoomDoorPortalEncodedPa> MergeEncodedInt32Blocks(
            IReadOnlyList<List<Scenario.ZoneSetAudibilityBlock.RoomDoorPortalEncodedPa>> sourceLists,
            Func<int, int, int> combine)
        {
            var validLists = sourceLists.Where(l => l != null && l.Count > 0).ToList();
            if (validLists.Count == 0)
                return new List<Scenario.ZoneSetAudibilityBlock.RoomDoorPortalEncodedPa>();

            int maxLen = validLists.Max(l => l.Count);
            var result = new List<Scenario.ZoneSetAudibilityBlock.RoomDoorPortalEncodedPa>(maxLen);

            for (int i = 0; i < maxLen; i++)
            {
                int combined = 0;
                foreach (var list in validLists)
                    if (i < list.Count)
                        combined = combine(combined, list[i].EncodedData);

                result.Add(new Scenario.ZoneSetAudibilityBlock.RoomDoorPortalEncodedPa { EncodedData = combined });
            }

            return result;
        }

        private List<Scenario.ZoneSetAudibilityBlock.AiDeafeningPa> MergeEncodedInt32Blocks(
            IReadOnlyList<List<Scenario.ZoneSetAudibilityBlock.AiDeafeningPa>> sourceLists,
            Func<int, int, int> combine)
        {
            var validLists = sourceLists.Where(l => l != null && l.Count > 0).ToList();
            if (validLists.Count == 0)
                return new List<Scenario.ZoneSetAudibilityBlock.AiDeafeningPa>();

            int maxLen = validLists.Max(l => l.Count);
            var result = new List<Scenario.ZoneSetAudibilityBlock.AiDeafeningPa>(maxLen);

            for (int i = 0; i < maxLen; i++)
            {
                int combined = 0;
                foreach (var list in validLists)
                    if (i < list.Count)
                        combined = combine(combined, list[i].EncodedData);

                result.Add(new Scenario.ZoneSetAudibilityBlock.AiDeafeningPa { EncodedData = combined });
            }

            return result;
        }

        private List<Scenario.ZoneSetAudibilityBlock.RoomDistance> MergeEncodedSbyteBlocks(
            IReadOnlyList<List<Scenario.ZoneSetAudibilityBlock.RoomDistance>> sourceLists,
            Func<sbyte, sbyte, sbyte> combine)
        {
            var validLists = sourceLists.Where(l => l != null && l.Count > 0).ToList();
            if (validLists.Count == 0)
                return new List<Scenario.ZoneSetAudibilityBlock.RoomDistance>();

            int maxLen = validLists.Max(l => l.Count);
            var result = new List<Scenario.ZoneSetAudibilityBlock.RoomDistance>(maxLen);

            for (int i = 0; i < maxLen; i++)
            {
                sbyte combined = sbyte.MinValue;
                foreach (var list in validLists)
                    if (i < list.Count)
                        combined = combine(combined, list[i].EncodedData);

                result.Add(new Scenario.ZoneSetAudibilityBlock.RoomDistance { EncodedData = combined });
            }

            return result;
        }

        private List<Scenario.ZoneSetAudibilityBlock.GamePortalToDoorOccluderMapping>
            MergePortalToDoorMappings(IReadOnlyList<Scenario.ZoneSetAudibilityBlock> sources)
        {
            // Indexed by BSP index directly — one entry per BSP, same as PortaldeviceMapping.
            // audibility_door_occluder_to_game_portal_index iterates this array and uses the
            // loop counter as structure_bsp_index, so order and count must match BSP indices.
            int maxBspIndex = sources
                .Where(s => s.GamePortalToDoorOccluderMappings != null)
                .Select(s => s.GamePortalToDoorOccluderMappings.Count - 1)
                .DefaultIfEmpty(-1).Max();

            if (maxBspIndex < 0)
                return new List<Scenario.ZoneSetAudibilityBlock.GamePortalToDoorOccluderMapping>();

            var result = new List<Scenario.ZoneSetAudibilityBlock.GamePortalToDoorOccluderMapping>(maxBspIndex + 1);

            for (int bspIdx = 0; bspIdx <= maxBspIndex; bspIdx++)
            {
                Scenario.ZoneSetAudibilityBlock.GamePortalToDoorOccluderMapping entry = null;
                foreach (var src in sources)
                {
                    if (src.GamePortalToDoorOccluderMappings == null ||
                        bspIdx >= src.GamePortalToDoorOccluderMappings.Count) continue;
                    var candidate = src.GamePortalToDoorOccluderMappings[bspIdx];
                    if (candidate.DoorOccluderCount > 0)
                    {
                        entry = candidate;
                        break;
                    }
                }

                result.Add(entry ?? new Scenario.ZoneSetAudibilityBlock.GamePortalToDoorOccluderMapping
                {
                    FirstDoorOccluderIndex = 0,
                    DoorOccluderCount = 0
                });
            }

            return result;
        }

        // ====================================================================
        // Zone set creation
        // ====================================================================

        private Scenario.ZoneSet CreateMergedZoneSet(
            Scenario.ZoneSetPvsBlock mergedPvs, int audibilityIndex)
        {
            return new Scenario.ZoneSet
            {
                Name     = Cache.StringTable.GetOrAddString("merged_all"),
                PvsIndex = 0,
                Bsps     = mergedPvs.StructureBspMask,

                AudibilityIndex = audibilityIndex,

                RequiredDesignerZones  = (Scenario.ZoneFlags)0,
                ForbiddenDesignerZones = (Scenario.ZoneFlags)0,
                CinematicZones         = (Scenario.ZoneFlags)0,

                HintPreviousZoneSet = -1,
                Flags               = Scenario.ZoneSet.ZoneSetFlags.None
            };
        }
    }
}
