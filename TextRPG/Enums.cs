using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    enum Stage
    {
        None,
        Start,
        Staters,
        Inventory,
        InventoryEquipItems,
        Shop,
        ShopBuyWindow,
        ShopSellWindow,
        DungeonSelection,
        DungeonEnd,
        BreakTime,
        GameOver
    }
    enum itemType
    {
        None,
        Armor,
        Weapon
    }
    enum DunjeonType
    {
        None,
        Easy,
        Normal,
        Hard
    }
}
