namespace TerceiroProjeto
{
    class Instituicao
    {
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }

        // Array de Departamentos (mantido do cap. 3 para referência)
        public Departamento[] Departamentos { get; } = new Departamento[10];
        private int quantidadeDepartamentos = 0;

        public void RegistrarDepartamento(Departamento departamento)
        {
            if (quantidadeDepartamentos < 10)
            {
                Departamentos[quantidadeDepartamentos] = departamento;
                quantidadeDepartamentos++;
            }
        }

        public int ObterQuantidadeDepartamentos()
        {
            return quantidadeDepartamentos;
        }

        public Departamento DepartamentoPorIndice(int indice)
        {
            return Departamentos[indice];
        }
    }
}
