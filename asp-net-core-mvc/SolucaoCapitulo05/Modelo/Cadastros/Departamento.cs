namespace Modelo.Cadastros
{
    public class Departamento
    {
        public long? DepartamentoID { get; set; }
        public string Nome { get; set; }

        public long? InstituicaoID { get; set; }
        public Instituicao Instituicao { get; set; }
    }
}
