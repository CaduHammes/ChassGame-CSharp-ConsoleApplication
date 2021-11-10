using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChass.Tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qntMovimentos { get; protected set; }

        public Tab tab { get; protected set; }

        public Peca(Cor cor, Tab tab)
        {
            this.posicao = null;
            this.cor = cor;
            this.tab = tab;
            this.qntMovimentos = 0;
        }

        public void incrementarQntDeMovimentos()
        {
            qntMovimentos++;
        }
    }
}
