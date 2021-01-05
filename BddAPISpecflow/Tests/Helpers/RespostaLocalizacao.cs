using Newtonsoft.Json;
using System.Collections.Generic;

namespace BddAPISpecflow.Tests.Helpers
{
    public class RespostaLocalizacao
    {
        [JsonProperty("post code")]
        public string CodigoDoPais { get; set; }

        [JsonProperty("country")]
        public string Pais { get; set; }

        [JsonProperty("country abbreviation")]
        public string PaisAbreviacao { get; set; }

        [JsonProperty("places")]
        public List<Local> Lugares { get; set; }
    }
}
