using TechTalk.SpecFlow;
using Xunit;
using BddAPISpecflow.Helpers.RequestAPI;
using System;
using Xunit.Abstractions;

namespace BddAPISpecflow.Steps
{
    [Binding]
    public class RequisitaAPIStepsDefinitions
    {
        //utilizando outPutHelper do xUnit no Specflow 
        ///<Summary>
        /// Maiores informações <see href="https://docs.specflow.org/projects/specflow/en/latest/Integrations/xUnit.html">xUnit e Specflow</see>
        ///</Summary>
        private readonly ITestOutputHelper _outPutHelper;

        //utilizando classe para fazer a requisição da api separadamente do teste
        private readonly ResquestApiRestSharp _requestApi;

        public RequisitaAPIStepsDefinitions(ResquestApiRestSharp requestApi, ITestOutputHelper testOutputHelper)
        {
            _outPutHelper = testOutputHelper;
            _requestApi = requestApi;
        }

        [Given(@"a url '(.*)' e (.*) com o codigo postal (.*)")]
        public void DadoAUrlEComOCodigoPostal(string url, string abreviacaoPais, string codigoPostal)
        {
            //remove caracteres que ficam da string json
            abreviacaoPais = RemoveCaraceteres(abreviacaoPais);
            codigoPostal = RemoveCaraceteres(codigoPostal);

            _requestApi.ChamaAPI(url, abreviacaoPais, codigoPostal);
            Assert.NotNull(_requestApi.RespostaRequest);
        }

        [Given(@"se a resposta for (.*)")]
        public void DadoEARespostaFor(int number)
        {
            var statusCode = (int)_requestApi.RespostaRequest.StatusCode;
            Assert.Equal(statusCode, number);
        }

        [Given(@"o (.*) deve conter (.*)")]
        public void EntaoODeveConter(string pais, string abreviacaoPais)
        {
            pais = RemoveCaraceteres(pais);
            abreviacaoPais = RemoveCaraceteres(abreviacaoPais);

            _requestApi.DeserializeResposta();

            Assert.Contains(pais, _requestApi.RespostaLocalizacao.Pais);
            Assert.Contains(abreviacaoPais, _requestApi.RespostaLocalizacao.PaisAbreviacao);
        }

        [Then(@"o primeiro (.*) deste pais deve retornar uma '(.*)' e '(.*)'")]
        public void EntaoOPrimeiroDestePaisDeveRetornarUmaE(string estado, string latitude, string longitude)
        {
            estado = _requestApi.RespostaLocalizacao.Lugares[0].Estado;
            latitude = _requestApi.RespostaLocalizacao.Lugares[0].Latitude;
            longitude = _requestApi.RespostaLocalizacao.Lugares[0].Longitude;

            //utilizando outPutHelper do xUnit no Specflow
            _outPutHelper.WriteLine(estado);
            _outPutHelper.WriteLine(latitude);
            _outPutHelper.WriteLine(longitude);
        }

        //limpa string passada pela '.feature'
        private string RemoveCaraceteres(string valor) => valor.Replace("\"", "");
    }
}
