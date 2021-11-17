using ConsoleChass.Tabuleiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChass.Chass
{
    class Rei : Peca
    {
        public Rei(Cor cor, Tab tab) : base(cor, tab)
        {

        }

        public override string ToString()
        {
            return "R";
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

            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //diagonal superior direita
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna + 1);

            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //direita
            pos.DefinirValores(posicao.Linha, posicao.Coluna + 1);

            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //diagonal inferior direita
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna + 1);

            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //abaixo
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna);

            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //diagonal inferior esquerda
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna - 1);

            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //esquerda
            pos.DefinirValores(posicao.Linha, posicao.Coluna - 1);

            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //diagonal superior squerda
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna - 1);

            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }

    }
}
