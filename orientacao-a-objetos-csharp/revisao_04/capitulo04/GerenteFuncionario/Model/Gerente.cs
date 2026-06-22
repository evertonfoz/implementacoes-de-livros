namespace ComplementarDois_GerenteFuncionario.Model
{
    class Gerente
    {
        public string Nome { get; set; }

        // Backing field da propriedade Funcionarios
        private List<Funcionario> funcionarios = new List<Funcionario>();

        // set customizado: garante que ao trocar a lista, cada funcionário
        // seja atualizado corretamente (sem referência circular)
        public List<Funcionario> Funcionarios
        {
            get { return this.funcionarios; }
            set
            {
                if (value == null)
                    RemoverAntigosDaGerencia(this.funcionarios);
                else
                    RegistrarFuncionarios(value);
            }
        }

        // API pública para registrar um único funcionário neste gerente
        public void RegistrarFuncionario(Funcionario funcionario)
        {
            RemoverDaGerencia(funcionario);
            RegistrarNaGerencia(funcionario);
        }

        // --- Métodos privados de suporte ---

        private void RemoverAntigosDaGerencia(List<Funcionario> funcionarios)
        {
            // Copia para array temporário para evitar modificação da coleção durante o foreach
            Funcionario[] funcionariosARemover = new Funcionario[funcionarios.Count];
            funcionarios.CopyTo(funcionariosARemover);

            foreach (var funcionario in funcionariosARemover)
            {
                this.RemoverDaGerencia(funcionario);
            }
        }

        private void RemoverDaGerencia(Funcionario funcionario)
        {
            if (funcionario.Gerente != null)
            {
                funcionario.Gerente = null;
            }
        }

        private void RegistrarFuncionarios(List<Funcionario> funcionarios)
        {
            RemoverAntigosDaGerencia(this.funcionarios);
            RegistrarNovosNaGerencia(funcionarios);
        }

        private void RegistrarNovosNaGerencia(List<Funcionario> funcionarios)
        {
            Funcionario[] funcionariosARegistrar = new Funcionario[funcionarios.Count];
            funcionarios.CopyTo(funcionariosARegistrar);

            foreach (var funcionario in funcionariosARegistrar)
            {
                this.RegistrarNaGerencia(funcionario);
            }
        }

        private void RegistrarNaGerencia(Funcionario funcionario)
        {
            // Só registra se o funcionário ainda não estiver neste gerente
            if (funcionario.Gerente == null || !funcionario.Gerente.Equals(this))
                funcionario.Gerente = this;
        }

        // Identidade do Gerente baseada no Nome
        public override bool Equals(object obj)
        {
            if (obj is Gerente gerente)
            {
                return Nome.Equals(gerente.Nome);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 11 + (Nome == null ? 0 : Nome.GetHashCode());
        }
    }
}
