using ConsoleChass.Tabuleiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChass.Chass
{
    class Rainha : Peca
    {
        public Rainha(Cor cor, Tab tab) : base(cor, tab)
        {

        }

        public override string ToString()
        {
            return "{R}";
        }

        public override bool[,] MovimentosPossiveis()
        {
            throw new NotImplementedException();
        }
    }
}
