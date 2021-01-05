using System;
using TechTalk.SpecFlow;
using Xunit;
using BddAPISpecflow.Helpers.RequestAPI;

namespace BddAPISpecflow.Steps
{
    [Binding]
    public class RequisitaAPIStepsDefinitions
    {
        private readonly ResquestApiRestSharp _requestApi;

        public string RespostaApi { get; set; }

        public RequisitaAPIStepsDefinitions(ResquestApiRestSharp requestApi)
        {
            _requestApi = requestApi;
        }

        [Given(@"a url '(.*)' e (.*) com o codigo postal (.*)")]
        public void DadoAUrlEComOCodigoPostal(string url, string abreviacaoPais, string codigoPostal)
        {
            //remove caracteres que ficam da string json
            abreviacaoPais = abreviacaoPais.Replace("\"", "");
            codigoPostal = codigoPostal.Replace("\"", "");

            _requestApi.ChamaAPI(url, abreviacaoPais, codigoPostal);
            Assert.NotNull(_requestApi.RespostaRequest);
        }

        [Given(@"se a resposta for (.*)")]
        public void DadoEARespostaFor(int number)
        {
            var statusCode = (int)_requestApi.RespostaRequest.StatusCode;
            Assert.Equal(statusCode, number);
        }

        [Then(@"o (.*) deve conter (.*)")]
        public void EntaoODeveConter(string pais, string abreviacaoPais)
        {
            pais = pais.Replace("\"", "");
            abreviacaoPais = abreviacaoPais.Replace("\"", "");

            _requestApi.DeserializeResposta();

            Assert.Contains(pais, _requestApi.RespostaLocalizacao.Pais);
            Assert.Contains(abreviacaoPais, _requestApi.RespostaLocalizacao.PaisAbreviacao);
        }
    }
}
