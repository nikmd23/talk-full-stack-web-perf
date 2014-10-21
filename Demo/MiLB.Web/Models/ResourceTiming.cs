using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MiLB.Web.Models
{
    [JsonConverter(typeof(ResourceTimingConverter))]
    public class ResourceTiming
    {
        public double ResponseTime { get; set; }
        public double RequestStart { get; set; }
        public double ConnectTime { get; set; }
        public double DomainLookupTime { get; set; }
        public double FetchStart { get; set; }
        public double RedirectTime { get; set; }
        public string InitiatorType { get; set; }
        public double Duration { get; set; }
        public double StartTime { get; set; }
        public string Name { get; set; }
    }

    public class ResourceTimingConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var array = JArray.Load(reader);
            return new ResourceTiming
            {
                Name = array[0].ToString(),
                InitiatorType = array[1].ToString(),
                ConnectTime = array[2].ToObject<double>(),
                DomainLookupTime = array[3].ToObject<double>(),
                Duration = array[4].ToObject<double>(),
                FetchStart = array[5].ToObject<double>(),
                RedirectTime = array[6].ToObject<double>(),
                StartTime = array[7].ToObject<double>(),
                ResponseTime = array[8].ToObject<double>(),
                RequestStart = array[9].ToObject<double>()
            };
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (ResourceTiming);
        }
    }
}