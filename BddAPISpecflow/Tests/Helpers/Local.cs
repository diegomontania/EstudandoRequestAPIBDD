using Newtonsoft.Json;

namespace BddAPISpecflow.Tests.Helpers
{
    public class Local
    {
        [JsonProperty("place name")]
        public string CodigoPostal { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("state")]
        public string Estado { get; set; }

        [JsonProperty("state abbreviation")]
        public string EstadoAbreviacao { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }
    }
}
