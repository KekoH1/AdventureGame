/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameDemo
{
    public class Combat
    {
        public static void StartCombat(Player player, List<Varelse> varelser)
        {
            Console.WriteLine("Combat started: Player vs Varelser");

            // Check if there are any varelser left
            if (varelser.Count == 0)
            {
                Console.WriteLine("No varelser to fight against.");
                return;
            }

            // Start combat
            while (player.IsAlive() && varelser.Any(varelse => varelse.IsAlive()))
            {
                // Player's turn
                Console.WriteLine("Player's turn:");
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Attack with fists");
                Console.WriteLine("2. Attack with weapon");
                Console.WriteLine("3. Use item to heal");
                Console.WriteLine("4. Run away");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AttackWithFists(player, varelser);
                        break;
                    case 2:
                        AttackWithWeapon(player, varelser);
                        break;
                    case 3:
                        UseItemToHeal(player);
                        break;
                    case 4:
                        if (RunAway(player))
                        {
                            Console.WriteLine("Player successfully ran away.");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Player failed to run away.");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose again.");
                        break;
                }

                // Varelser's turn
                Console.WriteLine("Varelser's turn:");
                foreach (var varelse in varelser)
                {
                    if (varelse.IsAlive())
                    {
                        Attack(varelse, player);
                    }
                }
            }

            // Check if player won or lost
            if (player.IsAlive())
            {
                Console.WriteLine("Player won the combat!");
            }
            else
            {
                Console.WriteLine("Player lost the combat!");
            }
        }

        private static void Attack(Varelse varelse, Player player)
        {
            Console.WriteLine("Varelse attacks Player!");

            // Calculate damage
            int damage = varelse.Stats.Strength - player.Stats.Endurance;
            if (damage < 0)
            {
                damage = 0;
            }

            // Apply damage to player
            player.Stats.Endurance -= damage;

            Console.WriteLine("Player takes " + damage + " damage.");

            // Check if player is still alive
            if (!player.IsAlive())
            {
                Console.WriteLine("Player is defeated!");
            }
        }

        private static void AttackWithFists(Player player, List<Varelse> varelser)
        {
            Console.WriteLine("Player attacks with fists!");

            // Player attacks a random varelse
            var randomVarelse = varelser[new Random().Next(0, varelser.Count)];

            // Calculate damage
            int damage = player.Stats.Strength - randomVarelse.Stats.Endurance;
            if (damage < 0)
            {
                damage = 0;
            }

            // Apply damage to varelse
            randomVarelse.Stats.Endurance -= damage;

            Console.WriteLine("Varelse takes " + damage + " damage.");

            // Check if varelse is still alive
            if (!randomVarelse.IsAlive())
            {
                Console.WriteLine("Varelse is defeated!");
            }
        }

        private static void AttackWithWeapon(Player player, List<Varelse> varelser)
        {
            if (player.Inventory.Contains("Weapon"))
            {
                Console.WriteLine("Player attacks with weapon!");

                // Player attacks a random varelse
                var randomVarelse = varelser[new Random().Next(0, varelser.Count)];

                // Calculate damage
                int damage = player.Stats.Strength + 5 - randomVarelse.Stats.Endurance;
                if (damage < 0)
                {
                    damage = 0;
                }

                // Apply damage to varelse
                randomVarelse.Stats.Endurance -= damage;

                Console.WriteLine("Varelse takes " + damage + " damage.");

                // Check if varelse is still alive
                if (!randomVarelse.IsAlive())
                {
                    Console.WriteLine("Varelse is defeated!");
                }
            }
            else
            {
                Console.WriteLine("Player does not have a weapon in the inventory.");
            }
        }

        private static void UseItemToHeal(Player player)
        {
            if (player.Inventory.Contains("Healing Item"))
            {
                Console.WriteLine("Player uses item to heal!");

                // Increase player's endurance temporarily
                player.Stats.Endurance += 10;

                Console.WriteLine("Player's endurance increased by 10.");
            }
            else
            {
                Console.WriteLine("Player does not have a healing item in the inventory.");
            }
        }

        private static bool RunAway(Player player)
        {
            Console.WriteLine("Player tries to run away...");

            // Generate a random number between 1 and 10
            int randomNumber = new Random().Next(1, 11);

            // Check if player successfully runs away
            if (randomNumber <= player.Stats.Agility)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}*/
