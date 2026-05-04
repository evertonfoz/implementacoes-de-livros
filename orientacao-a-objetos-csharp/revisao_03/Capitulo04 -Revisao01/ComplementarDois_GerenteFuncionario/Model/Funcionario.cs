namespace ComplementarDois_GerenteFuncionario.Model
{
    class Funcionario
    {
        public string Nome { get; set; }
        private Gerente gerente;
        public Gerente Gerente
        {
            get { return this.gerente; }
            set
            {
                if (this.gerente != null)
                    this.gerente.Funcionarios.Remove(this);

                this.gerente = value;
                if (this.gerente != null)
                    this.gerente.Funcionarios.Add(this);
            }
        }
    }
}
