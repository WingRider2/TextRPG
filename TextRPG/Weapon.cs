using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TextRPG
{
    internal class Weapon : Item
    {

        public Weapon(string name, int damage, string itemEquipment) : base(name, itemEquipment)
        {
            this.point = damage;
            this.type = itemType.Weapon;
        }
        public Weapon(string name, int damage, string itemEquipment,int price) : base(name, itemEquipment, price)
        {
            this.point = damage;
            this.type = itemType.Weapon;
        }

        public override void Show()
        {
            base.Show();
            Console.Write($"{Name} | 공격력 +{point} | {ItemEquipment} |");
        }
        public override void ShowCount(int num)
        {
            base.ShowCount(num);
            Console.Write($"{Name} | 공격력 +{point} | {ItemEquipment} |");
        }   
    }
}
