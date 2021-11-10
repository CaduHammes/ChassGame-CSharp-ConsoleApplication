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
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);
                    Console.Write("Digite a posicao de origem: ");
                    Posicao origem = Tela.lerPosicaoChass().toPosicao();
                    Console.Write("Digite a posicao de destino: ");
                    Posicao destino = Tela.lerPosicaoChass().toPosicao();

                    partida.ExecutaMovimento(origem, destino);
                }
            }
            catch (TabuleiroException tabE)
            {
                Console.WriteLine(tabE.Message);
            }
        }
    }
}
