namespace ComplementarDois_GerenteFuncionario.Model
{
    class Funcionario
    {
        public string Nome { get; set; }

        // Backing field para controlar o set da propriedade Gerente
        private Gerente gerente;

        // set customizado: ao atribuir um gerente, adiciona o funcionário
        // à coleção do gerente e remove do gerente anterior se houver
        public Gerente Gerente
        {
            get { return this.gerente; }
            set
            {
                // Remove deste funcionário do gerente anterior, se existir
                if (this.gerente != null)
                    this.gerente.Funcionarios.Remove(this);

                this.gerente = value;

                // Adiciona o funcionário ao novo gerente, se não for null
                if (this.gerente != null)
                    this.gerente.Funcionarios.Add(this);
            }
        }
    }
}
