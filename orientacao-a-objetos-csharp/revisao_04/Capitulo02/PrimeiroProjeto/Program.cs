// Demonstração de argumentos de linha de comando
// Execute com: dotnet run -- Casa do Código
for (int i = 0; i < args.Length; i++)
{
    System.Console.WriteLine(args[i]);
}

Instituicao instituicao = new Instituicao();
Console.Write("Informe o nome da instituição: ");
instituicao.Nome = Console.ReadLine();

Console.Write("Informe o endereço da instituição: ");
instituicao.Endereco = Console.ReadLine();

Console.WriteLine("===================================");
Console.WriteLine($"Obrigado por informar os dados para a {instituicao.Nome}");
Console.Write("Pressione ENTER para encerrar.");
Console.ReadLine();
