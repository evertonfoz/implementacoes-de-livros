using System;

namespace SegundoProjeto
{
    class Program
    {
        static void Main(string[] args)
        {
            var iesUTFPR = new Instituicao() {
                Nome = "UTFPR",
                Endereco = new Endereco()
                {
                    Rua = "Brasil",
                    Numero = "1000"
                }
            };

            var iesCC = new Instituicao()
            {
                Nome = "Casa do Código",
                Endereco = new Endereco()
                {
                    Bairro = "Liberdade"
                }
            };

            var dptoEnsino = new Departamento() { Nome = "Computação" };
            var dptoAlimentos = new Departamento() { Nome = "Alimentos" };
            var dptoRevisao = new Departamento() { Nome = "Revisão Escrita" };

            iesUTFPR.RegistrarDepartamento(dptoEnsino);
            iesUTFPR.RegistrarDepartamento(dptoAlimentos);

            iesCC.RegistrarDepartamento(dptoRevisao);

            Console.WriteLine("UTFPR");
            for (int i = 0; i < iesUTFPR.ObterQuantidadeDepartamentos(); i++)
            {
                Console.WriteLine($"==> {iesUTFPR.Departamentos[i].Nome}");
            }

            Console.WriteLine("Casa do Código");
            for (int i = 0; i < iesCC.ObterQuantidadeDepartamentos(); i++)
            {
                Console.WriteLine($"==> {iesCC.Departamentos[i].Nome}");
            }
            Console.Write("Pressione qualquer tecla para continuar");
            Console.ReadKey();

            var ctAlimentos = new Graduacao() {
                Nome = "Tecnologia em Alimentos", CargaHoraria = 2000 };

            dptoAlimentos.RegistrarCurso(ctAlimentos);

            if (!dptoAlimentos.Cursos.Contains(ctAlimentos))
                dptoAlimentos.RegistrarCurso(ctAlimentos);

            dptoAlimentos.RegistrarCurso(
                new Graduacao { Nome = "Engenharia de Alimentos", CargaHoraria = 3000 });

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Cursos no departamento de {dptoAlimentos.Nome}");

            foreach (var curso in dptoAlimentos.Cursos)
            {
                Console.WriteLine($"==> {curso.Nome} ({curso.CargaHoraria}h)");
            }
            Console.WriteLine();
            Console.WriteLine(
                $"A carga horária do curso de Engenharia de Alimentos do departamento {dptoAlimentos.Nome.ToUpper()} é {dptoAlimentos.ObterCursoPorNome("Engenharia de Alimentos").CargaHoraria}h");
            Console.Write("Pressione qualquer tecla para continuar");
            Console.ReadKey();

            dptoAlimentos.FecharDepartamento();
            dptoAlimentos = null;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("O departamento de alimentos foi fechado");
            Console.ReadKey();

            Console.WriteLine();
            var cursoCC = new Graduacao() { Nome = "Ciência da Computação", CargaHoraria = 3000 };
            cursoCC.RegistrarDisciplina(new Disciplina() { Nome = "Algoritmos", CargaHoraria = 80 });
            cursoCC.RegistrarDisciplina(new Disciplina() { Nome = "Orientação a Objetos", CargaHoraria = 60 });
            cursoCC.RegistrarDisciplina(new Disciplina() { Nome = "Orientação a Objetos", CargaHoraria = 80 });

            Console.WriteLine($"O curso {cursoCC.Nome} possui {cursoCC.Disciplinas.Count} disciplinas:");
            foreach (var d in cursoCC.Disciplinas)
            {
                Console.WriteLine($"==> {d.Nome} ({d.CargaHoraria})");
            }
            Console.ReadKey();
        }
    }
}
