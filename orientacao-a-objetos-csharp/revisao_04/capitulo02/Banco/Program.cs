using Complementar_Um_Banco;

// Prática para o leitor: instancie a classe Banco,
// informe o Numero e Nome e exiba-os no console.

Banco banco = new Banco();
Console.Write("Informe o número do banco: ");
banco.Numero = Console.ReadLine();

Console.Write("Informe o nome do banco: ");
banco.Nome = Console.ReadLine();

Console.WriteLine("===================================");
Console.WriteLine($"Banco: {banco.Numero} - {banco.Nome}");
Console.Write("Pressione ENTER para encerrar.");
Console.ReadLine();
