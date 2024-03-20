using AdventureGameDemo;
using System.Numerics;

public class Player
{
    private int health;
    private int maxHealth;

    public int Health { get; set; }
    public Stats Stats { get; set; }
    public int Endurance { get; set; }
    public object Inventory { get; internal set; }
    public int MaxHealth { get; internal set; }
    public object Name { get; internal set; }

    public Player()
    {
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
            health = 0;
        }
    }

    public void PrintHealthBar()
    {
        int healthPercentage = (int)((float)health / maxHealth * 100);
        string healthBar = "";

        for (int i = 0; i < 10; i++)
        {
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

    public int GetHealth()
    {
        return health;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    internal object GetStats()
    {
        throw new NotImplementedException();
    }

    internal void SetStats(Stats stats)
    {
        throw new NotImplementedException();
    }

    internal void Heal(int healthToRestore)
    {
        throw new NotImplementedException();
    }
}

