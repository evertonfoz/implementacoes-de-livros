namespace SegundoProjeto
{
    class Instituicao
    {
        public string Nome { get; set; }

        // Composição: Endereco é parte de Instituicao
        public Endereco Endereco { get; set; }

        // Associação: uma Instituicao tem vários Departamentos (array com tamanho fixo)
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

        // Encapsula o acesso ao array — ideal para não expor o índice diretamente
        public Departamento DepartamentoPorIndice(int indice)
        {
            return Departamentos[indice];
        }
    }
}
