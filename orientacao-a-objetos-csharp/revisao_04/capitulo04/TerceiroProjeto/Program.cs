using TerceiroProjeto;

// =============================================
// Setup: Instituições e Departamentos (Cap. 3)
// =============================================
var iesUTFPR = new Instituicao
{
    Nome = "UTFPR",
    Endereco = new Endereco { Rua = "Brasil", Numero = "1000" }
};

var dptoEnsino    = new Departamento("Computação");
var dptoAlimentos = new Departamento("Alimentos");

iesUTFPR.RegistrarDepartamento(dptoEnsino);
iesUTFPR.RegistrarDepartamento(dptoAlimentos);

// =============================================
// Novidade Cap. 4: Coleções — IList<Curso>
// =============================================
dptoAlimentos.RegistrarCurso(
    new Curso { Nome = "Tecnologia em Alimentos", CargaHoraria = 2000 });
dptoAlimentos.RegistrarCurso(
    new Curso { Nome = "Engenharia de Alimentos", CargaHoraria = 3000 });

Console.WriteLine();
Console.WriteLine($"Cursos no departamento de {dptoAlimentos.Nome}");
foreach (var curso in dptoAlimentos.Cursos)
{
    Console.WriteLine($"==> {curso.Nome} ({curso.CargaHoraria}h)");
}

// =============================================
// Identidade com Equals/Contains
// =============================================
var ctAlimentos = new Curso { Nome = "Tecnologia em Alimentos", CargaHoraria = 2000 };
if (!dptoAlimentos.Cursos.Contains(ctAlimentos))
    dptoAlimentos.RegistrarCurso(ctAlimentos);
else
    Console.WriteLine($"\n[Identidade] Curso '{ctAlimentos.Nome}' já existe — duplicata bloqueada.");

// =============================================
// LINQ: recuperação por nome
// =============================================
var cursoEncontrado = dptoAlimentos.ObterCursoPorNome("Engenharia de Alimentos");
Console.WriteLine($"\n[LINQ] Curso encontrado: {cursoEncontrado?.Nome} ({cursoEncontrado?.CargaHoraria}h)");

// =============================================
// FecharDepartamento + while
// =============================================
dptoAlimentos.FecharDepartamento();
Console.WriteLine();
Console.WriteLine($"Departamento de Alimentos encerrado. Cursos restantes: {dptoAlimentos.ObterQuantidadeDeCursos()}");

// =============================================
// Agregação: Curso → HashSet<Disciplina>
// HashSet evita duplicatas por identidade (Equals/GetHashCode)
// =============================================
Console.WriteLine();
var cursoCC = new Curso { Nome = "Ciência da Computação", CargaHoraria = 3000 };
cursoCC.RegistrarDisciplina(new Disciplina { Nome = "Algoritmos", CargaHoraria = 80 });
cursoCC.RegistrarDisciplina(new Disciplina { Nome = "Orientação a Objetos", CargaHoraria = 60 });
cursoCC.RegistrarDisciplina(new Disciplina { Nome = "Orientação a Objetos", CargaHoraria = 80 }); // duplicata bloqueada
cursoCC.RegistrarDisciplina(new Disciplina { Nome = "Estrutura de Dados", CargaHoraria = 80 });
cursoCC.RegistrarDisciplina(new Disciplina { Nome = "Programação para web", CargaHoraria = 80 });

dptoEnsino.RegistrarCurso(cursoCC);

Console.WriteLine($"O curso {cursoCC.Nome} possui {cursoCC.Disciplinas.Count} disciplinas:");
foreach (var d in cursoCC.Disciplinas)
{
    Console.WriteLine($"==> {d.Nome} ({d.CargaHoraria}h)");
}

// =============================================
// LINQ: busca de disciplina por nome
// =============================================
var discEncontrada = cursoCC.ObterDisciplinaPorNome("Algoritmos");
Console.WriteLine($"\n[LINQ] Disciplina encontrada: {discEncontrada?.Nome}");

Console.Write("\nPressione qualquer tecla para encerrar.");
Console.ReadKey();
