using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace TextRPG
{
    internal class Armor : Item
    {
        public Armor(string name, int defense, string itemEquipment, int? price) : base(name, itemEquipment, price)
        {
            this.point = defense;
            this.type = itemType.Armor;
        }
        public override void Show(int? num)
        {
            base.Show(num);
            Console.Write($"{Name} | 방어력 +{point} | {ItemEquipment} |");
        }

    }
}
