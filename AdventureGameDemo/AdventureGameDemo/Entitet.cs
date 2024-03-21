using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameDemo
{
    public class Entitet
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }
        public object Stats { get; internal set; }
        /*public object Name { get; internal set; }*/

        public Entitet(int x, int y, char symbol)
        {
            X = x;
            Y = y;
            Symbol = symbol;
        }

        internal bool IsAlive()
        {
            throw new NotImplementedException();
        }
    }
}
