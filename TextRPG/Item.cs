using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Item
    {
        protected string name;
        public string Name { get { return name; } set { name = value; } }
        protected string itemEquipment;
        public string ItemEquipment{ get { return itemEquipment; } set { itemEquipment = value; } }

        protected bool isEquipped;
        public bool IsEquipped { get { return isEquipped; } set { isEquipped = value; } }
        protected int? price;
        public int? Price { get { return price; } set { price = value; } }
        protected int point { get; set; }
        public int Point { get { return point; } set { point = value; } }

        protected itemType type;
        public itemType Type { get { return type; } set { type = value; } }
        
        public Item(string name, string itemEquipment, int? price)
        {
            this.Name = name;
            this.ItemEquipment = itemEquipment;
            this.price = price;
            IsEquipped = false;
        }

        public virtual void Show(int? num)
        {
            if (num.HasValue) Console.Write($" - {num} ");
            else Console.Write(" - ");

            if (IsEquipped) Console.Write("[E]");
        }
        public virtual void Equipped()
        {
            IsEquipped = true;
        }
        public virtual void UnEquipped()
        {
            IsEquipped = false;
        }
    }
}
