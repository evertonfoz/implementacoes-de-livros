namespace CasaDoCodigo.Models
{
    public class AtendimentoFoto : AtendimentoFotoIDProperty
    {
        public string CaminhoFoto { get; set; }
        public string Observacoes { get; set; }

        public Atendimento Atendimento { get; set; }
    }
}