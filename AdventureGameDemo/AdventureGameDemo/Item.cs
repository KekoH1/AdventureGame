
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameDemo
{

    public class Item 
    {

        public string Name { get; set; }
        public char Symbol { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


        public Item(int x, int y, char symbol, string name) 
        {
            X = x;
            Y = y;
            Symbol = symbol;
            Name = name;
            
        }
    }
}
