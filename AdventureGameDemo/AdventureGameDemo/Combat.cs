/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameDemo
{
    public class Combat
    {
        public static void PlayerVsVarelser(Player player, List<Varelse> varelser)
        {
            Console.WriteLine("Combat started: Player vs Varelser");

            // Check if there are any varelser left
            if (varelser.Count == 0)
            {
                Console.WriteLine("No varelser to fight against.");
                return;
            }

            // Set player stats
            player.SetStats(new Stats
            {
                Strength = 10,
                Endurance = 8,
                Agility = 6
            });

            // Set varelser stats
            foreach (var varelse in varelser)
            {
                varelse.Stats = new Stats
                {
                    Strength = 8,
                    Endurance = 6,
                    Agility = 4
                };
            }

            // Start combat
            while (player.IsAlive() && varelser.Any(varelse => varelse.IsAlive()))
            {
                // Player's turn
                Console.WriteLine("Player's turn:");
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Attack 1");
                Console.WriteLine("2. Attack 2");
                Console.WriteLine("3. Attack 3");
                Console.WriteLine("4. Defend");
                Console.WriteLine("5. Run");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Player attacks a random varelse
                        var randomVarelse1 = varelser[new Random().Next(0, varelser.Count)];
                        Attack1(player, randomVarelse1);
                        break;
                    case 2:
                        // Player attacks a random varelse
                        var randomVarelse2 = varelser[new Random().Next(0, varelser.Count)];
                        Attack2(player, randomVarelse2);
                        break;
                    case 3:
                        // Player attacks a random varelse
                        var randomVarelse3 = varelser[new Random().Next(0, varelser.Count)];
                        Attack3(player, randomVarelse3);
                        break;
                    case 4:
                        // Player defends
                        Defend(player);
                        break;
                    case 5:
                        // Player tries to run away
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

        private static void Attack1(Varelse varelse, Player player)
        {
            Console.WriteLine("Varelse attacks Player with Attack 1!");

            // Calculate damage
            int damage = varelse.Stats.Strength - player.GetStats().Endurance;
            if (damage < 0)
            {
                damage = 0;
            }

            // Apply damage to player
            player.GetStats().Endurance -= damage;

            Console.WriteLine("Player takes " + damage + " damage.");

            // Check if player is still alive
            if (!player.IsAlive())
            {
                Console.WriteLine("Player is defeated!");
            }
        }

        private static void Attack2(Varelse varelse, Player player)
        {
            Console.WriteLine("Varelse attacks Player with Attack 2!");

            // Calculate damage
            int damage = varelse.Stats.Strength - player.GetStats().Endurance;
            if (damage < 0)
            {
                damage = 0;
            }

            // Apply damage to player
            player.GetStats().Endurance -= damage;

            Console.WriteLine("Player takes " + damage + " damage.");

            // Check if player is still alive
            if (!player.IsAlive())
            {
                Console.WriteLine("Player is defeated!");
            }
        }

        private static void Attack3(Varelse varelse, Player player)
        {
            Console.WriteLine("Varelse attacks Player with Attack 3!");

            // Calculate damage
            int damage = varelse.Stats.Strength - player.GetStats().Endurance;
            if (damage < 0)
            {
                damage = 0;
            }

            // Apply damage to player
            player.GetStats().Endurance -= damage;

            Console.WriteLine("Player takes " + damage + " damage.");

            // Check if player is still alive
            if (!player.IsAlive())
            {
                Console.WriteLine("Player is defeated!");
            }
        }

        private static void Attack(Player player, Varelse randomVarelse)
        {
            Console.WriteLine("Player attacks Varelse!");

            // Calculate damage
            int damage = player.GetStats().Strength - randomVarelse.Stats.Endurance;
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

        private static void Defend(Player player)
        {
            Console.WriteLine("Player defends!");

            // Increase player's endurance temporarily
            player.GetStats().Endurance += 5;

            Console.WriteLine("Player's endurance increased by 5.");
        }

        private static bool RunAway(Player player)
        {
            Console.WriteLine("Player tries to run away...");

            // Generate a random number between 1 and 10
            int randomNumber = new Random().Next(1, 11);

            // Check if player successfully runs away
            if (randomNumber <= player.GetStats().Agility)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
*/