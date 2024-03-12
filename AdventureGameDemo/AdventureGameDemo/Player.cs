public class Player
{
    private int health;
    private int maxHealth;
    private int v;

    public Player()
    {
        maxHealth = 100;
        health = maxHealth;
    }

    public Player(int v)
    {
        this.v = v;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
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
}
