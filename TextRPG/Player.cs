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
        public int Level { get; set; }
        public int Exp { get; set; }
        public string Name { get; set; }
        public string MyClass { get; set; }
        public float Damage { get; set; }
        public float Defense { get; set; }
        public int Life { get; set; }
        public int Gold { get; set; }

        private List<Item> items = new List<Item>();
        public List<Item> Items { get { return items; }set { items = value; } }

        public Item myWeapon;
        public Item myArmor;

        public int addDamages;
        public int addDefense;

        public Player() { }
        public Player(int level, string name, string myClass, int damage, int defense, int life, int gold)

        {
            this.Level = level;
            this.Name = name;
            this.MyClass = myClass;
            this.Damage = damage;
            this.Defense = defense;
            this.Life = life;
            this.Gold = gold;
            Exp = 0;
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
                   상태 보기
                   캐릭터의 정보가 표시됩니다.

                   lv. {Level.ToString("00")}  
                   {Name}    : ( {MyClass} )  
                   공격력 : {Damage} {(addDamages != 0 ? $"(+{addDamages})" : "")}
                   방어력 : {Defense} {(addDefense != 0 ? $"(+{addDefense})" : "")}
                   체 력  : {Life}  
                   Gold   : {Gold} G               

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
                Damage += 0.5f;
                Defense += 1.0f;
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
        public void OnTheItem(int num)
        {
            OnTheItem(items[num-1]);
        }
        public void OnTheItem(Item item)
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
