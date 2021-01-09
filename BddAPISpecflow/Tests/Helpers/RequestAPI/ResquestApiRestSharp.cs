using BddAPISpecflow.Tests.Helpers;
using Newtonsoft.Json;
using RestSharp;

namespace BddAPISpecflow.Helpers.RequestAPI
{
    public class ResquestApiRestSharp
    {
        private RestClient _cliente;
        private RestRequest _requisicao;
        public IRestResponse RespostaRequest;

        public RespostaLocalizacao RespostaLocalizacao;

        public void ChamaAPI(string url, string abreviacaoPais, string codigoPostal)
        {
            _cliente = new RestClient(url);
            _requisicao = new RestRequest($"{abreviacaoPais}/{codigoPostal}", Method.GET);

            //executa a chamada
            RespostaRequest = _cliente.Execute(_requisicao);
        }

        //recebe a resposta da api na classe 'RespostaLocalização'
        public void DeserializeResposta()
            => RespostaLocalizacao = JsonConvert.DeserializeObject<RespostaLocalizacao>(RespostaRequest.Content);
    }
}
