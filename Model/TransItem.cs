using Newtonsoft.Json;

namespace VRCTans.Model
{
    class TransItem
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("lang")]
        public string Text { get; set; }

        [JsonProperty("component")]
        public string Component { get; set; }
    }
}
