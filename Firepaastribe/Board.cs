using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firepaastribe
{
    public class Board
    {
        public int[] F;
        public int[] M;

        public int this[int w, int h]
        {
            get { return this.F[w + h * Size.W]; }
            set { this.F[w + h * Size.W] = value; }
        }

        public Board()
        {
            this.F = new int[Size.W * Size.H];
            this.M = new int[Size.W];
            Enumerable.Range(0, Size.W * Size.H).Each(i => this.F[i] = Color.None);
            Enumerable.Range(0, Size.W).Each(i => this.M[i] = 0);
        }

        public IEnumerable<int> GetMoves()
        {
            return Enumerable.Range(0, Size.W).Where(w => this[w, Size.HM] == Color.None);
        }

        public void Push(int w, int color)
        {
            this[w, this.M[w]++] = color;
        }

        public void Pop(int w)
        {
            this[w, --this.M[w]] = Color.None;
        }

        public bool HasRow(int wstart, int hstart, int len, params int[] colors)
        {
            var l = len < 0 ? len + 1 : (len > 0 ? len - 1 : len);
            return HasRowD(wstart, wstart, hstart, hstart + l, colors) ||
                HasRowD(wstart, wstart + l, hstart, hstart + l, colors) ||
                HasRowD(wstart, wstart + l, hstart, hstart, colors);
        }

        private bool HasRowD(int wstart, int wend, int hstart, int hend, int[] colors)
        {
            if (wend >= Size.W || wend < 0 || hend >= Size.H || hend < 0)
                return false;

            int dw = wstart == wend ? 0 : (wstart < wend ? 1 : -1),
                dh = hstart == hend ? 0 : (hstart < hend ? 1 : -1);
            int w = wstart, h = hstart, i = 0;
            do
            {
                w += dw; h += dh;
                if (this[w, h] != colors[i])
                {
                    return false;
                }
                i++;
            }
            while (w != wend || h != hend);
            return true;
        }
    }
}
