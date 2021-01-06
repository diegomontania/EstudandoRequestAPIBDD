#language: pt-br

Funcionalidade: RequisitaAPI
	Enviar um código de pais e codigo postal
	E receber suas informações via json

@mytag
Cenario: 1) Requisitar informações de uma api
	Dado a url 'http://api.zippopotam.us/' e <AbreviacaoDoPais> com o codigo postal <CodigoPostal>
	E se a resposta for 200
	E o <Pais> deve conter <AbreviacaoDoPais>
	Entao o primeiro <Estado> deste pais deve retornar uma 'latitude' e 'longitude'

Exemplos: 
	| Pais            | AbreviacaoDoPais | Estado       | CodigoPostal |
	| "United States" | "US"             | "California" | "90210"      |
	| "Brazil"        | "BR"             | "Sao Paulo"  | "01000-000"  |