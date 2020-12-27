using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace BddAPISpecflow.ClassesTest.RequestAPI
{
    public class ResquestApiRestSharp
    {
        private RestClient _restClient;
        private RestRequest _restRequest;
        public IRestResponse RespostaRequest;

        public void CallGet(string url, string codigoPais, string codigoPostal)
        {
            _restClient = new RestClient(url);
            _restRequest = new RestRequest($"{codigoPais}/{codigoPostal}", Method.GET);

            //executa a chamada
           RespostaRequest = _restClient.Execute(_restRequest);
        }

        public string DeserializeResposta()
        {
            var deserealize = new JsonDeserializer();
            var resultadoDeserializado = deserealize.Deserialize<Dictionary<string, string>>(RespostaRequest);

            var resultado = resultadoDeserializado["places"];
            return resultado;
        }
    }
}
