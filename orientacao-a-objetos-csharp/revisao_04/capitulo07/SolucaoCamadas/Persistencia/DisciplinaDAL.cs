using System;
using System.Collections.Generic;
using System.Linq;
using Modelo;

namespace Persistencia
{
    public class DisciplinaDAL
    {
        private readonly List<Disciplina> disciplinas = new();

        public void Inserir(Disciplina disciplina)
        {
            disciplinas.Add(disciplina);
        }

        public IReadOnlyList<Disciplina> ObterTodas()
        {
            return disciplinas.AsReadOnly();
        }

        public Disciplina? ObterPorNome(string nome)
        {
            return disciplinas.FirstOrDefault(d => 
                d.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }
    }
}
