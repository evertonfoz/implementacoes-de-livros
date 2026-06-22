using System;

namespace SegundoProjeto
{
    class Matricula
    {
        public Turma Turma { get; set; }
        public Aluno Aluno { get; set; }
        public DateTime DataMatricula { get; set; }

        public Matricula(Turma turma, Aluno aluno)
        {
            Turma = turma;
            Aluno = aluno;
            DataMatricula = DateTime.Now;

            turma.RegistrarMatricula(this);
            aluno.Cursos.Add(turma.Curso);
            turma.Curso.RegistrarAluno(aluno);
        }
    }
}
