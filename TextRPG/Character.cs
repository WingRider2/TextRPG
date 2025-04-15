using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Character : IShowItem
    {
        private int level;
        public int Level { get { return level; } set { level = value; } }

        private string name;
        public string Name { get { return name; } set { name = value; } }

        private string myClass;
        public string MyClass { get { return myClass; } set { myClass = value; } }

        private int damage;
        public int Damage { get { return damage; } set { damage = value; } }

        private int defense;
        public int Defense { get { return defense; } set { defense = value; } }

        private int life;
        public int Life { get { return life; } set { life = value; } }

        private int gold;
        public int Gold { get { return gold; } set { gold = value; } }

        private List<Item> items = new List<Item>();
        public List<Item> Items { get { return items; } }
        private int addDamages;
        private int addDefense;
        //### 장착 개선 (난이도 - ★★☆☆☆)

        //- 각 타입별로 하나의 아이템만 장착가능 - (방어구 / 무기 )
        //- 방어구를 장착하면 기존 방어구가 있다면 해제하고 장착
        //- 무기를 장착하면 기존 무기가 있다면 해제하고 장착

        //### 레벨업 기능 추가 (난이도 - ★★☆☆☆)
        //- 던전을 여러번 클리어할 수록 레벨이 증가합니다.
        //    - Lv1 → Lv2 - 1회 클리어
        //    - Lv2 → Lv3 - 2회 클리어
        //    - Lv3 → Lv4 - 3회 클리어
        //    - Lv4 → Lv5 - 4회 클리어
        //- 레벨업시 기본 공격력이 0.5 방어력이 1 증가합니다.
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

        public void AddItem(Item item)
        {
            items.Add(item);
        }
        public void ShowStaters()
        {
            Console.WriteLine($"""  
                   lv. {level.ToString("00")}  
                   {name} ( {myClass} )  
                   공격력 : {damage} {(addDamages != 0 ? $"(+{addDamages})" : "")}
                   방어력 : {defense} {(addDefense != 0 ? $"(+{addDefense})" : "")}
                   체 력 : {life}  
                   Gold : {gold} G               

                   """);
        }
        public int GetItemLength()
        {
            return items.Count;
        }
        //마을객체 생기면 옮기기 *그때는 쉴 캐릭터 정보 받아야함
        public void TakeBreakTime()
        {
            if (Gold > 500)
            {
                Life = 100;
                Gold -= 500;
            }
            else
            {
                Messages.Instance().NotEnoughGold();
            }

        }

        public void ShowItems(int? num)
        {
            foreach (var item in items)
            {
                if (num.HasValue) num++;
                item.Show(num);
                Console.WriteLine();
            }
        }
        public void BuyItem(Item item)
        {
            Gold -= item.Price.Value;
            items.Add(item);
        }
        public void SelItem(int num)
        {
            Gold += items[num].Price.Value * 85 / 100;
            items.RemoveAt(num);
        }
        public void OnOffTheItem(Item item)
        {
            if (!items.Contains(item)) return;

            if (!item.IsEquipped)
            {
                item.Equipped();
                if (item.Type == itemType.Armor) addDefense += item.Point;
                if (item.Type == itemType.Weapon) addDamages += item.Point;
            }
            else
            {
                item.UnEquipped();
                if (item.Type == itemType.Armor) addDefense -= item.Point;
                if (item.Type == itemType.Weapon) addDamages -= item.Point;
            }
        }
        public void OnOffTheItem(int num)
        {
            int tempmun = num - 1;

            if (!items.Contains(items[tempmun])) return;
            if (!items[tempmun].IsEquipped)
            {
                items[tempmun].Equipped();
                if (items[tempmun].Type == itemType.Armor) addDefense += items[tempmun].Point;
                if (items[tempmun].Type == itemType.Weapon) addDamages += items[tempmun].Point;
            }
            else
            {
                items[tempmun].UnEquipped();
                if (items[tempmun].Type == itemType.Armor) addDefense -= items[tempmun].Point;
                if (items[tempmun].Type == itemType.Weapon) addDamages -= items[tempmun].Point;
            }
        }
    }
}
