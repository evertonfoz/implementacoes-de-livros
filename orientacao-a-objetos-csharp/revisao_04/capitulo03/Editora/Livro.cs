namespace ComplementarUm_Editora
{
    public class Livro
    {
        public string Titulo { get; set; }
        public string ISBN { get; set; }

        // Autores do livro (até 5)
        public Autor[] Autores { get; } = new Autor[5];
        private int _quantidadeAutores = 0;

        // Backing field para implementar a propriedade Editora com set personalizado
        private Editora _editora;

        // Propriedade Editora com set que registra o livro na editora automaticamente
        // ATENÇÃO: A lógica aqui evita loop infinito verificando se o livro já foi registrado
        public Editora Editora
        {
            get => _editora;
            set
            {
                _editora = value;
                // Verifica se o livro ainda não foi adicionado à editora
                // para evitar chamada cíclica (Stack Overflow)
                bool jaRegistrado = false;
                for (int i = 0; i < _editora.ObterQuantidadeLivros(); i++)
                {
                    if (_editora.Livros[i] == this)
                    {
                        jaRegistrado = true;
                        break;
                    }
                }
                if (!jaRegistrado)
                {
                    _editora.RegistrarLivro(this);
                }
            }
        }

        public void RegistrarAutor(Autor autor)
        {
            if (_quantidadeAutores < 5)
            {
                Autores[_quantidadeAutores] = autor;
                _quantidadeAutores++;
            }
        }

        public int ObterQuantidadeAutores()
        {
            return _quantidadeAutores;
        }
    }
}
