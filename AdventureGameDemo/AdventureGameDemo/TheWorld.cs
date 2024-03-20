
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using System;

namespace AdventureGameDemo
{
    public class TheWorld
    {
        public char[,] Grid;
        public int PlayerLocationX;
        public int PlayerLocationY;
        public int WorldSizeX;
        public int WorldSizeY;
        public List<Item> Items;

        public Inventory PlayerInventory;

        public List<Varelse> Varelser;

        public Potion item { get; private set; }
        public Player Player { get; private set; }

        public TheWorld()
        {
            WorldSizeX = 20;
            WorldSizeY = 50;

            Grid = new char[WorldSizeX, WorldSizeY];
            PlayerLocationX = 2;
            PlayerLocationY = 2;
            Items = new List<Item>();
            PlayerInventory = new Inventory();
            Varelser = new List<Varelse>();
            Player = new Player();

            CreateWorld();

            Grid[PlayerLocationX, PlayerLocationY] = 'P';
        }

        //Spelplan
        public void CreateWorld()
        {
            for (int i = 0; i < WorldSizeX; i++)
            {
                for (int j = 0; j < WorldSizeY; j++)
                {
                    if (i == 0 || i == WorldSizeX - 1 || j == 0 || j == WorldSizeY - 1)
                    {
                        Grid[i, j] = '#';
                    }
                    else
                    {
                        Grid[i, j] = ' ';
                    }
                }
            }
        }
        //Items

        // separerade items till vapen och potions så de blir enklare 
        public void GenerateRandomWeapons(int numberOfWeapons)
        {
            Random random = new Random();

            string[] weaponNames = { "Sword", "Axe", "Staff" };

            for (int i = 0; i < numberOfWeapons; i++)
            {
                int randomX = random.Next(1, WorldSizeX - 1);
                int randomY = random.Next(1, WorldSizeY - 1);

                string weaponName = weaponNames[random.Next(weaponNames.Length)];
                int damage = random.Next(5, 20);

                Weapon newWeapon = new Weapon(randomX, randomY, 'W', weaponName, damage);

                Items.Add(newWeapon);
                Grid[randomX, randomY] = newWeapon.Symbol;

            }
        }

        public void GenerateRandomPotions(int numberOfPotions)
        {
            Random random = new Random();
            string[] potionsNames = { "Health Potion" };

            for (int i = 0; i < numberOfPotions; i++)
            {
                int randomX = random.Next(1, WorldSizeX - 1);
                int randomY = random.Next(1, WorldSizeY - 1);

                string potionName = potionsNames[random.Next(potionsNames.Length)];
                int healingPower = random.Next(10, 30);

                Potion existingPotion = (Potion)Items.FirstOrDefault(item => item is Potion && item.Name == potionName && ((Potion)item).StackSize < 3);

                if (existingPotion != null)
                {
                    ((Potion)existingPotion).StackSize++;
                }
                else
                {
                    Potion newPotion = new Potion(randomX, randomY, 'I', potionName, healingPower, 1);
                    Items.Add(newPotion);
                    Grid[randomX, randomY] = newPotion.Symbol;
                }
            }
        }


        //Varelser
        public void GenerateRandomVarelsers(int numberOfVarelser)
        {
            Random random = new Random();
            for (int i = 0; i < numberOfVarelser; i++)
            {
                int randomX = random.Next(1, WorldSizeX - 1);
                int randomY = random.Next(1, WorldSizeY - 1);
                string VarelsersName = "Varelse" + (i + 1);

                while (IsPositionOccupied(randomX, randomY))
                {
                    randomX = random.Next(1, WorldSizeX - 1);
                    randomY = random.Next(1, WorldSizeY - 1);
                }

                int strength = random.Next(1, 10);
                int endurance = random.Next(1, 10);
                int agility = random.Next(1, 10);

                Varelse newVarelse = new Varelse(randomX, randomY, 'V', VarelsersName, strength, endurance, agility);
                Varelser.Add(newVarelse);
                Grid[randomX, randomY] = newVarelse.Symbol;

            }

        }

        private bool IsPositionOccupied(int randomX, int randomY)
        {
            if (Grid[randomX, randomY] != ' ')
            {
                return true;
            }
            return false;
        }

        public void PrintWorld()
        {
            Console.Clear();

            for (int i = 0; i < WorldSizeX; i++)
            {
                for (int j = 0; j < WorldSizeY; j++)
                {
                    Console.Write(Grid[i, j]);
                }

                Console.WriteLine();
            }


            int itemsAndInventoryX = WorldSizeY + 2;
            int itemsAndInventoryY = 0;

            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(itemsAndInventoryX, itemsAndInventoryY++);
            Console.WriteLine("Items: ");

            foreach (Item item in Items)
            {
                Console.SetCursorPosition(itemsAndInventoryX, itemsAndInventoryY++);
                Console.WriteLine($"{item.Name}");
            }

            Console.SetCursorPosition(itemsAndInventoryX, itemsAndInventoryY++);
            Console.WriteLine(new string('-', 20));

            Console.SetCursorPosition(itemsAndInventoryX, itemsAndInventoryY++);
            Console.WriteLine("Inventory: ");

            for (int i = 0; i < PlayerInventory.Items.Count; i++)
            {
                Console.SetCursorPosition(itemsAndInventoryX, itemsAndInventoryY++);
                Console.WriteLine($"{i + 1}. {PlayerInventory.Items[i].Name}");
            }

            Console.ForegroundColor = ConsoleColor.Gray;

            // Print Health Bar
            int healthBarX = WorldSizeY + 2;
            int healthBarY = itemsAndInventoryY + 2;

            Console.SetCursorPosition(healthBarX, healthBarY++);
            Console.WriteLine("Health Bar:");

            Console.SetCursorPosition(healthBarX, healthBarY++);
            Console.WriteLine($"Player's Health: {Player.Health}");

            Console.SetCursorPosition(healthBarX, healthBarY++);
            Console.WriteLine(new string('-', 20));
        }


