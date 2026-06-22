namespace TerceiroProjeto
{
    class Disciplina
    {
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }

        // Equals e GetHashCode: identidade baseada no Nome
        public override bool Equals(object obj)
        {
            if (obj is Disciplina disciplina)
            {
                return Nome.Equals(disciplina.Nome);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 11 + (Nome == null ? 0 : Nome.GetHashCode());
        }
    }
}
