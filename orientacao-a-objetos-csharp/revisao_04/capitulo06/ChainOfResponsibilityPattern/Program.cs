using System;
using ChainOfResponsibilityPattern;

var matricula = new Matricula
{
    TemRegulares = true,
    TemEnriquecimento = true,
    TemDependencia = true
};

new CalculadorDeMensalidade().Calcular(matricula);

Console.WriteLine($"Valor total da mensalidade: {matricula.ValorMensalidade:C}");
