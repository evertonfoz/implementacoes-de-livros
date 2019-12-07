using System;
using System.Collections.Generic;
using System.Linq;

namespace SegundoProjeto
{
    abstract class Curso
    {
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public HashSet<Disciplina> Disciplinas { get; } = new HashSet<Disciplina>();
        public HashSet<Professor> Professores { get; } = new HashSet<Professor>();

        public void RegistrarProfessor(Professor p)
        {
            this.Professores.Add(p);
            p.Cursos.Add(this);
        }

        public void RegistrarDisciplina(Disciplina d)
        {
            Disciplinas.Add(d);
        }

        public int ObterQuantidadeDiscilinasDoCurso()
        {
            return Disciplinas.Count;
        }

        public Disciplina ObterDisciplinaPorNome(string nome)
        {
            return Disciplinas.Where<Disciplina>(n => n.Nome.Equals(nome)).FirstOrDefault();
        }

        public override bool Equals(Object obj)
        {
            if (obj is Curso)
            {
                Curso c = obj as Curso;
                return this.Nome.Equals(c.Nome);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (11 + this.Nome == null ? 0 : this.Nome.GetHashCode());
        }
    }
}