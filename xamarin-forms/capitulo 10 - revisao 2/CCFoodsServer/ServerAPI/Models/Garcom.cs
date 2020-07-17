using ServerAPI.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerAPI.Models
{
    public class Garcom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
