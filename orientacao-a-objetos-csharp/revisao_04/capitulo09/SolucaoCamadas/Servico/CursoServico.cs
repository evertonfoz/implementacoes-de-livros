using System;
using System.Collections.Generic;
using Modelo;
using Persistencia;

namespace Servico
{
    public class CursoServico
    {
        private readonly CursoDAL cursoDAL = new();

        public void Gravar(Curso curso)
        {
            if (string.IsNullOrWhiteSpace(curso.Nome))
                throw new Exception("O nome do curso é obrigatório.");

            if (curso.CargaHoraria <= 0)
                throw new Exception("A carga horária deve ser maior que zero.");

            cursoDAL.Gravar(curso);
        }

        public List<Curso> ObterTodos()
        {
            return cursoDAL.ObterTodos();
        }

        public Curso? ObterPorId(long id)
        {
            return cursoDAL.ObterPorId(id);
        }

        public void Remover(Curso curso)
        {
            cursoDAL.Remover(curso);
        }
    }
}
