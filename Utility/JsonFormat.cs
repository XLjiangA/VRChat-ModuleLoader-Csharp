using Newtonsoft.Json;

namespace VRCTans.Utility
{
    internal class JsonFormat
    {
        public static T Get<T>(string jsonBase)
            => JsonConvert.DeserializeObject<T>(jsonBase);

    }
}
