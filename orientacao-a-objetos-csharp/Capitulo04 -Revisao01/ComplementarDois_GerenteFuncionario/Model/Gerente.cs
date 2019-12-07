using System.Collections.Generic;

namespace ComplementarDois_GerenteFuncionario.Model
{
    class Gerente
    {
        private List<Funcionario> funcionarios = new List<Funcionario>();
        public string Nome { get; set; }
        public List<Funcionario> Funcionarios {
            get { return this.funcionarios; }
            set {
                if (value == null)
                    removerAntigosDaGerencia(this.funcionarios);
                else
                    registrarFuncionarios(value);
            }
        }
        private void registrarNaGerencia(Funcionario funcionario)
        {
            if (funcionario.Gerente == null || !funcionario.Gerente.Equals(this))
                funcionario.Gerente = this;
        }

        private void removerDaGerencia(Funcionario funcionario)
        {
            funcionario.Gerente = null;
            /*if (funcionario.Gerente != null)
            {
                funcionario.Gerente = null;
            }*/
        }
        public void RegistrarFuncionario(Funcionario funcionario)
        {
            removerDaGerencia(funcionario);
            registrarNaGerencia(funcionario);
        }
        private void registrarNovosNaGerencia(List<Funcionario> funcionarios)
        {
            Funcionario[] funcionariosARegistrar = new Funcionario[funcionarios.Count];
            funcionarios.CopyTo(funcionariosARegistrar);

            foreach (var funcionario in funcionariosARegistrar)
            {
                this.registrarNaGerencia(funcionario);
            }
        }
        private void registrarFuncionarios(List<Funcionario> funcionarios)
        {
            removerAntigosDaGerencia(this.funcionarios);
            registrarNovosNaGerencia(funcionarios);
        }

        private void removerAntigosDaGerencia(List<Funcionario> funcionarios)
        {
            Funcionario[] funcionariosARemover = new Funcionario[funcionarios.Count];
            funcionarios.CopyTo(funcionariosARemover);

            foreach (var funcionario in funcionariosARemover)
            {
                this.removerDaGerencia(funcionario);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (obj is Gerente)
            {
                Gerente g = obj as Gerente;
                return this.Nome.Equals(g.Nome);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (11 + this.Nome == null ? 0 : this.Nome.GetHashCode());
        }
        public override string ToString()
        {
            return Nome + "-" + funcionarios.Count;
        }
    }
}
