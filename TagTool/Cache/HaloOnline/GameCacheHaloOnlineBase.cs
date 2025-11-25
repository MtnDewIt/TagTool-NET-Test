using System;
using System.Collections.Generic;
using System.IO;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;
using TagTool.Cache.HaloOnline;
using TagTool.Cache.Resources;

namespace TagTool.Cache
{
    public abstract class GameCacheHaloOnlineBase : GameCache
    {
        public TagCacheHaloOnline TagCacheGenHO;
        public StringTableHaloOnline StringTableHaloOnline;
        public ResourceCachesHaloOnlineBase ResourceCaches;
        public IMapFileStorage MapFiles;

        public override TagCache TagCache => TagCacheGenHO;
        public override StringTable StringTable => StringTableHaloOnline;
        public override ResourceCache ResourceCache => ResourceCaches;

        #region Serialization Methods

        public override void Serialize(Stream stream, CachedTag instance, object definition)
        {
            if (typeof(CachedTagHaloOnline) == instance.GetType())
                Serialize(stream, (CachedTagHaloOnline)instance, definition);
            else
                throw new Exception($"Try to serialize a {instance.GetType()} into an Halo Online Game Cache");
            
        }

        public void Serialize(Stream stream, CachedTagHaloOnline instance, object definition)
        {
            Serializer.Serialize(new HaloOnlineSerializationContext(stream, this, instance), definition);
        }

        public object Deserialize(ISerializationContext context, Type type) =>
            Deserializer.Deserialize(context, type);

        public override object Deserialize(Stream stream, CachedTag instance, Type type) =>
            Deserialize(new HaloOnlineSerializationContext(stream, this, (CachedTagHaloOnline)instance), type);

        #endregion


        public virtual void SaveTagNames(string path = null) => throw new NotImplementedException();

        public virtual void SaveFonts(Stream fontStream) => throw new NotImplementedException();

        public virtual void AddModFile(string path, Stream file) => throw new NotImplementedException();
    }
}
