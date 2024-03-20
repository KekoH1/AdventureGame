
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
        public int Health { get; internal set; }

        public Varelse(int x, int y, char symbol, string name, int strength, int endurance, int agility) : base(x, y, symbol)
        {
            Name = name;
            Strength = strength;
            Endurance = endurance;
            Agility = agility;
            Health = 50;
            
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

            if (strength < 1)
            {
                errorCode = ErrorCode.InvalidStrength;
                return false;
            }

            if (endurance < 2)
            {
                errorCode = ErrorCode.InvalidEndurance;
                return false;
            }

            if (agility < 1)
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

        internal void TakeDamage(int playerDamage)
        {
            throw new NotImplementedException();
        }

        internal int GetHealth()
        {
            throw new NotImplementedException();
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
     