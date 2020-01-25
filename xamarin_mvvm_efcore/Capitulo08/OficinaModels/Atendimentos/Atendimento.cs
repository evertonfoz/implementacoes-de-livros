using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CasaDoCodigo.Models
{
    public class Atendimento : AtendimentoIDProperty
    {
        public string Veiculo { get; set; }
        public DateTime DataHoraChegada { get; set; }
        public DateTime DataHoraPrometida { get; set; }
        public DateTime? DataHoraEntrega { get; set; }

        public Cliente Cliente { get; set; }

        public virtual List<AtendimentoItem> Servicos { get; set; }
        public virtual List<AtendimentoFoto> Fotos { get; set; }

        public Atendimento()
        {
            this.Servicos = new List<AtendimentoItem>();
            this.Fotos = new List<AtendimentoFoto>();

            this.DataHoraChegada = DateTime.Now;
            this.DataHoraPrometida = DateTime.Now;
            this.DataHoraEntrega = null;
        }

        public override bool EstaFinalizado => DataHoraEntrega != null;

        public override bool Equals(object obj)
        {
            return AtendimentoID.Equals((obj as Atendimento).AtendimentoID);
        }

        public override int GetHashCode()
        {
            var hashCode = -1711974840;
            hashCode = hashCode * -1521134297 + EqualityComparer<string>.Default.GetHashCode(AtendimentoID.ToString());
            return hashCode;
        }
    }
}
