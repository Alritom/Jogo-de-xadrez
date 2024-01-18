using System;
using tabuleiro;

namespace xadrez_console
{
    internal class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            //Para imprimir o tabuleiro na tela
            for (int i = 0; i < tab.linhas; i++)
            {
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (tab.peca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        //Chamando o objeto peca no objeto tab
                        Console.Write(tab.peca(i, j) + " ");
                    }

                }
                Console.WriteLine();
            }
        }
    }
}
