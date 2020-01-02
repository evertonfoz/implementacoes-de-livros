using System;

namespace SegundoProjeto
{
    class Curso
    {
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public override bool Equals(Object obj)
        {
            if (obj is Curso)
            {
                Curso c = obj as Curso;
                return this.Nome.Equals(c.Nome);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (11 + this.Nome == null ? 0 : this.Nome.GetHashCode());
        }
    }
}
