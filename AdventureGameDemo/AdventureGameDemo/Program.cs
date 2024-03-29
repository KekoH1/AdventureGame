﻿using AdventureGameDemo;

namespace AdventurGameDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TheWorld World = new TheWorld();
            /*Player Player = new Player(100);*/
            Player Player = new Player();

            World.GenerateRandomWeapons(2);
            World.GenerateRandomPotions(5);
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
