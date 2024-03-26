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

        public void UseItem(int itemIndex, Player player)
        {
            if (itemIndex >= 0 && itemIndex < items.Count){
                Item item = items[itemIndex];
                if (item is Potion && player.Health < player.MaxHealth)
                {
                    Potion healthPotion = (Potion)item;
                    int healthToRestore = Math.Min(player.MaxHealth - player.Health, 20);
                    player.Health += healthToRestore;
                    Console.WriteLine($"Player used {healthPotion.Name} and restored {healthToRestore} health.");
                    items.RemoveAt(itemIndex);
                }
                else
                {
                    Console.WriteLine("Cannot use this item.");
                }
            }
            else { Console.WriteLine("Invalid item index."); }
        }

        /*public void UseHealthPotion(Player player, Potion healthPotion)
        {
            int healthToRestore = (int)(player.MaxHealth * healthPotion.healthRestoredPercentage / 100);
            player.Heal(healthToRestore);
        }*/

        public void PrintInventory()
        {
            Console.WriteLine("Inventory:");

            if (items.Count == 0) 
            {
                Console.WriteLine("Empty");
            }
            else
            {
                foreach (var item in items)
                {
                    Console.WriteLine($"{item.Name}");
                }
            }
        }
    }
}
