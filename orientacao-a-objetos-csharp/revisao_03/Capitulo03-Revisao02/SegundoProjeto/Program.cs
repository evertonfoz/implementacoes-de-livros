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
        }
    }
}
