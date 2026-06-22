namespace Modelo
{
    public class Curso
    {
        public long CursoId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int CargaHoraria { get; set; }

        public System.Collections.Generic.List<Disciplina> Disciplinas { get; set; } = new();
    }
}
