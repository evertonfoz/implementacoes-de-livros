using System;
using System.Collections.Generic;
using System.Linq;

namespace SegundoProjeto
{
    class Turma
    {
        public PeriodoCursoEnum Periodo { get; set; }
        public TurnoTurmaEnum Turno { get; set; }
        public int QuantidadeVagas { get; set; }

        public Curso Curso { get; private set; }

        public void RegistrarCurso(Curso c)
        {
            Curso = c;
        }

        public IList<Matricula> Matriculas { get; } = new List<Matricula>();

        public void RegistrarMatricula(Matricula m)
        {
            if (Matriculas.Count >= QuantidadeVagas)
                throw new Exception("Quantidade de vagas na turma não permite mais matrículas");
            
            Matriculas.Add(m);
        }

        public override bool Equals(object obj)
        {
            if (obj is Turma turma)
            {
                return Periodo.Equals(turma.Periodo) && Turno.Equals(turma.Turno);
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 11;
            hash = (hash * 7) + Periodo.GetHashCode();
            hash = (hash * 7) + Turno.GetHashCode();
            return hash;
        }
    }
}
