using System;

namespace SegundoProjeto
{
    class Program
    {
        static void Main(string[] args)
        {
            var iesUTFPR = new Instituicao()
            {
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

            var dptoEnsino = new Departamento();
            dptoEnsino.Nome = "Computação";

            var dptoAlimentos = new Departamento();
            dptoAlimentos.Nome = "Alimentos";

            var dptoRevisao = new Departamento();
            dptoRevisao.Nome = "Revisão Escrita";

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

            //dptoAlimentos.RegistrarCurso(
            //    new Curso { Nome = "Tecnologia em Alimentos", CargaHoraria = 2000 });

            //dptoAlimentos.RegistrarCurso(
            //    new Curso { Nome = "Engenharia de Alimentos", CargaHoraria = 3000 });

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Cursos no departamento de {dptoAlimentos.Nome}");

            foreach (var curso in dptoAlimentos.Cursos)
            {
                Console.WriteLine($"==> {curso.Nome} ({curso.CargaHoraria}h)");
            }
            Console.Write("Pressione qualquer tecla para continuar");
            Console.ReadKey();

            dptoAlimentos.FecharDepartamento();
            dptoAlimentos = null;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("O departamento de alimentos foi fechado");
            Console.ReadKey();

            //var ctAlimentos = new Curso()
            //{
            //    Nome = "Tecnologia em Alimentos",
            //    CargaHoraria = 2000
            //};

            //if (!dptoAlimentos.Cursos.Contains(ctAlimentos))
            //    dptoAlimentos.RegistrarCurso(ctAlimentos);

            //Console.WriteLine();
            //var cursoCC = new Curso() { Nome = "Ciência da Computação", CargaHoraria = 3000 };
            //cursoCC.RegistrarDisciplina(new Disciplina() { Nome = "Algoritmos", CargaHoraria = 80 });
            //cursoCC.RegistrarDisciplina(new Disciplina() { Nome = "Orientação a Objetos", CargaHoraria = 60 });
            //cursoCC.RegistrarDisciplina(new Disciplina() { Nome = "Orientação a Objetos", CargaHoraria = 80 });
            //cursoCC.RegistrarDisciplina(new Disciplina() { Nome = "Estrutura de Dados", CargaHoraria = 80 });
            //cursoCC.RegistrarDisciplina(new Disciplina() { Nome = "Programação para web", CargaHoraria = 80 });

            //Console.WriteLine($"O curso {cursoCC.Nome} possui {cursoCC.Disciplinas.Count} disciplinas:");
            //foreach (var d in cursoCC.Disciplinas)
            //{
            //    Console.WriteLine($"==> {d.Nome} ({d.CargaHoraria})");
            //}
            //Console.ReadKey();

            var graduacao = new Graduacao() { Nome = "Curso de Graduação" };
            var latoSensu = new LatoSensu() { Nome = "Curso de Lato Sensu" };
            var strictoSenso = new StrictoSensu() { Nome = "Curso de Stricto Sensu" };

            var repositorioCursos = new RepositorioCurso();
            repositorioCursos.Gravar(graduacao);
            repositorioCursos.Gravar(latoSensu);
            repositorioCursos.Gravar(strictoSenso);

            Console.WriteLine();
            Console.WriteLine("Cursos gravados");
            foreach (var curso in repositorioCursos.ObterTodos())
            {
                Console.WriteLine($"==> {curso.Nome} ({curso.GetType()})");
            }
            Console.Write("Pressione qualquer tecla para continuar");
            Console.ReadKey();

            var turma = new Turma()
            {
                CodigoTurma = "1",
                PeriodoCurso = PeriodoCursoEnum.Primeiro,
                TurnoTurma = TurnoTurmaEnum.Matutino
            };

            var aluno = new Aluno()
            {
                RegistroAcademico = "1",
                Nome = "Asdrubal"
            };

            var cursoCC = new Graduacao() { Nome = "Ciência da Computação", CargaHoraria = 3000 };
            cursoCC.RegistrarAluno(aluno);
            cursoCC.RegistrarTurma(turma);

            foreach (var d in cursoCC.Disciplinas)
            {
                try
                {
                    turma.RegistrarMatricula(new Matricula()
                    {
                        Aluno = aluno,
                        Disciplina = d
                    });
                }
                catch (Exception exception)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(exception.Message);
                }
            }

            Console.WriteLine("Registro de matrículas concluído");
            Console.Write("Pressione qualquer tecla para continuar");
            Console.ReadKey();
        }
    }
}
