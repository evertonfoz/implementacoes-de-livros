using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelProject
{
    public class ProdutoNotaEntrada
    {
        public Guid Id { get; set; }
        public Produto ProdutoNota { get; set; }
        public double PrecoCustoCompra { get; set; }
        public double QuantidadeComprada { get; set; }

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
