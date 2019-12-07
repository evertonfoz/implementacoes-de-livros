
namespace EFSolutionNovaVersao.POCO
{
    public class Cidade
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        public long EstadoId { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
