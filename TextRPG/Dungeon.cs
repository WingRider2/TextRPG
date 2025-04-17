using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Dungeon
    {
        private DunjeonType type;
        public DunjeonType Type { get { return type; } }
        private int recommendDefense;
        public int RecommendDefense { get { return recommendDefense; } }
        private int clearGold;
        public int ClearGold {  get { return clearGold; } }
        public Dungeon(DunjeonType dunjeonType , int Defense  , int Gold)
        {
            type = dunjeonType;
            recommendDefense = Defense;
            clearGold = Gold;
        }
        public void show(int num)
        {
            Console.WriteLine($"{num}. {type.ToString(),6} | 방어력 {recommendDefense,2} 이상 권장");
        }

        public bool ComeInPlayer(Player player)
        {
            if (player.GetPlayerDefense()> recommendDefense)
            {
                Clear(player);
                return true;
            }
            else
            {
                if(isClear())
                {
                    Clear(player);
                    return true;
                }
                else
                {
                    lose(player);
                    return false;
                }
            }         

        }
        public bool isClear()
        {
            Random rnd = new Random();
            int num=rnd.Next(0, 100);
            return num > 40;
        }
        public void Clear(Player player)
        {
            Random rnd = new Random();
            int randLife = rnd.Next(20, 35);
            int randGold = rnd.Next((int)player.GetPlayerDamages(), (int)player.GetPlayerDamages() * 2);
            player.Hit(randLife + (int)(player.GetPlayerDefense() - recommendDefense));
            player.TakeGold(player.Gold * randGold / 100);
        }
        public void lose(Player player)
        {
            player.Hit(player.Life/2);
        }
    }
}
