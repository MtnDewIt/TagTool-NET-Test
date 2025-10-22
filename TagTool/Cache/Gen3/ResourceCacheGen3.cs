using System;
using System.IO;
using System.IO.Compression;
using TagTool.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;
using TagTool.Tags.Resources;
using TagTool.BlamFile;
using TagTool.Cache.Resources;
using TagTool.Extensions;
using System.Security.AccessControl;

namespace TagTool.Cache.Gen3
{
    public class ResourceCacheGen3 : ResourceCache
    {
        public bool isLoaded;
        public ResourceGestalt ResourceGestalt;
        public ResourceLayoutTable ResourceLayoutTable;
        public GameCacheGen3 Cache;
        public ResourcePageLruvCache ResourcePageCache;

        public ResourceCacheGen3(GameCacheGen3 cache, bool load = false)
        {
            isLoaded = false;
            Cache = cache;
            ResourcePageCache = new ResourcePageLruvCache(2L * 1024 * 1024 * 1024); // 2GB;

            if (load)
                LoadResourceCache();
        }

        public void LoadResourceCache()
        {
            var sectionTable = Cache.BaseMapFile.Header.GetSectionTable();

            // means no resources
            if (Cache.Version > CacheVersion.Halo3Beta && sectionTable.OriginalSectionBounds[(int)CacheFileSectionType.ResourceSection].Size == 0)
                return;
            // means resources but no tags, campaign.map for example. The resource section only contains pages for resources
            else if (Cache.Version > CacheVersion.Halo3Beta && sectionTable.OriginalSectionBounds[(int)CacheFileSectionType.TagSection].Size == 0)
                return;
            else
            {
                using (var cacheStream = Cache.OpenCacheRead())
                {
                    ResourceGestalt = Cache.Deserialize<ResourceGestalt>(cacheStream, Cache.TagCacheGen3.GlobalInstances["zone"]);

                    // there's probably a better way to determine which to use
                    if (ResourceGestalt.LayoutTable.Sections.Count > 0)
                        ResourceLayoutTable = ResourceGestalt.LayoutTable;
                    else
                        ResourceLayoutTable = Cache.Deserialize<ResourceLayoutTable>(cacheStream, Cache.TagCacheGen3.GlobalInstances["play"]);
                }
            }
            isLoaded = true;
        }

        public ResourceData GetTagResourceFromReference(TagResourceReference resourceReference)
        {
            if (!isLoaded)
                LoadResourceCache();

            if (resourceReference == null)
                return null;

            if (resourceReference.Gen3ResourceID == DatumHandle.None)
                return null;

            return ResourceGestalt.TagResources[resourceReference.Gen3ResourceID.Index];
        }

        public bool IsResourceValid(ResourceData tagResource)
        {
            if (tagResource == null || tagResource.ResourceTypeIndex == -1)
                return false;
            else
                return true;
        }

        public override BinkResource GetBinkResource(TagResourceReference resourceReference)
        {
            throw new NotImplementedException();
        }

        public override BitmapTextureInteropResource GetBitmapTextureInteropResource(TagResourceReference resourceReference)
        {
            var tagResource = GetTagResourceFromReference(resourceReference);
            if (!IsResourceValid(tagResource) || GetResourceTypeName(tagResource) != "bitmap_texture_interop_resource")
                return null;
            return GetResourceDefinition<BitmapTextureInteropResource>(resourceReference);
        }

        public override BitmapTextureInterleavedInteropResource GetBitmapTextureInterleavedInteropResource(TagResourceReference resourceReference)
        {
            var tagResource = GetTagResourceFromReference(resourceReference);
            if (!IsResourceValid(tagResource) || GetResourceTypeName(tagResource) != "bitmap_texture_interleaved_interop_resource")
                return null;
            return GetResourceDefinition<BitmapTextureInterleavedInteropResource>(resourceReference);
        }

        public override RenderGeometryApiResourceDefinition GetRenderGeometryApiResourceDefinition(TagResourceReference resourceReference)
        {
            var tagResource = GetTagResourceFromReference(resourceReference);
            if (!IsResourceValid(tagResource) || GetResourceTypeName(tagResource) != "render_geometry_api_resource_definition")
                return null;
            return GetResourceDefinition<RenderGeometryApiResourceDefinition>(resourceReference);
        }

