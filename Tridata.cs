using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixDijkstra
{
    internal class Tridata
    {
        public int i, j;
        public int value;
        public Tridata(int i,int j, int value)
        {
            this.i = i;
            this.j = j;
            this.value = value;
        }
    }
}
