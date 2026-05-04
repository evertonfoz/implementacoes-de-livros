using ComplementarDois_GerenteFuncionario.Model;
using System;

namespace ComplementarDois_GerenteFuncionario
{
    class Program
    {
        static void Main(string[] args)
        {
            var g1 = new Gerente() { Nome = "Gerente 1" };
            var f1 = new Funcionario() { Nome = "Funcionário 1" };

            var g2 = new Gerente() { Nome = "Gerente 2" };
            var f2 = new Funcionario() { Nome = "Funcionário 2" };

            g1.RegistrarFuncionario(f1);
            g2.RegistrarFuncionario(f2);

            g1.Funcionarios = g2.Funcionarios;
            //f1.Gerente = g2;
            //f2.Gerente = null;
            //g2.Funcionarios = null;
            //g2.Funcionarios = g1.Funcionarios;
            Console.ReadKey();
        }
    }
}
