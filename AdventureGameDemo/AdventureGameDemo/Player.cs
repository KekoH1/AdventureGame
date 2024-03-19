using System;

namespace AdventureGameDemo
{
    public class Player
    {
        private int health;
        public int MaxHealth;

        public Player(int maxHealth)
        {
            this.MaxHealth = maxHealth;
            this.health = maxHealth;
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

        public void Heal(int amount)
        {
            int previousHealth = Health;
            Health += amount;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Player healed for {amount} health. Current health: {Health}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Health bar: {new string('█', previousHealth)}{new string(' ', MaxHealth - previousHealth)}");
            Console.ResetColor();
        }
    }
}