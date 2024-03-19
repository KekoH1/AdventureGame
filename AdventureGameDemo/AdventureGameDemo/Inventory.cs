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

        public List<Item> Items {  get { return items; } }

        public Inventory() 
        {
            items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void UseHealthPotion(Player player, Potion healthPotion)
        {
            int healthToRestore = (int)(player.MaxHealth * healthPotion.healthRestoredPercentage / 100);
            player.Heal(healthToRestore);
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
