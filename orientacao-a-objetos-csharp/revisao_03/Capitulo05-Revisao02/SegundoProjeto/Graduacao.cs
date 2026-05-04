namespace SegundoProjeto
{
    class Graduacao : Curso
    {
        public int Semestres { get; set; }
        public override void RegistrarDisciplina(Disciplina d)
        {
            if (Disciplinas.Count < 24)
                Disciplinas.Add(d);
        }
    }
}
