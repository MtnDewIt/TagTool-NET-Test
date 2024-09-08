using Newtonsoft.Json;
using TagTool.Cache;
using System;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class LastModificationDateHandler : JsonConverter<LastModificationDate> 
    {
        public override void WriteJson(JsonWriter writer, LastModificationDate value, JsonSerializer serializer)
        {
            var date = "";

            if (value.Low != 0 && value.High != 0) 
            {
                date = $@"{value.GetModificationDate():yyyy-MM-dd HH:mm:ss.FFFFFFF}";
            }

            writer.WriteValue(date);
        }

        public override LastModificationDate ReadJson(JsonReader reader, Type objectType, LastModificationDate existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var date = reader.Value.ToString();

            var modificationDate = new LastModificationDate();

            if (date != "") 
            {
                var dateTime = DateTime.Parse(date);
                modificationDate.SetModificationDate(dateTime);
            }

            return modificationDate;
        }
    }
}
