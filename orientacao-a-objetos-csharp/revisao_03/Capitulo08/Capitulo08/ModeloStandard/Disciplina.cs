namespace Modelo
{
    public class Disciplina
    {
        public long DisciplinaID { get; set; }
        public string Nome { get; set; }
        public long CursoID { get; set; }
        public virtual Curso Curso { get; set; }
    }
}
