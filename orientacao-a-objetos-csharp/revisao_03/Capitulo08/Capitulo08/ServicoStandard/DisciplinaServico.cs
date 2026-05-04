using Modelo;
using Persistencia;
using System.Collections.Generic;

namespace Servico
{
    public class DisciplinaServico
    {
        private DisciplinaDAL disciplinaDAL = new DisciplinaDAL();
        public IList<Disciplina> TodosAsDisciplinas()
        {
            return disciplinaDAL.TodosAsDisciplinas();
        }

        public void Gravar(Disciplina disciplina)
        {
            disciplinaDAL.Gravar(disciplina);
        }

        public Disciplina ObterPorId(long disciplinaID)
        {
            return disciplinaDAL.ObterPorId(disciplinaID);
        }

        public void Remover(long disciplinaID)
        {
            disciplinaDAL.Remover(disciplinaID);
        }

    }
}
