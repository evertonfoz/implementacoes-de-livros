namespace ADO_NETProject01
{
    public class Produto
    {
        public long? Id { get; set; }
        public string Descricao { get; set; }
        public double PrecoDeCusto { get; set; }
        public double PrecoDeVenda { get; set; }
        public double Estoque { get; set; }

        public Produto()
        {
            this.Id = null;
        }
    }
}
