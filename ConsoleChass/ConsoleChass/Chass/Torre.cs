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

        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.Peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna);

            while (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).cor != cor)
                {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }

            //abaixo
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna);

            while (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).cor != cor)
                {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }

            //direita
            pos.DefinirValores(posicao.Linha, posicao.Coluna + 1);

            while (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).cor != cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }

            //esquerda
            pos.DefinirValores(posicao.Linha, posicao.Coluna - 1);

            while (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).cor != cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }


            return mat;
        }
    }
}
