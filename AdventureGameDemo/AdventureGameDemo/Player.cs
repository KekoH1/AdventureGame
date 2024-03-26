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
    public int Strength { get; internal set; }
    public object PlayerInventory { get; internal set; }

    public Player()
    {
        maxHealth = 100;
        Health = maxHealth;
        Stats = new Stats();
        Strength = 1;
        Endurance = 8;

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

}
