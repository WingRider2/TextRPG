using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Item
    {
        protected string Name { get; set; }
        protected string ItemEquipment { get; set; }
        public bool IsEquipped { get; set; }
        public int price { get; set; }

        public int point { get; set; }
        public itemType type { get; set; }
        public Item(string name, string itemEquipment)
        {
            this.Name = name;
            this.ItemEquipment = itemEquipment;
            this.price = -1;
            IsEquipped = false;            
        }
        public Item(string name, string itemEquipment, int price)
        {
            this.Name = name;
            this.ItemEquipment = itemEquipment;
            this.price = price;
            IsEquipped = false;
        }

        public virtual void Show()
        {
            Console.Write(" - ");
            if (IsEquipped) Console.Write("[E]");
        }
        public virtual void ShowCount(int num)
        {            
            Console.Write($" - {num} ");
            if (IsEquipped) Console.Write("[E]");
        }
        public virtual void equipped()
        {
            IsEquipped = true;
        }
        public virtual void unEquipped()
        {
            IsEquipped = false;
        }
    }
}
