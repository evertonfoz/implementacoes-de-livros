namespace TerceiroProjeto
{
    class Departamento
    {
        public string Nome { get; set; }

        public Departamento(string nome)
        {
            Nome = nome;
        }

        // Associação: Departamento possui uma coleção de Cursos (IList<T>)
        public IList<Curso> Cursos { get; } = new List<Curso>();

        public void RegistrarCurso(Curso curso)
        {
            Cursos.Add(curso);
        }

        public int ObterQuantidadeDeCursos()
        {
            return Cursos.Count;
        }

        public Curso ObterCursoPorIndice(int indice)
        {
            return Cursos[indice];
        }

        // LINQ: recupera o primeiro curso pelo nome
        public Curso ObterCursoPorNome(string nome)
        {
            return Cursos.FirstOrDefault(curso => curso.Nome.Equals(nome));
        }

        public void FecharDepartamento()
        {
            while (Cursos.Count > 0)
            {
                Cursos.RemoveAt(0);
            }
        }
    }
}