        public void PlayerMovement()
        {
            ConsoleKeyInfo KeyInfo = Console.ReadKey(true);
            Console.Clear();


            int newPlayerLocationX = PlayerLocationX;
            int newPlayerLocationY = PlayerLocationY;

            switch (KeyInfo.Key)
            {
                case ConsoleKey.RightArrow:
                    newPlayerLocationY++;
                    break;

                case ConsoleKey.LeftArrow:
                    newPlayerLocationY--;
                    break;

                case ConsoleKey.UpArrow:
                    newPlayerLocationX--;
                    break;

                case ConsoleKey.DownArrow:
                    newPlayerLocationX++;
                    break;
            }


            if (newPlayerLocationX > 0 && newPlayerLocationX < WorldSizeX - 1 &&
                newPlayerLocationY > 0 && newPlayerLocationY < WorldSizeY - 1)
            {
                Grid[newPlayerLocationX, newPlayerLocationY] = 'P';
                Grid[PlayerLocationX, PlayerLocationY] = ' ';
                PlayerLocationX = newPlayerLocationX;
                PlayerLocationY = newPlayerLocationY;

                Varelse varelseAtPlayerPosition = GetVarelseAtPosition(PlayerLocationX, PlayerLocationY);
                if (varelseAtPlayerPosition != null)
                {
                    Combat(Player, varelseAtPlayerPosition);
                }
            }

            for (int i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];
                if (PlayerLocationX == item.X && PlayerLocationY == item.Y)
                {
                    Console.WriteLine($"Player picked up {item.Name}");
                    Console.ReadLine();
                    PlayerInventory.AddItem(item);
                    Items.Remove(item);
                    PlayerInventory.PrintInventory();
                    break;
                }
            }

            PrintWorld();

            foreach (Item item in Items)
            {
                if (PlayerLocationX == item.X && PlayerLocationY == item.Y)
                {
                    /*Console.WriteLine($"Player picked up {item.Name}");*/ // skapa en inventory klass som skriver ut vilka items man har
                    Items.Remove(item);
                    break;
                }
            }

            if (item is Potion && ((Potion)item).Name == "Health Potion")
            {
                PlayerInventory.UseHealthPotion(Player, (Potion)item);
            }
        }



        public void Combat(Player player, Varelse varelse)
        {
            Console.WriteLine($"Player and {varelse.Name} are in combat!");

            while (player.Health > 0 && varelse.Health > 0)
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Attack 1 (Strength: 10)");
                Console.WriteLine("2. Attack 2 (Strength: 15)");
                Console.WriteLine("3. Run away");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Console.Clear();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        Attack(player, varelse, 10);
                        break;

                    case ConsoleKey.D2:
                        Attack(player, varelse, 15);
                        break;

                    case ConsoleKey.D3:
                        Console.WriteLine("Player ran away from combat!");
                        return;

                    default:
                        Console.WriteLine("Invalid action. Please choose a valid action.");
                        break;
                }

                if (varelse.Health > 0)
                {
                    VarelseAttack(player, varelse, 10);
                }
            }

            Console.WriteLine($"Player's Health: {player.Health}");
            Console.WriteLine($"{varelse.Name}'s Health: {varelse.Health}");

            if (player.Health <= 0)
            {
                Console.WriteLine("Player is defeated!");
            }
            else if (varelse.Health <= 0)
            {
                Console.WriteLine($"{varelse.Name} is defeated!");
            }
        }

        private void Attack(Player player, Varelse varelse, int strength)
        {
            int playerAttackDamage = player.Strength * strength;
            varelse.Health -= playerAttackDamage;

            Console.WriteLine($"Player deals {playerAttackDamage} damage to {varelse.Name}");
        }

        private void VarelseAttack(Player player, Varelse varelse, int strength)
        {
            int varelseAttackDamage = varelse.Strength * strength;
            player.Health -= varelseAttackDamage;

            Console.WriteLine($"{varelse.Name} deals {varelseAttackDamage} damage to Player");
        }
        public Varelse GetVarelseAtPosition(int x, int y)
        {
            foreach (Varelse varelse in Varelser)
            {
                if (varelse.X == x && varelse.Y == y)
                {
                    return varelse;
                }
            }
            return null;
        }

        internal void PrintHealthBar()
        {
            int PrintHealthBar = WorldSizeY + 2;
        }
    }
}
