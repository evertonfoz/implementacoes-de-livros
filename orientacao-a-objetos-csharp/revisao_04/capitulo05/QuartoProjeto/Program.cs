using System;

namespace SegundoProjeto
{
    class Program
    {
        static void Main(string[] args)
        {
            var fatec = new Instituicao() { Nome = "FATEC", Endereco = new Endereco() { Bairro = "Bairro", Numero = "100", Rua = "Rua" } };

            // Usando a sobrecarga do método criada no cap. 5
            fatec.RegistrarDepartamento("Computacao");
            fatec.RegistrarDepartamento("Administracao");

            Console.WriteLine($"FATEC possui {fatec.ObterQuantidadeDepartamentos()} departamentos");

            // Testando herança e repositórios
            var uem = new Instituicao() { Nome = "UEM", Endereco = new Endereco() { Bairro = "Jd. Univ", Numero = "1000", Rua = "Av. Colombo" } };
            
            var dptoInformatica = new Departamento() { Nome = "Informatica" };
            uem.RegistrarDepartamento(dptoInformatica);

            var informatica = new Graduacao() { Nome = "Sistemas de Informação", CargaHoraria = 3000, Semestres = 8 };
            var mestrado = new StrictoSensu() { Nome = "Ciência da Computação", CargaHoraria = 400 };

            dptoInformatica.RegistrarCurso(informatica);
            dptoInformatica.RegistrarCurso(mestrado);

            // Testando a lógica de Vagas de Turma e Exceções
            var turmaSI = new Turma() { 
                Periodo = PeriodoCursoEnum.Primeiro, 
                Turno = TurnoTurmaEnum.Noturno, 
                QuantidadeVagas = 2 // Forçando limite baixo para teste
            };
            informatica.RegistrarTurma(turmaSI);

            var a1 = new Aluno() { Nome = "Everton", RA = "1" };
            var a2 = new Aluno() { Nome = "Carlos", RA = "2" };
            var a3 = new Aluno() { Nome = "Zaqueu", RA = "3" }; // Este causará erro por limite de vagas

            try
            {
                new Matricula(turmaSI, a1);
                Console.WriteLine($"Aluno {a1.Nome} matriculado.");
                new Matricula(turmaSI, a2);
                Console.WriteLine($"Aluno {a2.Nome} matriculado.");
                new Matricula(turmaSI, a3);
                Console.WriteLine($"Aluno {a3.Nome} matriculado."); // Não chegará aqui
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao matricular {a3.Nome}: {ex.Message}");
            }

            Console.WriteLine($"A turma {turmaSI.Turno} do {turmaSI.Periodo}º período de {turmaSI.Curso.Nome} possui {turmaSI.Matriculas.Count} matrículas.");
            Console.WriteLine($"O aluno {a1.Nome} está matriculado em {a1.Cursos.Count} curso(s).");
        }
    }
}
