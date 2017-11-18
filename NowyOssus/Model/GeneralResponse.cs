using System;
using Newtonsoft.Json;

namespace NowyOssus.Model
{
    public class GeneralResponse<T> where T : class
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results")]
        public T[] Results { get; set; }
    }
}
