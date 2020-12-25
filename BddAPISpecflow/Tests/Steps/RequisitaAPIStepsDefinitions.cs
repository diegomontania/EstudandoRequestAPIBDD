using System;
using TechTalk.SpecFlow;
using BddAPISpecflow.RequestAPI;
using System.Threading.Tasks;
using Xunit;

namespace BddAPISpecflow.Steps
{
    [Binding]
    public class RequisitaAPIStepsDefinitions
    {
        private readonly RequestApi _requestApi;

        public string RespostaApi { get; set; }

        public RequisitaAPIStepsDefinitions(RequestApi requestApi)
        {
            _requestApi = requestApi;
        }

        [Given(@"a uri")]
        public void DadoAUri()
        {
            Console.WriteLine("oi");
        }
        
        [Given(@"e obtiver resposta ok")]
        public async Task<string> DadoEObtiverRespostaOk()
        {
            RespostaApi = await _requestApi.TestRequest();
            Assert.NotNull(RespostaApi);
            return RespostaApi; /* melhorar a resposta aqui */
        }

        [Then(@"exibe o resultado")]
        public void EntaoExibeOResultado()
        {
            Console.WriteLine(RespostaApi.ToString()); 
        }
    }
}
