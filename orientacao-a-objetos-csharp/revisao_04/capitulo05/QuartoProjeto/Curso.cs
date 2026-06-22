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
        public HashSet<Turma> Turmas { get; } = new HashSet<Turma>();
        public HashSet<Aluno> Alunos { get; } = new HashSet<Aluno>();

        public void RegistrarProfessor(Professor p)
        {
            Professores.Add(p);
            p.Cursos.Add(this);
        }

        public virtual void RegistrarDisciplina(Disciplina d)
        {
            Disciplinas.Add(d);
        }

        public int ObterQuantidadeDisciplinasDoCurso()
        {
            return Disciplinas.Count;
        }

        public Disciplina ObterDisciplinaPorNome(string nome)
        {
            return Disciplinas.FirstOrDefault(d => d.Nome.Equals(nome));
        }

        public void RegistrarTurma(Turma t)
        {
            Turmas.Add(t);
            t.RegistrarCurso(this);
        }

        public void RegistrarAluno(Aluno a)
        {
            Alunos.Add(a);
            a.Cursos.Add(this);
        }

        public override bool Equals(object obj)
        {
            if (obj is Curso curso)
            {
                return Nome.Equals(curso.Nome);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 11 + (Nome == null ? 0 : Nome.GetHashCode());
        }
    }
}
