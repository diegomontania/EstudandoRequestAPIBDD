#language: pt-br

Funcionalidade: RequisitaAPI

@mytag
Cenario: 1) Requisitar informações de uma api
	Dado a uri
	E e obtiver resposta ok
	Entao exibe o resultado