using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameDemo
{
    public class Inventory
    {
        private List<Item> items;
        private Player player;

        public List<Item> Items {  get { return items; } }

        public Inventory(Player player) 
        {
            items = new List<Item>();
            this.player = player;
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        

        private void UsePotion(Potion healthPotion, Player player)
        {
            int healthToRestore = Math.Min(player.MaxHealth - player.Health, 20);
            player.Health += healthToRestore;
            player.Health = Math.Min(player.Health, player.MaxHealth);
        }

        public void UseItem(int index, Player Player)
        {
            if (index >= 0 && index < Items.Count)
            {
                Item item = Items[index];
                if (item is Potion)
                {
                    UsePotion((Potion)item, player);
                    Items.RemoveAt(index);
                    Console.WriteLine($"{Player.Name} used {item.Name}");
                }
            }
        }

        public void PrintInventory()
        {
            Console.WriteLine("Inventory:");

            if (items.Count == 0) 
            {
                Console.WriteLine("Empty");
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {items[i].Name}");
                }
            }
        }
    }
}
