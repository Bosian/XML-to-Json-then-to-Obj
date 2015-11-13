using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    public class MyJsonConverter<T> : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                return serializer.Deserialize<List<T>>(reader);
            }
            else
            {
                T skill = serializer.Deserialize<T>(reader);
                return new List<T>(new[] { skill });
            }
        }


        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }


        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //writer.WriteValue(value);

            writer.WriteRawValue(JsonConvert.SerializeObject(value));
        }
    }
}
