using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameDemo
{
    class Combat
    {
        public static void Encounter(Player player, Varelse varelse)
        {
            Console.WriteLine("You encounter a " + varelse.Name + "!");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Fight");
            Console.WriteLine("2. Run");
            string input = Console.ReadLine();

            if (input == "1")
            {
                Fight(player, varelse);
            }
            else if (input == "2")
            {
                Run(player, varelse);
            }
        
        
        
        static void Fight(Player player, Varelse varelse)
            {
            while (player.GetHealth() > 0 && varelse.GetHealth() > 0)
                {
                int playerDamage = player.Stats.Strength;
                int varelseDamage = varelse.Strength;

                player.TakeDamage(varelseDamage);
                varelse.TakeDamage(playerDamage);

                Console.WriteLine("You hit the " + varelse.Name + " for " + playerDamage + " damage!");
                Console.WriteLine("The " + varelse.Name + " hits you for " + varelseDamage + " damage!");

                Console.WriteLine("You have " + player.GetHealth() + " health left.");
                Console.WriteLine("The " + varelse.Name + " has " + varelse.GetHealth() + " health left.");
            }

            if (player.GetHealth() <= 0)
                {
                Console.WriteLine("You have died!");
            }
            else if (varelse.GetHealth() <= 0)
                {
                Console.WriteLine("You have killed the " + varelse.Name + "!");
            }
            }
        
        static void Run (Player player, Varelse varelse)
            {
            Console.WriteLine("You run away from the " + varelse.Name + "!");
            }
        
        
        
        }
    }

}
