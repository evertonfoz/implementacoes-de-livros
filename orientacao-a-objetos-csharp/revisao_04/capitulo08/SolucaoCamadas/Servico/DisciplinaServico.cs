using System;
using System.Collections.Generic;
using Modelo;
using Persistencia;

namespace Servico
{
    public class DisciplinaServico
    {
        private readonly DisciplinaDAL disciplinaDAL = new DisciplinaDAL();

        public void Gravar(Disciplina disciplina)
        {
            if (string.IsNullOrWhiteSpace(disciplina.Nome))
                throw new Exception("O nome da disciplina é obrigatório.");

            if (disciplina.CargaHoraria <= 0)
                throw new Exception("A carga horária deve ser maior que zero.");

            disciplinaDAL.Gravar(disciplina);
        }

        public List<Disciplina> ObterTodas()
        {
            return disciplinaDAL.ObterTodas();
        }

        public Disciplina? ObterPorId(long id)
        {
            return disciplinaDAL.ObterPorId(id);
        }

        public void Remover(Disciplina disciplina)
        {
            disciplinaDAL.Remover(disciplina);
        }
    }
}
