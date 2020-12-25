using BddAPISpecflow.Logica;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace BddAPISpecflow.Steps
{
    [Binding]
    public sealed class CalcuradoraStepsDefinitions
    {
        //Contexto
        private readonly Calculadora _calculadora;

        //propriedade para armazenar o resultado
        public int Resultado { get; set; }

        public CalcuradoraStepsDefinitions(Calculadora calculadora)
        {
            //instancia contexto
            _calculadora = calculadora;
        }

        [Given(@"primeiro numero e (.*)")]
        public void DadoPrimeiroNumeroE(int numero1)
        {
            _calculadora.Numero1 = numero1;
        }
        
        [Given(@"segundo numero e (.*)")]
        public void DadoSegundoNumeroE(int numero2)
        {
            _calculadora.Numero2 = numero2;
        }
        
        [When(@"os dois numeros forem somados")]
        public void QuandoOsDoisNumerosForemSomados()
        {
            //TODO: implement act (action) logic
            Resultado = _calculadora.Soma();
        }
        
        [Then(@"o resultado deve ser (.*)")]
        public void EntaoOResultadoDeveSer(int resultado)
        {
            //TODO: implement assert (verification) logic
            Assert.Equal(Resultado, resultado);
        }
    }
}
