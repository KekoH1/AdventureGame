using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameDemo
{
    public class Potion : Item
    {
        internal int healthRestoredPercentage;

        public int HealingPower { get; set; }
        public int StackSize { get; set; }
        public double HealthRestordPercentage { get; set; }
        public int V { get; }

        public Potion(int x, int y, char symbol, string name, int healingpower, int stacksize, double healthRestoredPercentage) : base(x, y, symbol, name) 
        {
            HealingPower = healingpower;
            StackSize = stacksize;
            HealthRestordPercentage = healthRestoredPercentage;
        }

        public Potion(int x, int y, char symbol, string name, int healingPower, int v) : base(x, y, symbol, name)
        {
            HealingPower = healingPower;
            V = v;
        }
    }
}
