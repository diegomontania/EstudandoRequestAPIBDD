using System;
using TechTalk.SpecFlow;
using System.Threading.Tasks;
using Xunit;
using BddAPISpecflow.ClassesTest.RequestAPI;
using FluentAssertions;

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

        [Given(@"a uri '(.*)' e (.*) com o codigo postal (.*)")]
        public void DadoAUriEComOCodigoPostal(string url, string pais, string codigoPostal)
        {
            //utilizar regex, para remover esses caracteres posteriormente
            pais = pais.Replace("\"", "");
            codigoPostal = codigoPostal.Replace("\"", "");

            _requestApi.CallGet(url, pais, codigoPostal);
            Assert.NotNull(_requestApi.RespostaRequest);
        }

        [Given(@"se a resposta for (.*)")]
        public void DadoEARespostaFor(int number)
        {
            var statusCode = (int)_requestApi.RespostaRequest.StatusCode;
            Assert.Equal(statusCode, number);
        }

        [Given(@"o codigo do pais for (.*) e o codigo postal for (.*)")]
        public void DadoOCodigoDoPaisForEOCodigoPostalFor(string codigoPais, string codigoPostal)
        {
            //imeplementar comparacao aqui
            Console.WriteLine("");
        }


        [Then(@"exibe o resultado")]
        public void EntaoExibeOResultado()
        {
            //melhorar resultado aqui 
            var resultadoResposta = _requestApi.DeserializeResposta();
            Console.WriteLine(resultadoResposta); 
        }
    }
}
