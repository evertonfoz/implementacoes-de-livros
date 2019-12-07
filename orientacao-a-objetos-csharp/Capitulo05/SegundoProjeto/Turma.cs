using System;
using System.Collections.Generic;

namespace SegundoProjeto
{
    class Turma
    {
        private Curso _Curso;

        public string CodigoTurma { get; set; }
        public PeriodoCursoEnum PeriodoCurso { get; set; }
        public TurnoTurmaEnum TurnoTurma { get; set; }
        public Curso Curso { get { return _Curso; } }
        public HashSet<Matricula> Matriculas { get; } = new HashSet<Matricula>();

        public void RegistrarMatricula(Matricula m)
        {
            if (this.Matriculas.Count > 2)
                throw new Exception("Turma já não dispõe de vagas");
            this.Matriculas.Add(m);
            m.Turma = this;
        }

        public void RegistrarCurso(Curso curso)
        {
            this._Curso = curso;
        }

        public override bool Equals(Object obj)
        {
            if (obj is Turma)
            {
                Turma t = obj as Turma;
                return this.CodigoTurma.Equals(t.CodigoTurma);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (11 + this.CodigoTurma == null ? 0 : this.CodigoTurma.GetHashCode());
        }
    }
}
