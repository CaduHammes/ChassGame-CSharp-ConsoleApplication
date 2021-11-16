using ConsoleChass.Tabuleiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChass.Chass
{
    class Bispo : Peca
    {
        public Bispo(Cor cor, Tab tab) : base(cor, tab)
        {

        }
        public override string ToString()
        {
            return "B";
        }

        public override bool[,] movimentosPossiveis()
        {
            throw new NotImplementedException();
        }
    }
}
