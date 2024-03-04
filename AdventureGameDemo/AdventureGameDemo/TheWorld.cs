
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
        public List<Varelse> Varelser;

        public TheWorld()
        {
            WorldSizeX = 10;
            WorldSizeY = 10;

            Grid = new char[WorldSizeX, WorldSizeY];
            PlayerLocationX = 2;
            PlayerLocationY = 2;
            Items = new List<Item>();
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
        public void GenerateRandomItems(int numberOfItems)
        {
            Random random = new Random();

            for (int i = 0; i < numberOfItems; i++)
            {
                int randomX = random.Next(1, WorldSizeX - 1);
                int randomY = random.Next(1, WorldSizeY - 1);
                string itemName = "Item" + (i + 1);

                Item newItem = new Item(randomX, randomY, 'I', itemName);
                Items.Add(newItem);
                Grid[randomX, randomY] = newItem.Symbol;
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

        internal void PrintHealthBar()
        {
            throw new NotImplementedException();
        }
    }
}
