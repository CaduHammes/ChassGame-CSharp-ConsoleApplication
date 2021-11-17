using ConsoleChass.Chass;
using ConsoleChass.Tabuleiro;
using System;

namespace ConsoleChass
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeChass partida = new PartidaDeChass();

                while (!partida.terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Digite a posicao de origem: ");
                        Posicao origem = Tela.LerPosicaoChass().ToPosicao();
                        partida.ValidarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.Peca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Digite a posicao de destino: ");
                        Posicao destino = Tela.LerPosicaoChass().ToPosicao();
                        partida.ValidarPosicaoDeDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);
                    }
                    catch (TabuleiroException tabE)
                    {
                        Console.WriteLine(tabE.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (TabuleiroException tabE)
            {
                Console.WriteLine(tabE.Message);
            }
        }
    }
}
