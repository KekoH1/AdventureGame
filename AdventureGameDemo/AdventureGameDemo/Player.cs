using System;

namespace AdventureGameDemo
{
    public class Player
    {
        private int health;
        private int maxHealth;

        public Player(int maxHealth)
        {
            this.maxHealth = maxHealth;
            this.health = maxHealth;
        }

        public int Health
        {
            get { return health; }
            set { health = Math.Clamp(value, 0, maxHealth); }
        }

        public void TakeDamage(int damage)
        {
            int previousHealth = Health;
            Health -= damage;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Player took {damage} damage. Current health: {Health}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Health bar: {new string('█', Health)}{new string(' ', maxHealth - Health)}");
            Console.ResetColor();
        }

        public void Heal(int amount)
        {
            int previousHealth = Health;
            Health += amount;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Player healed for {amount} health. Current health: {Health}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Health bar: {new string('█', previousHealth)}{new string(' ', maxHealth - previousHealth)}");
            Console.ResetColor();
        }
    }
    public void Bar(Player player)
    {
        Console.WriteLine("Player Health:");

        if (player.MaxHealth != 0)
        {
            // Calculate the percentage of health remaining
            double healthPercentage = (double)player.Health / player.MaxHealth;

            // Handle the case where Player.Health is greater than Player.MaxHealth
            if (healthPercentage > 1)
            {
                healthPercentage = 1;
            }

            // Calculate the number of health bars to display
            int numHealthBars = (int)(healthPercentage * 10);

            // Print the health bars
            for (int i = 0; i < numHealthBars; i++)
            {
                Console.Write("#");
            }
        }
        else
        {
            Console.Write("N/A"); // Handle the case where MaxHealth is zero
        }

        Console.WriteLine();

        if (player.Health == 0)
        {
            Console.WriteLine("Game Over");
        }

    }
}
public class Player
{
    private int health;
    private int maxHealth;

    public Player(int maxHealth)
    {
        this.maxHealth = maxHealth;
        this.health = maxHealth;
    }

    public int Health
    {
        get { return health; }
        set { health = Math.Clamp(value, 0, maxHealth); }
    }

    public void TakeDamage(int damage)
    {
        int previousHealth = Health;
        Health -= damage;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Player took {damage} damage. Current health: {Health}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Health bar: {new string('█', Health)}{new string(' ', maxHealth - Health)}");
        Console.ResetColor();
    }

    public void Heal(int amount)
    {
        int previousHealth = Health;
        Health += amount;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Player healed for {amount} health. Current health: {Health}");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Health bar: {new string('█', previousHealth)}{new string(' ', maxHealth - previousHealth)}");
        Console.ResetColor();
    }

    public void Bar()
    {
        Console.WriteLine("Player Health:");

        if (MaxHealth != 0)
        {
            // Calculate the percentage of health remaining
            double healthPercentage = (double)Health / MaxHealth;

            // Handle the case where Player.Health is greater than Player.MaxHealth
            if (healthPercentage > 1)
            {
                healthPercentage = 1;
            }

            // Calculate the number of health bars to display
            int numHealthBars = (int)(healthPercentage * 10);

            // Print the health bars
            for (int i = 0; i < numHealthBars; i++)
            {
                Console.Write("#");
            }
        }
        else
        {
            Console.Write("N/A"); // Handle the case where MaxHealth is zero
        }

        Console.WriteLine();

        if (Health == 0)
        {
            Console.WriteLine("Game Over");
        }
    }
}
