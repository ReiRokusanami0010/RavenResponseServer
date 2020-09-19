using Newtonsoft.Json;

namespace NekomataResponseServer.Schemes {
    public class SecureScheme {
        [JsonProperty("DeviceName")]
        public string DeviceName { get; set; }
        [JsonProperty("OSName")]
        public string OSName { get; set; }
    }
}