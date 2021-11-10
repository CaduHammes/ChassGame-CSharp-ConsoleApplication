using ConsoleChass.Tabuleiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChass.Chass
{
    class Torre : Peca
    {
        public Torre(Cor cor, Tab tab) : base(cor, tab)
        {

        }

        public override string ToString()
        {
            return "T";
        }
    }
}
