using System;

namespace Modelo
{
    public class Disciplina
    {
        public long? DisciplinaId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int CargaHoraria { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is Disciplina disciplina)
            {
                return this.DisciplinaId.Equals(disciplina.DisciplinaId);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (11 + (this.DisciplinaId == null ? 0 : this.DisciplinaId.GetHashCode()));
        }
    }
}
