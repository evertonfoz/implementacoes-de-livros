namespace ADO_NETProject01
{
    public class ProdutoNotaEntrada
    {
        public long? Id { get; set; }
        public Produto ProdutoNota { get; set; }
        public double PrecoCustoCompra { get; set; }
        public double QuantidadeComprada { get; set; }

        public ProdutoNotaEntrada()
        {
            this.Id = null;
        }

        protected bool Equals(ProdutoNotaEntrada other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != typeof(ProdutoNotaEntrada))
                return false;
            return Equals((ProdutoNotaEntrada)obj);
        }

        public override int GetHashCode()
        {
            return ProdutoNota.GetHashCode();
        }
    }
}
