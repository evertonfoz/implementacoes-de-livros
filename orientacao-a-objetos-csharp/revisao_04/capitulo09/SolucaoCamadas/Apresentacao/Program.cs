using System;
using Modelo;
using Servico;
using Persistencia;
using Microsoft.EntityFrameworkCore;

// Aplica as migrations pendentes e garante que o banco está atualizado
using (var context = new EFContext())
{
    context.Database.Migrate();
}

var cursoServico = new CursoServico();
var disciplinaServico = new DisciplinaServico();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("=== Sistema de Gestão de Cursos ===");
    Console.WriteLine("1 - Cadastrar curso");
    Console.WriteLine("2 - Listar cursos");
    Console.WriteLine("3 - Alterar curso");
    Console.WriteLine("4 - Remover curso");
    Console.WriteLine("--------");
    Console.WriteLine("5 - Cadastrar disciplina");
    Console.WriteLine("6 - Listar disciplinas");
    Console.WriteLine("7 - Alterar disciplina");
    Console.WriteLine("8 - Remover disciplina");
    Console.WriteLine("--------");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");

    var opcao = Console.ReadLine();

    if (opcao == "0")
        break;

    switch (opcao)
    {
        case "1": CadastrarCurso(); break;
        case "2": ListarCursos(); break;
        case "3": AlterarCurso(); break;
        case "4": RemoverCurso(); break;
        case "5": CadastrarDisciplina(); break;
        case "6": ListarDisciplinas(); break;
        case "7": AlterarDisciplina(); break;
        case "8": RemoverDisciplina(); break;
        default: Console.WriteLine("Opção inválida."); break;
    }
}

// --- Funções de Curso ---

void CadastrarCurso()
{
    try
    {
        Console.Write("Nome do curso: ");
        var nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Carga horária total: ");
        if (!int.TryParse(Console.ReadLine(), out var cargaHoraria))
        {
            Console.WriteLine("A carga horária informada não é válida.");
            return;
        }

        cursoServico.Gravar(new Curso { Nome = nome, CargaHoraria = cargaHoraria });
        Console.WriteLine("Curso cadastrado com sucesso.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao cadastrar curso: {ex.Message}");
    }
}

void ListarCursos()
{
    var cursos = cursoServico.ObterTodos();

    if (cursos.Count == 0)
    {
        Console.WriteLine("Nenhum curso cadastrado.");
        return;
    }

    Console.WriteLine();
    Console.WriteLine("Cursos cadastrados:");

    foreach (var curso in cursos)
    {
        Console.WriteLine($"- ID: {curso.CursoId} | Nome: {curso.Nome} ({curso.CargaHoraria}h)");
    }
}

void AlterarCurso()
{
    Console.Write("Digite o ID do curso que deseja alterar: ");
    if (!long.TryParse(Console.ReadLine(), out var id))
    {
        Console.WriteLine("ID inválido.");
        return;
    }

    var curso = cursoServico.ObterPorId(id);
    if (curso == null)
    {
        Console.WriteLine("Curso não encontrado.");
        return;
    }

    try
    {
        Console.Write($"Novo nome (Atual: {curso.Nome}): ");
        var novoNome = Console.ReadLine() ?? string.Empty;

        Console.Write($"Nova carga horária (Atual: {curso.CargaHoraria}): ");
        if (!int.TryParse(Console.ReadLine(), out var novaCarga))
        {
            Console.WriteLine("A carga horária informada não é válida.");
            return;
        }

        curso.Nome = string.IsNullOrWhiteSpace(novoNome) ? curso.Nome : novoNome;
        curso.CargaHoraria = novaCarga;

        cursoServico.Gravar(curso);
        Console.WriteLine("Curso atualizado com sucesso.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao alterar curso: {ex.Message}");
    }
}

void RemoverCurso()
{
    Console.Write("Digite o ID do curso que deseja remover: ");
    if (!long.TryParse(Console.ReadLine(), out var id))
    {
        Console.WriteLine("ID inválido.");
        return;
    }

    var curso = cursoServico.ObterPorId(id);
    if (curso == null)
    {
        Console.WriteLine("Curso não encontrado.");
        return;
    }

    try
    {
        cursoServico.Remover(curso);
        Console.WriteLine("Curso removido com sucesso.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao remover curso: {ex.Message}");
    }
}

// --- Funções de Disciplina ---

void CadastrarDisciplina()
{
    var cursos = disciplinaServico.ObterCursosDisponiveis();

    if (cursos.Count == 0)
    {
        Console.WriteLine("Nenhum curso cadastrado. Cadastre um curso antes de adicionar disciplinas.");
        return;
    }

    Console.WriteLine();
    Console.WriteLine("Cursos disponíveis:");

    foreach (var curso in cursos)
    {
        Console.WriteLine($"  ID: {curso.CursoId} | {curso.Nome}");
    }

    try
    {
        Console.Write("ID do curso: ");
        if (!long.TryParse(Console.ReadLine(), out var cursoId))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        Console.Write("Nome da disciplina: ");
        var nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Carga horária: ");
        if (!int.TryParse(Console.ReadLine(), out var cargaHoraria))
        {
            Console.WriteLine("A carga horária informada não é válida.");
            return;
        }

        disciplinaServico.Gravar(new Disciplina
        {
            Nome = nome,
            CargaHoraria = cargaHoraria,
            CursoId = cursoId
        });

        Console.WriteLine("Disciplina cadastrada com sucesso.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao cadastrar disciplina: {ex.Message}");
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
        var nomeCurso = disciplina.Curso?.Nome ?? "Sem curso";
        Console.WriteLine($"- ID: {disciplina.DisciplinaId} | {disciplina.Nome} ({disciplina.CargaHoraria}h) — Curso: {nomeCurso}");
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

    var disciplina = disciplinaServico.ObterPorId(id);
    if (disciplina == null)
    {
        Console.WriteLine("Disciplina não encontrada.");
        return;
    }

    try
    {
        Console.Write($"Novo nome (Atual: {disciplina.Nome}): ");
        var novoNome = Console.ReadLine() ?? string.Empty;

        Console.Write($"Nova carga horária (Atual: {disciplina.CargaHoraria}): ");
        if (!int.TryParse(Console.ReadLine(), out var novaCarga))
        {
            Console.WriteLine("A carga horária informada não é válida.");
            return;
        }

        disciplina.Nome = string.IsNullOrWhiteSpace(novoNome) ? disciplina.Nome : novoNome;
        disciplina.CargaHoraria = novaCarga;

        disciplinaServico.Gravar(disciplina);
        Console.WriteLine("Disciplina atualizada com sucesso.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao alterar disciplina: {ex.Message}");
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
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao remover disciplina: {ex.Message}");
    }
}
