namespace Modulo1.Modelo
{
    public class TipoItemCardapio
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string CaminhoArquivoFoto { get; set; }
        public override bool Equals(object obj)
        {
            TipoItemCardapio tipoItemCardapio = obj as TipoItemCardapio;
            if (tipoItemCardapio == null)
            {
                return false;
            }
            return (Id.Equals(tipoItemCardapio.Id));
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
