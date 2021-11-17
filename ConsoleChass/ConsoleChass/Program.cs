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
                        Tela.imprimirTabuleiro(partida.tab);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.turno);
                        Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);

                        Console.WriteLine();
                        Console.Write("Digite a posicao de origem: ");
                        Posicao origem = Tela.lerPosicaoChass().toPosicao();
                        partida.ValidarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Digite a posicao de destino: ");
                        Posicao destino = Tela.lerPosicaoChass().toPosicao();
                        partida.ValidarPosicaoDeDestino(origem, destino);

                        partida.ExecutaMovimento(origem, destino);
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