        public override SoundResourceDefinition GetSoundResourceDefinition(TagResourceReference resourceReference)
        {
            var tagResource = GetTagResourceFromReference(resourceReference);
            if (!IsResourceValid(tagResource))
                return null;

            Memory<byte> primaryResourceData = GetPrimaryResource(resourceReference.Gen3ResourceID);
            Memory<byte> secondaryResourceData = GetSecondaryResource(resourceReference.Gen3ResourceID);

            if (primaryResourceData.IsEmpty)
                primaryResourceData = new byte[0];

            if (secondaryResourceData.IsEmpty)
                secondaryResourceData = new byte[0];

            //
            // Reorganize primary and secondary resources into a single contiguous data[]
            //

            byte[] data = new byte[primaryResourceData.Length + secondaryResourceData.Length];

            if (data.Length == 0)
                return null;

            var primarySubPageTable = GetPrimarySubpageTable(resourceReference.Gen3ResourceID);
            var secondarySubPageTable = GetSecondarySubpageTable(resourceReference.Gen3ResourceID);

            if (primarySubPageTable == null)
                return null;

            var primaryRunningOffset = 0;
            foreach (var subPage in primarySubPageTable.Subpages)
            {
                primaryResourceData.CopyTo(primaryRunningOffset, data, subPage.Offset, subPage.Size);
                primaryRunningOffset += subPage.Size;
            }

            if (secondarySubPageTable != null && secondaryResourceData.Length > 0)
            {
                var secondaryRunningOffset = 0;
                foreach (var subPage in secondarySubPageTable.Subpages)
                {
                    secondaryResourceData.CopyTo(secondaryRunningOffset, data, subPage.Offset, subPage.Size);
                    secondaryRunningOffset += subPage.Size;
                }
            }

            // does not exist in gen3, create one.
            var resourceDef = new SoundResourceDefinition
            {
                Data = new TagData(data)
            };
            return resourceDef;
        }

        public override ModelAnimationTagResource GetModelAnimationTagResource(TagResourceReference resourceReference)
        {
            var tagResource = GetTagResourceFromReference(resourceReference);
            if (!IsResourceValid(tagResource) || GetResourceTypeName(tagResource) != "model_animation_tag_resource")
                return null;
            return GetResourceDefinition<ModelAnimationTagResource>(resourceReference);
        }

        public override StructureBspTagResources GetStructureBspTagResources(TagResourceReference resourceReference)
        {
            var tagResource = GetTagResourceFromReference(resourceReference);
            if (!IsResourceValid(tagResource) || GetResourceTypeName(tagResource) != "structure_bsp_tag_resources")
                return null;
            // extra step for bsp resources
            if (ResourceLayoutTable.Sections[tagResource.SegmentIndex].RequiredPageIndex == -1)
                return null;
            return GetResourceDefinition<StructureBspTagResources>(resourceReference);
        }

        public override StructureBspCacheFileTagResources GetStructureBspCacheFileTagResources(TagResourceReference resourceReference)
        {
            var tagResource = GetTagResourceFromReference(resourceReference);
            if (!IsResourceValid(tagResource) || GetResourceTypeName(tagResource) != "structure_bsp_cache_file_tag_resources")
                return null;
            // extra step for bsp resources
            if (ResourceLayoutTable.Sections[tagResource.SegmentIndex].RequiredPageIndex == -1)
                return null;
            return GetResourceDefinition<StructureBspCacheFileTagResources>(resourceReference);
        }

        public override Tags.Resources.Gen4.BitmapTextureInteropResource GetBitmapTextureInteropResourceGen4(TagResourceReference resourceReference)
        {
            throw new NotImplementedException();
        }
        public override Tags.Resources.Gen4.ModelAnimationTagResource GetModelAnimationTagResourceGen4(TagResourceReference resourceReference)
        {
            throw new NotImplementedException();
        }
        public override Tags.Resources.Gen4.CollisionModelResource GetCollisionModelResourceGen4(TagResourceReference resourceReference)
        {
            throw new NotImplementedException();
        }
        public override Tags.Resources.Gen4.RenderGeometryApiResourceDefinition GetRenderGeometryApiResourceDefinitionGen4(TagResourceReference resourceReference)
        {
            throw new NotImplementedException();
        }
        public override Tags.Resources.Gen4.StructureBspTagResources GetStructureBspTagResourcesGen4(TagResourceReference resourceReference)
        {
            throw new NotImplementedException();
        }
        public override Tags.Resources.Gen4.StructureBspCacheFileTagResources GetStructureBspCacheFileTagResourcesGen4(TagResourceReference resourceReference)
        {
            throw new NotImplementedException();
        }
        public override TagResourceReference CreateBinkResource(BinkResource binkResourceDefinition)
        {
            throw new NotImplementedException();
        }

        public override TagResourceReference CreateRenderGeometryApiResource(RenderGeometryApiResourceDefinition renderGeometryDefinition)
        {
            throw new NotImplementedException();
        }

        public override TagResourceReference CreateModelAnimationGraphResource(ModelAnimationTagResource modelAnimationGraphDefinition)
        {
            throw new NotImplementedException();
        }

        public override TagResourceReference CreateBitmapInterleavedResource(BitmapTextureInterleavedInteropResource bitmapResourceDefinition)
        {
            throw new NotImplementedException();
        }

