﻿using ConsoleChass.Tabuleiro;
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
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool Xeque { get; private set; }

        public PartidaDeChass()
        {
            tab = new Tab(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            Xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementarQntDeMovimentos();
            Peca pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.RetirarPeca(destino);
            p.DecrementarQntDeMovimentos();

            if (pecaCapturada != null)
            {
                tab.ColocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.ColocarPeca(p, origem);
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);

            if (EstaEmXeque(jogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("\nVoce nao pode se colocar em xeque" +
                    "\nPressione enter para continuar...");
            }

            if (EstaEmXeque(Adversaria(jogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }

            turno++;
            MudaJogador();
        }

        public void ValidarPosicaoDeOrigem(Posicao pos)
        {
            if (tab.Peca(pos) == null)
            {
                throw new TabuleiroException("\nNão existe peça na posição de origem escolhida" +
                    "\nPressione enter para continuar...");
            }
            if (jogadorAtual != tab.Peca(pos).cor)
            {
                throw new TabuleiroException("\nA peça de origem escolhida não é sua" +
                    "\nPressione enter para continuar...");
            }
            if (!tab.Peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("\nNão há movimentos possíveis para a peça de origem escolhida" +
                    "\nPressione enter para continuar...");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("\nPosição de destino invalida" +
                    "\nPressione enter para continuar...");
            }
        }

        private void MudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        private Cor Adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca Rei(Cor cor)
        {
            foreach (Peca x in PecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca r = Rei(cor);

            if (r == null)
            {
                throw new TabuleiroException("\nNao tem rei da cor " + cor + " no tabuleiro" +
                    "\nPressione enter para continuar...");
            }

            foreach (Peca x in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = x.MovimentosPossiveis();

                if (mat[r.posicao.Linha, r.posicao.Coluna])
                {
                    return true;
                }
            }

            return false;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.ColocarPeca(peca, new PosicaoChass(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('c', 1, new Torre(Cor.Branca, tab));
            ColocarNovaPeca('c', 2, new Torre(Cor.Branca, tab));
            ColocarNovaPeca('d', 2, new Torre(Cor.Branca, tab));
            ColocarNovaPeca('e', 2, new Torre(Cor.Branca, tab));
            ColocarNovaPeca('e', 1, new Torre(Cor.Branca, tab));
            ColocarNovaPeca('d', 1, new Rei(Cor.Branca, tab));

            ColocarNovaPeca('c', 7, new Torre(Cor.Preta, tab));
            ColocarNovaPeca('c', 8, new Torre(Cor.Preta, tab));
            ColocarNovaPeca('d', 7, new Torre(Cor.Preta, tab));
            ColocarNovaPeca('e', 7, new Torre(Cor.Preta, tab));
            ColocarNovaPeca('e', 8, new Torre(Cor.Preta, tab));
            ColocarNovaPeca('d', 8, new Rei(Cor.Preta, tab));
        }
    }
}
