using System;

namespace Modelo
{
    public class Disciplina
    {
        public string Nome { get; set; } = string.Empty;
        public int CargaHoraria { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is Disciplina disciplina)
            {
                return Nome.Equals(disciplina.Nome, StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Nome.ToUpperInvariant().GetHashCode();
        }
    }
}
