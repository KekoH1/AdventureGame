using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameDemo
{
    public class Weapon : Item
    {
        public int AttackDamge { get; set; }

        public Weapon(int x, int y, char symbol, string name, int attckdamage) : base (x, y, symbol, name)
        {
            AttackDamge = attckdamage;
        }
    }
}
