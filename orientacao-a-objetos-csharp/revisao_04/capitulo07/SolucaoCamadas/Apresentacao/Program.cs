using System;
using Modelo;
using Servico;

var disciplinaServico = new DisciplinaServico();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("=== Cadastro de Disciplinas ===");
    Console.WriteLine("1 - Cadastrar disciplina");
    Console.WriteLine("2 - Listar disciplinas");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");

    var opcao = Console.ReadLine();

    if (opcao == "0")
        break;

    switch (opcao)
    {
        case "1":
            CadastrarDisciplina();
            break;

        case "2":
            ListarDisciplinas();
            break;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}

void CadastrarDisciplina()
{
    try
    {
        Console.Write("Nome da disciplina: ");
        var nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Carga horária: ");
        var cargaHorariaTexto = Console.ReadLine();

        if (!int.TryParse(cargaHorariaTexto, out var cargaHoraria))
        {
            Console.WriteLine("A carga horária informada não é válida.");
            return;
        }

        var disciplina = new Disciplina
        {
            Nome = nome,
            CargaHoraria = cargaHoraria
        };

        disciplinaServico.Inserir(disciplina);

        Console.WriteLine("Disciplina cadastrada com sucesso.");
    }
    catch (Exception exception)
    {
        Console.WriteLine($"Erro ao cadastrar disciplina: {exception.Message}");
    }
}

void ListarDisciplinas()
{
    var disciplinas = disciplinaServico.ObterTodas();

    if (disciplinas.Count == 0)
    {
        Console.WriteLine("Nenhuma disciplina cadastrada.");
        return;
    }

    Console.WriteLine();
    Console.WriteLine("Disciplinas cadastradas:");

    foreach (var disciplina in disciplinas)
    {
        Console.WriteLine($"- {disciplina.Nome} ({disciplina.CargaHoraria}h)");
    }
}
