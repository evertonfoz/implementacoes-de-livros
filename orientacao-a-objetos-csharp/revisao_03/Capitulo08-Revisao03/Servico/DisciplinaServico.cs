using Modelo;
using Persistencia;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Servico
{
    public class DisciplinaServico
    {
        private DisciplinaDAL disciplinaDAL;
        public DisciplinaServico(SqlConnection connection)
        {
            disciplinaDAL = new DisciplinaDAL(connection);
        }
        public void Gravar(Disciplina disciplina)
        {
            disciplinaDAL.Gravar(disciplina);
        }
        public List<Disciplina> ObterTodas()
        {
            return disciplinaDAL.ObterTodas();
        }
        public Disciplina ObterPorId(long id)
        {
            return disciplinaDAL.ObterPorId(id);
        }
        public void Remover(Disciplina disciplina)
        {
            disciplinaDAL.Remover(disciplina);
        }
    }
}
