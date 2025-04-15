using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TextRPG
{
    internal class Player : IShowItem
    {
        private int level;
        public int Level { get { return level; } set { level = value; } }
        private int exp;
        public int Exp { get { return exp; } set { exp = value; } }
        private string name;
        public string Name { get { return name; } set { name = value; } }

        private string myClass;
        public string MyClass { get { return myClass; } set { myClass = value; } }

        private float damage;
        public float Damage { get { return damage; } set { damage = value; } }

        private float defense;
        public float Defense { get { return defense; } set { defense = value; } }

        private int life;
        public int Life { get { return life; } set { life = value; } }

        private int gold;
        public int Gold { get { return gold; } set { gold = value; } }

        private List<Item> items = new List<Item>();
        public List<Item> Items { get { return items; } }
        private Item myWeapon;
        private Item myArmor;

        private int addDamages;
        private int addDefense;

        public Player(int level, string name, string myClass, int damage, int defense, int life, int gold)

        {
            this.level = level;
            this.name = name;
            this.myClass = myClass;
            this.damage = damage;
            this.defense = defense;
            this.life = life;
            this.gold = gold;
            exp = 0;
            addDamages = 0;
            addDefense = 0;
        }
        public int GetPlayerDamages()
        {
            return (int)Damage+addDamages;
        }
        public int GetPlayerDefense()
        {
            return (int)Defense + addDefense;
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
        public void LevelUP(int num)
        {
            Exp += num;
            if(Exp==Level)
            {
                damage += 0.5f;
                defense += 1.0f;
                Level++;
                Exp = 0;
            }
        }
        public void Hit(int num)
        {
            Life-=num;
        }       
        public void TakeGold(int num)
        {
            Gold += num;
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
        public void OnOffTheItem(int num)
        {
            OnOffTheItem(items[num-1]);
        }
        public void OnOffTheItem(Item item)
        {
            if (!items.Contains(item)) return; 

            if (item.Type == itemType.Armor)
            {
                if (myArmor != null)
                {
                    addDefense -= myArmor.Point;
                    myArmor.UnEquipped();
                }
                item.Equipped();
                myArmor = item;                   
                addDefense += item.Point;
            }
            if (item.Type == itemType.Weapon)
            {
                if (myWeapon != null)
                {
                    addDamages -= myWeapon.Point;
                    myWeapon.UnEquipped();
                }
                item.Equipped();
                myWeapon = item;
                addDamages += item.Point;
            }
        }

    }
}
