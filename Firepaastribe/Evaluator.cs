using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firepaastribe
{
    public static class Evaluator
    {
        public static int Evaluate(Board board, int color)
        {
            return EvaluateColor(board, color) - EvaluateColor(board, Color.Next(color));
        }

        public static bool IsFinished(Board board, int color)
        {
            if (EvaluateColor(board, color, true) != 0)
            {
                return true;
            }
            return false;
        }

        private static int EvaluateColor(Board b, int c, bool checkForFinished = false)
        {
            int v = 0;
            Enumerable.Range(0, Size.W).Each(w =>
            {
                int h = 0;
                while (h < Size.H && b[w, h] != Color.None)
                {
                    if (b[w, h] == c)
                    {
                        if (checkForFinished)
                        {
                            if (b.HasRow(w, h, 4, c, c, c, c))
                            {
                                v = 1;
                            }
                        }
                        else
                        {
                            if (b.HasRow(w, h, 4, c, c, c, c))
                                v += 1000;
                            else if (b.HasRow(w, h, 4, c, c, c, Color.None) || b.HasRow(w, h, -4, c, c, c, Color.None))
                                v += 300;
                        }
                    }
                    h++;
                }
            });
            return v;
        }
    }
}
