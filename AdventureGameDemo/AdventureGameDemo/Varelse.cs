
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameDemo
{
    public class Varelse : Entitet
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Endurance { get; set; }
        public int Agility { get; set; }

        public Varelse(int x, int y, char symbol, string name, int strength, int endurance, int agility) : base(x, y, symbol)
        {
            Name = name;
            Strength = strength;
            Endurance = endurance;
            Agility = agility;
        }

        public enum ErrorCode
        {
            InvalidName,
            InvalidStrength,
            InvalidEndurance,
            InvalidAgility,
            None
        }

        public static bool ValidateAttributes(string name, int strength, int endurance, int agility, out ErrorCode errorCode)
        {
            errorCode = ErrorCode.InvalidName;

            if (string.IsNullOrEmpty(name))
            {
                errorCode = ErrorCode.InvalidName;
                return false;
            }

            if (strength < 0)
            {
                errorCode = ErrorCode.InvalidStrength;
                return false;
            }

            if (endurance < 0)
            {
                errorCode = ErrorCode.InvalidEndurance;
                return false;
            }

            if (agility < 0)
            {
                errorCode = ErrorCode.InvalidAgility;
                return false;
            }

            errorCode = ErrorCode.None;
            return true;
        }

        public bool IsAlive()
        {
            return Endurance > 0;
        }
    }


    namespace AdventureGameDemo
    {
        public class Varelse
        {
            public Stats Stats { get; set; }

            public Varelse()
            {
                Stats = new Stats();
            }
        }

        public class Stats
        {
            public int Endurance { get; set; }
            public int Strength { get; set; }
        }
    }
}
     /*   public void Attack(Player player)
        {
        int Strength = 0;
        // Calculate damage based on Varelse's strength and player's endurance
        int damage = Strength - player.Endurance;

            // Reduce player's health by the calculated damage
            player.Health -= damage;

            // Check if the player is still alive
            if (player.Health <= 0)
            {
                Console.WriteLine("Player has been defeated!");
            }
            else
            {
                Console.WriteLine($"Player has taken {damage} damage. Player's health: {player.Health}");
            }
        }
    }

*/