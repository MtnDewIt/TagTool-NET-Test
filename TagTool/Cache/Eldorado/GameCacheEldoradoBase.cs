using System;
using System.Collections.Generic;
using System.IO;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;
using TagTool.Cache.Eldorado;
using TagTool.Cache.Resources;

namespace TagTool.Cache
{
    public abstract class GameCacheEldoradoBase : GameCache
    {
        public TagCacheEldorado TagCacheEldorado;
        public StringTableEldorado StringTableEldorado;
        public ResourceCachesEldoradoBase ResourceCaches;

        public override TagCache TagCache => TagCacheEldorado;
        public override StringTable StringTable => StringTableEldorado;
        public override ResourceCache ResourceCache => ResourceCaches;

        #region Serialization Methods

        public override void Serialize(Stream stream, CachedTag instance, object definition)
        {
            if (typeof(CachedTagEldorado) == instance.GetType())
                Serialize(stream, (CachedTagEldorado)instance, definition);
            else
                throw new Exception($"Try to serialize a {instance.GetType()} into an Halo Online Game Cache");
            
        }

        public void Serialize(Stream stream, CachedTagEldorado instance, object definition)
        {
            Serializer.Serialize(new EldoradoSerializationContext(stream, this, instance), definition);
        }

        public object Deserialize(ISerializationContext context, Type type) =>
            Deserializer.Deserialize(context, type);

        public override object Deserialize(Stream stream, CachedTag instance, Type type) =>
            Deserialize(new EldoradoSerializationContext(stream, this, (CachedTagEldorado)instance), type);

        #endregion
        

        public virtual void SaveTagNames(string path = null) => throw new NotImplementedException();

        public virtual void SaveFonts(Stream fontStream) => throw new NotImplementedException();

        public virtual void AddModFile(string path, Stream file) => throw new NotImplementedException();
    }
}
