namespace TerceiroProjeto
{
    class Curso
    {
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }

        // HashSet garante que disciplinas com mesmo Nome não sejam duplicadas
        public HashSet<Disciplina> Disciplinas { get; } = new HashSet<Disciplina>();

        public void RegistrarDisciplina(Disciplina disciplina)
        {
            Disciplinas.Add(disciplina);
        }

        public int ObterQuantidadeDisciplinasDoCurso()
        {
            return Disciplinas.Count;
        }

        // LINQ: busca disciplina pelo nome usando expressão lambda
        public Disciplina ObterDisciplinaPorNome(string nome)
        {
            return Disciplinas.Where<Disciplina>(d => d.Nome.Equals(nome)).FirstOrDefault();
        }

        // Identidade do Curso baseada no Nome
        public override bool Equals(object obj)
        {
            if (obj is Curso c)
            {
                return this.Nome.Equals(c.Nome);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (11 + this.Nome == null ? 0 : this.Nome.GetHashCode());
        }
    }
}