        public override TagResourceReference CreateStructureBspResource(StructureBspTagResources sbspResource)
        {
            throw new NotImplementedException();
        }

        public override TagResourceReference CreateStructureBspCacheFileResource(StructureBspCacheFileTagResources sbspCacheFileResource)
        {
            throw new NotImplementedException();
        }

        public override TagResourceReference CreateSoundResource(SoundResourceDefinition soundResourceDefinition)
        {
            return null;
        }

        public override TagResourceReference CreateBitmapResource(BitmapTextureInteropResource bitmapResourceDefinition)
        {
            return null;
        }

        private string GetResourceTypeName(ResourceData tagResource)
        {
            return Cache.StringTable.GetString(ResourceGestalt.ResourceDefinitions[tagResource.ResourceTypeIndex].Name);
        }

        private void ApplyResourceDefinitionFixups(ResourceData tagResource, byte[] resourceDefinitionData)
        {
            using (var resourceDefinitionStream = new MemoryStream(resourceDefinitionData))
            using (var fixupWriter = new EndianWriter(resourceDefinitionStream, Cache.Endianness))
            {
                for (int i = 0; i < tagResource.FixupLocations.Count; i++)
                {
                    var fixup = tagResource.FixupLocations[i];
                    fixupWriter.Seek((int)fixup.BlockOffset, SeekOrigin.Begin);
                    fixupWriter.Write(fixup.Address.Value);
                }
            }
        }

        public override object GetResourceDefinition(TagResourceReference resourceReference, Type definitionType)
        {
            var tagResource = GetTagResourceFromReference(resourceReference);
            if (!IsResourceValid(tagResource))
                return null;

            byte[] resourceDefinitionData = new byte[tagResource.DefinitionDataLength];
            Array.Copy(ResourceGestalt.DefinitionData, tagResource.DefinitionDataOffset, resourceDefinitionData, 0, tagResource.DefinitionDataLength);

            ApplyResourceDefinitionFixups(tagResource, resourceDefinitionData);

            Memory<byte> primaryResourceData = GetPrimaryResource(resourceReference.Gen3ResourceID);
            Memory<byte> secondaryResourceData = GetSecondaryResource(resourceReference.Gen3ResourceID);

            //if (primaryResourceData.IsEmpty && secondaryResourceData.IsEmpty && (definitionType ==  typeof(BitmapTextureInteropResource) || definitionType == typeof(BitmapTextureInterleavedInteropResource)))
            //    return null;

            if (primaryResourceData.IsEmpty)
                primaryResourceData = new byte[0];

            if (secondaryResourceData.IsEmpty)
                secondaryResourceData = new byte[0];

            using (var definitionDataStream = new MemoryStream(resourceDefinitionData))
            using (var dataStream = new FixedMemoryStream(primaryResourceData))
            using (var secondaryDataStream = new FixedMemoryStream(secondaryResourceData))
            using (var definitionDataReader = new EndianReader(definitionDataStream, Cache.Endianness))
            using (var dataReader = new EndianReader(dataStream, Cache.Endianness))
            using (var secondaryDataReader = new EndianReader(secondaryDataStream, Cache.Endianness))
            {
                var context = new ResourceDefinitionSerializationContext(dataReader, secondaryDataReader, definitionDataReader, tagResource.DefinitionAddress.Type);
                var deserializer = new ResourceDeserializer(Cache.Version, Cache.Platform);
                definitionDataReader.SeekTo(tagResource.DefinitionAddress.Offset);
                return deserializer.Deserialize(context, definitionType);
            }
        }

        private Memory<byte> ReadSegmentData(ResourceData resource, int pageIndex, int offset, int sizeIndex)
        {
            var page = ResourceLayoutTable.Pages[pageIndex];
            if (page.BlockIndex == uint.MaxValue || page.CompressedBlockSize == 0)
                return Memory<byte>.Empty;

            byte[] decompressed;
            if(!ResourcePageCache.TryGetPage(pageIndex, out decompressed))
            {
                decompressed = ReadPageData(resource, page);
                ResourcePageCache.AddPage(pageIndex, decompressed);
            }

            int length;
            if (sizeIndex != -1)
                length = ResourceLayoutTable.SubpageTables[sizeIndex].TotalSize;
            else
                length = decompressed.Length - offset;

            return decompressed.AsMemory(offset, length);
        }

        private ResourceSubpageTable GetPrimarySubpageTable(DatumHandle ID)
        {
            var resource = ResourceGestalt.TagResources[ID.Index];

            if (resource.SegmentIndex == -1)
                return null;

            var segment = ResourceLayoutTable.Sections[resource.SegmentIndex];

            if (segment.RequiredSizeIndex == -1)
                return null;
            else
                return ResourceLayoutTable.SubpageTables[segment.RequiredSizeIndex];
        }

