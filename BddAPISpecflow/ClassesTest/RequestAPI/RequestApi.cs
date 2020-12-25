using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BddAPISpecflow.RequestAPI
{
    public class RequestApi
    {
		private HttpClient httpClient = new HttpClient();
		private string MyUri = "http://api.publicapis.org";
		private string Parameters = "entries?category=animals&https=true";

		//utilizando Task async
		public async Task<string> TestRequest()
		{
			//Contexto
			var builder = new UriBuilder($"{MyUri}/{Parameters}");

			//Pega resposta 
			var response = await httpClient.GetAsync(builder.Uri);

			//Coloca no conteto
			var context = await response.Content.ReadAsStringAsync();
			return context;
		}

		public async Task GetResultAPI()
        {
			var response = await TestRequest();

			//https://docs.microsoft.com/pt-br/dotnet/standard/serialization/system-text-json-how-to?pivots=dotnet-5-0
			//melhorar a resposta aqui 'deserialize'
			Console.WriteLine(response.ToString());
        }
	}
}
