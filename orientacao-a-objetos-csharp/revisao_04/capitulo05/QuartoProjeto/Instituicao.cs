using System.Collections.Generic;

namespace SegundoProjeto
{
    class Instituicao
    {
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }

        public HashSet<Departamento> Departamentos { get; } = new HashSet<Departamento>();

        // Método original
        public void RegistrarDepartamento(Departamento d)
        {
            Departamentos.Add(d);
        }

        // Sobrecarga adicionada no capítulo 5
        public void RegistrarDepartamento(string nome)
        {
            Departamentos.Add(new Departamento() { Nome = nome });
        }

        public int ObterQuantidadeDepartamentos()
        {
            return Departamentos.Count;
        }

        public override bool Equals(object obj)
        {
            if (obj is Instituicao instituicao)
            {
                return Nome.Equals(instituicao.Nome);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 11 + (Nome == null ? 0 : Nome.GetHashCode());
        }
    }
}
