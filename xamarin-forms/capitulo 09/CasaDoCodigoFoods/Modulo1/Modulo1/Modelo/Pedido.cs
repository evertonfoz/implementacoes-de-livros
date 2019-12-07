using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace Modulo1.Modelo
{
    public class Pedido
    {
        [PrimaryKey, AutoIncrement]
        public long? PedidoId { get; set; }
        public DateTime DataEHoraPedido { get; set; }
        public DateTime? DataEHoraProducao { get; set; }
        public DateTime? DataEHoraEntrega { get; set; }
        public DateTime? DataEHoraEntregue { get; set; }
        public string Situacao { get
            {
                if (DataEHoraProducao == null)
                    return "Aberto";
                else if (DataEHoraEntrega == null)
                    return "Produção";
                else if (DataEHoraEntregue == null)
                    return "Em entrega";
                else
                    return "Fechado";
            } }

        [ForeignKey(typeof(Cliente))]
        public long? ClienteId { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public Cliente Cliente { get; set; }

        [ForeignKey(typeof(Entregador))]
        public long? EntregadorId { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public Entregador Entregador { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.CascadeInsert)]
        public List<ItemPedido> Itens { get; set; }
    }
}
