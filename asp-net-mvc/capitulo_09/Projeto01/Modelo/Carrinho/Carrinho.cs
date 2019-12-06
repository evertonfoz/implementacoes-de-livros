using Modelo.Cadastros;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Modelo.Carrinho
{
    public class Carrinho
    {
        public long? CarrinhoId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Data { get; set; }
        public long? ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        //public double Total {  get
        //    {
        //       return 100;
        //       return Itens.Select(ic => (ic.Quantidade * ic.ValorUnitario)).Sum();
        //    }
        //}
        public ICollection<ItemCarrinho> Itens { get; set; }
    }
}
