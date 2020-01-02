using System;

namespace SegundoProjeto
{
    class Matricula
    {
        public Aluno Aluno { get; set; }
        public Disciplina Disciplina { get; set; }
        public Turma Turma { get; set; }

        public override bool Equals(Object obj)
        {
            if (obj is Matricula)
            {
                Matricula m = obj as Matricula;
                return (this.Aluno.RegistroAcademico.Equals(m.Aluno.RegistroAcademico) &&
                    this.Disciplina.Nome.Equals(m.Disciplina.Nome) &&
                    this.Turma.CodigoTurma.Equals(m.Turma.CodigoTurma));
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (11 + ((this.Aluno.RegistroAcademico == null ||
                this.Disciplina.Nome == null || this.Turma == null ||
                this.Turma.CodigoTurma == null) ? 0 :
                this.Aluno.RegistroAcademico.GetHashCode() + this.Disciplina.Nome.GetHashCode() +
                this.Turma.CodigoTurma.GetHashCode()));
        }
    }
}
