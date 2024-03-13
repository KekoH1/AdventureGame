
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
}
