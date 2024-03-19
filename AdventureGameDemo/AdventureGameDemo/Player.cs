using AdventureGameDemo;
using System.Numerics;

public class Player
{
    private int health;
    private int maxHealth;
    private object player;

    public int Health { get; set; }

    public Stats Stats { get; set; }
    public int Endurance { get; set; }
    public object Inventory { get; internal set; }

    public Player()
    {

        private int health;
        public int MaxHealth;

        maxHealth = 100;
        health = maxHealth;
        Stats = new Stats();
        Stats.Strength = 10;
        Stats.Endurance = 8;
        Stats.Agility = 6;
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
      {
 
            this.MaxHealth = maxHealth;
            this.health = maxHealth;

            health = 0;

        }
    }


        public int Health
        {
            get { return health; }
            set { health = Math.Clamp(value, 0, MaxHealth); }
        }

        public void TakeDamage(int damage)
        {
            int previousHealth = Health;
            Health -= damage;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Player took {damage} damage. Current health: {Health}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Health bar: {new string('█', Health)}{new string(' ', MaxHealth - Health)}");
            Console.ResetColor();
        }

    public int GetHealth()
    {
        return health;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }


    public void PrintHealthBar()
    {
        int healthPercentage = (int)((float)health / maxHealth * 100);
        string healthBar = "";

        for (int i = 0; i < 10; i++)
        {

            int previousHealth = Health;
            Health += amount;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Player healed for {amount} health. Current health: {Health}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Health bar: {new string('█', previousHealth)}{new string(' ', MaxHealth - previousHealth)}");
            Console.ResetColor();

            if (i < healthPercentage / 10)
            {
                healthBar += "#";
            }
            else
            {
                healthBar += "-";
            }
 
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Health: " + healthBar);
    }

    public bool IsAlive()
    {
        return health > 0;
    }

    internal object GetStats()
    {
        throw new NotImplementedException();
    }

    internal void SetStats(Stats stats)
    {
        throw new NotImplementedException();
    }
}

