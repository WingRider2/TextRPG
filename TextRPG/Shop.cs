using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Shop
    {
        List<Item> shopItems;
        public Shop() {
            shopItems = new List<Item>();
        }
        public void Add(Item item) { 
            shopItems.Add(item);
        }
        public int Length()
        {
            return shopItems.Count;
        }
        public void showItems()
        {
            foreach (var item in shopItems)
            {
                item.Show();
                if (item.Price != -1) Console.WriteLine($"{item.Price} G");
                if (item.Price == -1) Console.WriteLine("구매완료");
            }
        }
        public void showItems(int num)
        {
            foreach (var item in shopItems)
            {
                num++;
                item.ShowCount(num);
                if (item.Price != -1) Console.WriteLine($"{item.Price} G");
                if (item.Price == -1) Console.WriteLine("구매완료");
            }
        }
    }
}
