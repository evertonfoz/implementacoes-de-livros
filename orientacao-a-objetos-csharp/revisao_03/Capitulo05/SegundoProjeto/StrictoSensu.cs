using System.Collections.Generic;

namespace SegundoProjeto
{
    class StrictoSensu : PosGraduacao
    {
        public IList<string> LinhasDePesquisa { get; } = new List<string>();
    }
}
