using AdventureGameDemo;

namespace AdventurGameDemo
{
    public class Program
    {

        public static void Main(string[] args)
        {
            TheWorld World = new TheWorld();
            World.GenerateRandomItems(4);
            World.GenerateRandomVarelsers(3);
            while (true)
            {
                World.PrintWorld();
                World.PrintHealthBar(); 
                World.PlayerMovement();
            }
        }
    }
}
