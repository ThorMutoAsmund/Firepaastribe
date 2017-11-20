using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firepaastribe
{
    public static class Visualizer
    {
        public static void Show(Board board)
        {
            Enumerable.Range(0, Size.H).Reverse().Each(h =>
            {
                Enumerable.Range(0, Size.W).Each(w =>
                {
                    switch (board[w, h])
                    {
                        case Color.None:
                            Console.ForegroundColor = ConsoleColor.Gray; Console.Write("· "); break;
                        case Color.Blue:
                            Console.ForegroundColor = ConsoleColor.Blue; Console.Write("O "); break;
                        case Color.Red:
                            Console.ForegroundColor = ConsoleColor.Red; Console.Write("O "); break;
                    }
                });
                Console.WriteLine();
            });
            Console.ForegroundColor = ConsoleColor.White;
            Enumerable.Range(0, Size.W).Each(w => Console.Write(w + " "));
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
