using Modulo1.Modelo.Enums;
using SQLite;
using System;

namespace Modulo1.Modelo
{
    public class Garcom
    {
        [PrimaryKey]
        public string GarcomId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public byte[] Foto { get; set; }

        public long? DispositivoId { get; set; }
        public long? EntityId { get; set; }
        public OperacaoSincronismo OperacaoSincronismo { get; set; }

        public override bool Equals(object obj)
        {
            var garcom = obj as Garcom;
            return this.GarcomId.Equals(garcom.GarcomId);
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(DispositivoId + EntityId);
        }
    }
}
