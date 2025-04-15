using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Shop : IShowItem
    {
        List<Item> shopItems;
        public Shop()
        {
            shopItems = new List<Item>();
        }
        public void Add(Item item)
        {
            shopItems.Add(item);
        }
        public int Length()
        {
            return shopItems.Count;
        }
        public void SellItem(Character character, int num)
        {
            int itemNum = num - 1;
            if (character.Gold < shopItems[itemNum].Price)
            {
                Messages.Instance().NotEnoughGold();
            }
            else
            {
                character.BuyItem(shopItems[itemNum]);
                shopItems[itemNum].Price = null;
            }

        }
        public void BuyItem(Character character, int num)
        {
            int itemNum = num - 1;
            shopItems.Find(n => n.Name == character.Items[itemNum].Name).Price = character.Items[itemNum].Price;
            character.SelItem(itemNum);
            

        }
        public void ShowItems(int? num)
        {
            foreach (var item in shopItems)
            {
                if (num.HasValue) num++;
                item.Show(null);
                if (item.Price.HasValue) Console.WriteLine($"{item.Price} G");
                else Console.WriteLine("구매완료");
            }
        }
    }
}
