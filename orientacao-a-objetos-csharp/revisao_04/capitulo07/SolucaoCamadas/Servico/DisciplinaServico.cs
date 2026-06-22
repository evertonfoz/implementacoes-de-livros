using System;
using System.Collections.Generic;
using Modelo;
using Persistencia;

namespace Servico
{
    public class DisciplinaServico
    {
        private readonly DisciplinaDAL disciplinaDAL = new();

        public void Inserir(Disciplina disciplina)
        {
            if (string.IsNullOrWhiteSpace(disciplina.Nome))
                throw new Exception("O nome da disciplina é obrigatório.");

            if (disciplina.CargaHoraria <= 0)
                throw new Exception("A carga horária deve ser maior que zero.");

            if (disciplinaDAL.ObterPorNome(disciplina.Nome) is not null)
                throw new Exception("Já existe uma disciplina cadastrada com esse nome.");

            disciplinaDAL.Inserir(disciplina);
        }

        public IReadOnlyList<Disciplina> ObterTodas()
        {
            return disciplinaDAL.ObterTodas();
        }
    }
}
