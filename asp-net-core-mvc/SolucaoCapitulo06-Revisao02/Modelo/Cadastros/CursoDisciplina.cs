namespace Modelo.Cadastros
{
    public class CursoDisciplina
    {
        public long? CursoID { get; set; }
        public Curso Curso { get; set; }
        public long? DisciplinaID { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}