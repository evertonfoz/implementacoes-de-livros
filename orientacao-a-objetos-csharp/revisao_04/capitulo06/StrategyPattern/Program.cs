using System;
using StrategyPattern;

var calculador = new CalculadorDeDescontos();

var matricula = new Matricula
{
    ValorMensalidade = 1000m
};

// Aqui o polimorfismo brilha! Passamos comportamentos diferentes.
var descontoAntecipado = calculador.Calcular(matricula, new DescontoAntecipado());
var descontoMonitoria = calculador.Calcular(matricula, new DescontoMonitoria());

Console.WriteLine($"Valor da mensalidade: {matricula.ValorMensalidade:C}");
Console.WriteLine($"Desconto por pagamento antecipado: {descontoAntecipado:C}");
Console.WriteLine($"Desconto por monitoria: {descontoMonitoria:C}");
Console.WriteLine($"Valor a pagar: {(matricula.ValorMensalidade - descontoAntecipado - descontoMonitoria):C}");
