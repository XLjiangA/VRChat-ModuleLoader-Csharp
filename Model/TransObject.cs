using Newtonsoft.Json;

namespace VRCTans.Model
{
    class TransObject
    {
        [JsonProperty("Objects")]
        public TransItem[] Items { get; set; }
    }
}
