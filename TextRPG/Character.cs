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

        private List<Item> items = new List<Item>();

        private int addDamages;
        private int addDefense;
        //### 장착 개선 (난이도 - ★★☆☆☆)

        //- 각 타입별로 하나의 아이템만 장착가능 - (방어구 / 무기 )
        //- 방어구를 장착하면 기존 방어구가 있다면 해제하고 장착
        //- 무기를 장착하면 기존 무기가 있다면 해제하고 장착
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
                if (item.Type == itemType.Armor) addDefense += item.Point;
                if (item.Type == itemType.Weapon) addDamages += item.Point;
            }
            else
            {
                item.equipped();
                if (item.Type == itemType.Armor) addDefense -= item.Point;
                if (item.Type == itemType.Weapon) addDamages -= item.Point;
            }
        }
        public void onOffTheItem(int num)
        {
            int tempmun = num - 1;

            if(!items.Contains(items[tempmun])) return;
            if (!items[tempmun].IsEquipped)
            {
                items[tempmun].unEquipped();
                if (items[tempmun].Type == itemType.Armor) addDefense += items[tempmun].Point;
                if (items[tempmun].Type == itemType.Weapon) addDamages += items[tempmun].Point;
            }
            else
            {
                items[tempmun].equipped();
                if (items[tempmun].Type == itemType.Armor) addDefense -= items[tempmun].Point;
                if (items[tempmun].Type == itemType.Weapon) addDamages -= items[tempmun].Point;
            }
        }
    }
}
