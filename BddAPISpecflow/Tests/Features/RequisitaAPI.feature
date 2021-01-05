#language: pt-br

Funcionalidade: RequisitaAPI
	Enviar um código de pais e codigo postal
	E receber suas informações via json

@mytag
Cenario: 1) Requisitar informações de uma api
	Dado a url 'http://api.zippopotam.us/' e <AbreviacaoDoPais> com o codigo postal <CodigoPostal>
	E se a resposta for 200
	Entao o <Pais> deve conter <AbreviacaoDoPais>

Exemplos: 
	| Pais            | AbreviacaoDoPais | CodigoPostal |
	| "United States" | "US"		     | "90210"      |
	| "Brazil"        | "BR"             | "01000-000"  |