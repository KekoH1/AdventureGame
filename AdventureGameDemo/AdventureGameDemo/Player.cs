using AdventureGameDemo;
using System.Numerics;

/*public class Player
{
    private int health;
    private int maxHealth;

    public int Health { get; set; }
    public Stats Stats { get; set; }
    public int Endurance { get; set; }
    public object Inventory { get; internal set; }
    public int MaxHealth { get; internal set; }

    public object Name { get; internal set; }

    public int Strength { get; internal set; }
    public object PlayerInventory { get; internal set; }


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

    public void Bar(Player player)
    {
        Console.WriteLine("Player Health:");

        if (player.MaxHealth != 0)
        {
            // Calculate the percentage of health remaining
            double healthPercentage = (double)player.health / player.MaxHealth;

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
}*/
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
    public int Strength { get; internal set; }
    public object PlayerInventory { get; internal set; }

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


   /* public void PrintHealthBar()
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
    
*/

/*Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Health: " + health + "/" + maxHealth);*/
        


    
/*

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

>>>>>>> bd5f480b5b936cabaa5ede3f613123a5e505e644
*/