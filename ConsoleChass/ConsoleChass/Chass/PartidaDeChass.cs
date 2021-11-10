using ConsoleChass.Tabuleiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChass.Chass
{
    class PartidaDeChass
    {
        public Tab tab { get; private set; }
        private int turno;
        private Cor jogadorAtual;
        public bool terminada { get; private set; }

        public PartidaDeChass()
        {
            tab = new Tab(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            colocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQntDeMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
        }

        private void colocarPecas()
        {
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoChass('c', 1).toPosicao());
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoChass('c', 2).toPosicao());
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoChass('d', 2).toPosicao());
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoChass('e', 2).toPosicao());
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoChass('e', 1).toPosicao());
            tab.colocarPeca(new Rei(Cor.Branca, tab), new PosicaoChass('d', 1).toPosicao());

            tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoChass('c', 7).toPosicao());
            tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoChass('c', 8).toPosicao());
            tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoChass('d', 7).toPosicao());
            tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoChass('e', 7).toPosicao());
            tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoChass('e', 8).toPosicao());
            tab.colocarPeca(new Rei(Cor.Preta, tab), new PosicaoChass('d', 8).toPosicao());
        }
    }
}
