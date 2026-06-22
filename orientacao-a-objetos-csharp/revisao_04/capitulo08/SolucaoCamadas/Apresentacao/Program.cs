using System;
using Modelo;
using Servico;
using Persistencia;

// Garante que o banco de dados e a tabela existam
BancoInicializador.Inicializar();

var disciplinaServico = new DisciplinaServico();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("=== Cadastro de Disciplinas ===");
    Console.WriteLine("1 - Cadastrar disciplina");
    Console.WriteLine("2 - Listar disciplinas");
    Console.WriteLine("3 - Pesquisar disciplina");
    Console.WriteLine("4 - Alterar disciplina");
    Console.WriteLine("5 - Remover disciplina");
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
        case "3":
            PesquisarDisciplina();
            break;
        case "4":
            AlterarDisciplina();
            break;
        case "5":
            RemoverDisciplina();
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

        disciplinaServico.Gravar(disciplina);

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
        Console.WriteLine($"- ID: {disciplina.DisciplinaId} | Nome: {disciplina.Nome} ({disciplina.CargaHoraria}h)");
    }
}

void PesquisarDisciplina()
{
    Console.Write("Digite o ID da disciplina: ");
    if (!long.TryParse(Console.ReadLine(), out var id))
    {
        Console.WriteLine("ID inválido.");
        return;
    }

    var disciplina = disciplinaServico.ObterPorId(id);
    if (disciplina == null)
    {
        Console.WriteLine("Disciplina não encontrada.");
    }
    else
    {
        Console.WriteLine($"Disciplina encontrada: {disciplina.Nome} ({disciplina.CargaHoraria}h)");
    }
}

void AlterarDisciplina()
{
    Console.Write("Digite o ID da disciplina que deseja alterar: ");
    if (!long.TryParse(Console.ReadLine(), out var id))
    {
        Console.WriteLine("ID inválido.");
        return;
    }

    var disciplinaAtual = disciplinaServico.ObterPorId(id);
    if (disciplinaAtual == null)
    {
        Console.WriteLine("Disciplina não encontrada.");
        return;
    }

    try
    {
        Console.Write($"Novo nome (Atual: {disciplinaAtual.Nome}): ");
        var nome = Console.ReadLine() ?? string.Empty;

        Console.Write($"Nova carga horária (Atual: {disciplinaAtual.CargaHoraria}): ");
        var cargaHorariaTexto = Console.ReadLine();

        if (!int.TryParse(cargaHorariaTexto, out var cargaHoraria))
        {
            Console.WriteLine("A carga horária informada não é válida.");
            return;
        }

        disciplinaAtual.Nome = string.IsNullOrWhiteSpace(nome) ? disciplinaAtual.Nome : nome;
        disciplinaAtual.CargaHoraria = cargaHoraria;

        disciplinaServico.Gravar(disciplinaAtual);

        Console.WriteLine("Disciplina atualizada com sucesso.");
    }
    catch (Exception exception)
    {
        Console.WriteLine($"Erro ao alterar disciplina: {exception.Message}");
    }
}

void RemoverDisciplina()
{
    Console.Write("Digite o ID da disciplina que deseja remover: ");
    if (!long.TryParse(Console.ReadLine(), out var id))
    {
        Console.WriteLine("ID inválido.");
        return;
    }

    var disciplina = disciplinaServico.ObterPorId(id);
    if (disciplina == null)
    {
        Console.WriteLine("Disciplina não encontrada.");
        return;
    }

    try
    {
        disciplinaServico.Remover(disciplina);
        Console.WriteLine("Disciplina removida com sucesso.");
    }
    catch (Exception exception)
    {
        Console.WriteLine($"Erro ao remover disciplina: {exception.Message}");
    }
}
