using Modelo;
using System.Collections.Generic;

namespace Persistencia
{
    public class DisciplinaDAL
    {
        public List<Disciplina> Repository { get; set; } = new List<Disciplina>();

        public void Inserir(Disciplina disciplina)
        {
            this.Repository.Add(disciplina);
        }

        public List<Disciplina> ObterTodas()
        {
            return this.Repository;
        }
    }
}
