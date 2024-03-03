using AdventureGameDemo;

namespace AdventurGameDemo
{
    public class Program
    {

        public static void Main(string[] args)
        {
            TheWorld World = new TheWorld();
            World.GenerateRandomWeapons(2);
            World.GenerateRandomPotions(3);
            World.GenerateRandomVarelsers(3);


            while (true)
            {
                World.PrintWorld();
                World.PlayerMovement();
            }
        }
    }
}
