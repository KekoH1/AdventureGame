
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

        public TheWorld()
        {
            WorldSizeX = 10;
            WorldSizeY = 10;

            Grid = new char[WorldSizeX, WorldSizeY];
            PlayerLocationX = 2;
            PlayerLocationY = 2;
            Items = new List<Item>();
            PlayerInventory = new Inventory();
            Varelser = new List<Varelse>();

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
                int randomX = random.Next(1, WorldSizeX -1 );
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
            string[] potionsNames = { "Health Potion", "Mana Potion", "Strenght Potion" };

            for (int i = 0; i < numberOfPotions;i++)
            {
                int randomX = random.Next(1, WorldSizeX - 1 );
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
        

        /*public void GenerateRandomItems(int numberOfItems)

        {
            Random random = new Random();

            for (int i = 0; i < numberOfItems; i++)
            {
                int randomX = random.Next(1, WorldSizeX - 1);
                int randomY = random.Next(1, WorldSizeY - 1);

                
                Type itemType = random.Next(2) == 0 ? typeof(Weapon) : typeof(Potion);

                Item newItem = null;

                if (itemType == typeof(Weapon))
                {
                newItem = new Weapon(randomX, randomY, "Sword", 10);
                }
                else if (itemType == typeof(Potion))
                {
                    newItem = new Potion(randomX, randomY, "Health Potion", 20);
                }

                Items.Add(newItem);

                Grid[randomX, randomY] = newItem.Symbol;
            }
            
        }*/

           /*     string itemName = "Item" + (i + 1);

                Item newItem = new Item(randomX, randomY, 'I', itemName);
                Items.Add(newItem);
                Grid[randomX, randomY] = newItem.Symbol;
            }
        }*/

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
                    /*Console.WriteLine($"Möter {varelseAtPlayerPosition.Name}");*/ // klass för combat
                }
            }


            for (int i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];   
                if (PlayerLocationX == item.X && PlayerLocationY == item.Y)
                {
                    Console.WriteLine($"Player picked up {item.Name}");
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



       /* internal void PrintHealthBar()
        {
            throw new NotImplementedException();
        }*/

    }
}
