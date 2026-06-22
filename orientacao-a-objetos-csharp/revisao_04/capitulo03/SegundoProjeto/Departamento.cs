namespace SegundoProjeto
{
    class Departamento
    {
        public string Nome { get; set; }

        // Construtor: garante que o departamento seja criado com um nome válido
        public Departamento(string nome)
        {
            Nome = nome;
        }
    }
}