        private ResourceSubpageTable GetSecondarySubpageTable(DatumHandle ID)
        {
            var resource = ResourceGestalt.TagResources[ID.Index];

            if (resource.SegmentIndex == -1)
                return null;

            var segment = ResourceLayoutTable.Sections[resource.SegmentIndex];

            if (segment.OptionalSizeIndex == -1)
                return null;
            else
                return ResourceLayoutTable.SubpageTables[segment.OptionalSizeIndex];
        }

        private Memory<byte> GetPrimaryResource(DatumHandle ID)
        {
            var resource = ResourceGestalt.TagResources[ID.Index];

            if (resource.SegmentIndex == -1)
                return null;

            var segment = ResourceLayoutTable.Sections[resource.SegmentIndex];

            if (segment.RequiredPageIndex == -1 || segment.RequiredSegmentOffset == -1)
                return null;

            if (ResourceLayoutTable.Pages[segment.RequiredPageIndex].Checksum.CRC32Value == -1)
                return null;

            return ReadSegmentData(resource, segment.RequiredPageIndex, segment.RequiredSegmentOffset, segment.RequiredSizeIndex);
        }

        private Memory<byte> GetSecondaryResource(DatumHandle ID)
        {
            var resource = ResourceGestalt.TagResources[ID.Index];

            if (resource.SegmentIndex == -1)
                return null;

            var segment = ResourceLayoutTable.Sections[resource.SegmentIndex];

            if (segment.OptionalPageIndex == -1 || segment.OptionalSegmentOffset == -1)
                return null;

            if (ResourceLayoutTable.Pages[segment.OptionalPageIndex].Checksum.CRC32Value == -1)
                return null;

            return ReadSegmentData(resource, segment.OptionalPageIndex, segment.OptionalSegmentOffset, segment.OptionalSizeIndex);
        }

        private byte[] ReadPageData(ResourceData resource, ResourcePage page)
        {
            string cacheFilePath;

            var cache = Cache;

            if (page.SharedCacheIndex != -1)
            {
                cacheFilePath = ResourceLayoutTable.SharedFiles[page.SharedCacheIndex].MapPath;
                var pathComponent = cacheFilePath.Split('\\');
                cacheFilePath = pathComponent[pathComponent.Length - 1];
                cacheFilePath = Path.Combine(Cache.Directory.FullName, cacheFilePath);

                if (cacheFilePath != Cache.CacheFile.FullName)
                    cache = OpenSharedCacheFile(cacheFilePath);
            }

            uint blockOffset = 0;
            if (page.SharedCacheIndex < 0 || (ResourceLayoutTable.SharedFiles[page.SharedCacheIndex].GlobalSharedSegmentOffset & 1) != 0)
            {
                var sectionTable = cache.BaseMapFile.Header.GetSectionTable();
                blockOffset = sectionTable.GetOffset(CacheFileSectionType.ResourceSection, page.BlockIndex);
            }
            else
            {
                blockOffset = ResourceLayoutTable.SharedFiles[page.SharedCacheIndex].BlockOffset + page.BlockIndex;
            }

            using var cacheStream = cache.OpenCacheRead();
            var pageStream = new RangeStream(cacheStream, blockOffset, page.CompressedBlockSize);

            if (page.CodecIndex == ResourcePage.CompressionCodec.None)
            {
                byte[] compressed = new byte[page.CompressedBlockSize];
                pageStream.ReadExactly(compressed);
                return compressed;
            }
            else
            {
                var decompressed = new byte[page.UncompressedBlockSize];

                using var readerDeflate = new DeflateStream(pageStream, CompressionMode.Decompress);
                readerDeflate.ReadExactly(decompressed);
                return decompressed;
            }
        }

        private GameCacheGen3 OpenSharedCacheFile(string cacheFilePath)
        {
            lock (Cache.SharedCacheFiles)
            {
                if (!Cache.SharedCacheFiles.TryGetValue(cacheFilePath, out GameCacheGen3 cache))
                {
                    var newCacheFile = new FileInfo(cacheFilePath);
                    using var newCacheReader = new EndianReader(newCacheFile.OpenRead());
                    var newMapFile = new MapFile();
                    newMapFile.Read(newCacheReader);
                    cache = Cache.SharedCacheFiles[cacheFilePath] = new GameCacheGen3(newMapFile, newCacheFile);
                }
                return cache;
            }
        }

        public override bool IsResourceValid(TagResourceReference resourceReference)
        {
            ResourceData resource = GetTagResourceFromReference(resourceReference);
            if (!IsResourceValid(resource))
                return false;

            if (resource.SegmentIndex == -1)
                return false;

            var segment = ResourceLayoutTable.Sections[resource.SegmentIndex];

            return resource.DefinitionDataLength > 0 || segment.RequiredPageIndex != -1 || segment.OptionalPageIndex != -1;
        }
    }
}