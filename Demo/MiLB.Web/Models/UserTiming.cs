using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MiLB.Web.Models
{
    [JsonConverter(typeof(UserTimingConverter))]
    public class UserTiming
    {
        public double Duration { get; set; }
        public double StartTime { get; set; }
        public string Name { get; set; }
    }

    public class UserTimingConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var array = JArray.Load(reader);
            return new UserTiming
            {
                Name = array[0].ToString(), 
                Duration = array[1].ToObject<double>(), 
                StartTime = array[2].ToObject<double>()
            };
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (UserTiming);
        }
    }
}