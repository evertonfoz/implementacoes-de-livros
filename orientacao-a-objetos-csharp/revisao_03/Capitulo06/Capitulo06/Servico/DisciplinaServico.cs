using Modelo;
using Persistencia;
using System.Collections.Generic;

namespace Servico
{
    public class DisciplinaServico
    {
        private DisciplinaDAL disciplinaDAL = new DisciplinaDAL();

        public void Inserir(Disciplina disciplina)
        {
            disciplinaDAL.Inserir(disciplina);
        }

        public List<Disciplina> ObterTodas()
        {
            return disciplinaDAL.ObterTodas();
        }
    }
}
