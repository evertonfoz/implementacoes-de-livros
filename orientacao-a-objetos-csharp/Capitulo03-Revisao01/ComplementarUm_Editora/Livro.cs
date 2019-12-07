namespace ComplementarUm_Editora
{
    class Livro
    {
        public string Titulo { get; set; }
        public string ISBN { get; set; }

        private Editora editora;
        public Editora Editora
        {
            get { return this.editora; }
            set
            {
                this.editora = value;
                this.editora.RegistrarLivro(this);
            }
        }
        public Autor[] Autores { get; set; } = new Autor[5];
    }
}
