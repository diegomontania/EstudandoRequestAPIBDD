#language: pt-br

Funcionalidade: RequisitaAPI
	Enviar um código de pais e codigo postal
	E receber suas informações via json

@mytag
Cenario: 1) Requisitar informações de uma api
	Dado a uri 'http://api.zippopotam.us/' e <CodigoPais> com o codigo postal <CodigoPostal>
	E se a resposta for 200
	E o codigo do pais for <CodigoPais> e o codigo postal for <CodigoPostal>
	Entao exibe o resultado

Exemplos: 
	| CodigoPais | CodigoPostal |
	| "US"       | "90210"      |
	| "BR"       | "01000-000"  |