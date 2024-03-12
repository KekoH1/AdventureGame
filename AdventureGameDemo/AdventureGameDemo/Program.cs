using AdventureGameDemo;

namespace AdventurGameDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TheWorld World = new TheWorld();
            Player Player = new Player(100);

            World.GenerateRandomWeapons(2);
            World.GenerateRandomPotions(3);
            World.GenerateRandomVarelsers(3);

            while (true)
            {
                World.PrintWorld();
                Player.PrintHealthBar(); // Uncomment this line to print the player's health bar

                World.PlayerMovement();
            }
        }
    }
}
