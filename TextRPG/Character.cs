using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Character
    {
        private int level;
        public int Level { get { return level; } set { level = value; } }

        private string name;
        public string Name { get { return name; } set { name = value; } }

        private string myClass;
        public string MyClass { get { return name; } set { name = value; } }

        private int damage;
        public int Damage { get { return level; } set { level = value; } }

        private int defense;
        public int Defense { get { return level; } set { level = value; } }

        private int life;
        public int Life { get { return level; } set { level = value; } }

        private int gold;
        public int Gold { get { return level; } set { level = value; } }

        public List<Item> items = new List<Item>();

        public int addDamages;
        public int addDefense;
        public Character()
        {
            level = 0;
            name = null;
            myClass = null;
            damage = 0;
            defense = 0;
            life = 0;
            gold = 0;
            addDamages = 0;
            addDefense = 0;
        }
        public Character(int level, string name, string myClass, int damage, int defense, int life, int gold)

        {
            this.level = level;
            this.name = name;
            this.myClass = myClass;
            this.damage = damage;
            this.defense = defense;
            this.life = life;
            this.gold = gold;
            addDamages = 0;
            addDefense = 0;
        }

        public void addItem(Item item)
        {
            items.Add(item);
        }
        public void showStaters()
        {
            Console.WriteLine($"""  
                   lv. {level.ToString("00")}  
                   {name} ( {myClass} )  
                   공격력 : {damage} {(addDamages!= 0 ? $"(+{addDamages})" :"")}
                   방어력 : {defense} {(addDefense != 0 ? $"(+{addDefense})" : "")}
                   체 력 : {life}  
                   Gold : {gold} G               

                   """);
        }
        public int getItemLength()
        {
            return items.Count; 
        }
        
        public void showItems()
        {
            foreach (var item in items)
            {
                item.Show();
                Console.WriteLine();
            }
        }
        public void showItems(int num)
        {
            foreach (var item in items)
            {
                num++;
                item.ShowCount(num);
                Console.WriteLine();
            }
        }
        public void onOffTheItem(Item item)
        {
            if(!items.Contains(item)) return;

            if (!item.IsEquipped)
            {
                item.unEquipped();
                if (item.type == itemType.Armor) addDefense += item.point;
                if (item.type == itemType.Weapon) addDamages += item.point;
            }
            else
            {
                item.equipped();
                if (item.type == itemType.Armor) addDefense -= item.point;
                if (item.type == itemType.Weapon) addDamages -= item.point;
            }
        }
        public void onOffTheItem(int num)
        {
            int tempmun = num - 1;

            if(!items.Contains(items[tempmun])) return;
            if (!items[tempmun].IsEquipped)
            {
                items[tempmun].unEquipped();
                if (items[tempmun].type == itemType.Armor) addDefense += items[tempmun].point;
                if (items[tempmun].type == itemType.Weapon) addDamages += items[tempmun].point;
            }
            else
            {
                items[tempmun].equipped();
                if (items[tempmun].type == itemType.Armor) addDefense -= items[tempmun].point;
                if (items[tempmun].type == itemType.Weapon) addDamages -= items[tempmun].point;
            }
        }
    }
}
