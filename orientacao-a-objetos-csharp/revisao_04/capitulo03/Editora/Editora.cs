namespace ComplementarUm_Editora
{
    public class Editora
    {
        public string RazaoSocial { get; set; }
        public string EMail { get; set; }
        public string WhatsApp { get; set; }

        // Navegabilidade bidirecional: Editora conhece seus Livros
        public Livro[] Livros { get; } = new Livro[10];
        private int _quantidadeLivros = 0;

        public void RegistrarLivro(Livro livro)
        {
            if (_quantidadeLivros < 10)
            {
                Livros[_quantidadeLivros] = livro;
                _quantidadeLivros++;
            }
        }

        public int ObterQuantidadeLivros()
        {
            return _quantidadeLivros;
        }
    }
}
