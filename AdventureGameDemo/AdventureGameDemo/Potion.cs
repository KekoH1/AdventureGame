using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameDemo
{
    public class Potion : Item
    {
        public int HealingPower { get; set; }
        public int StackSize { get; set; }

        public Potion(int x, int y, char symbol, string name, int healingpower, int stacksize) : base(x, y, symbol, name) 
        {
            HealingPower = healingpower;
            StackSize = stacksize;
        }
    }
}
