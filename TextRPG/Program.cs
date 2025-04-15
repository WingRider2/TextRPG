namespace TextRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Character kim = new Character(1, "kim", "전사", 10, 5, 100, 1500);

            Armor armor1 = new Armor("무쇠갑옷", 5, "무쇠로 만들어져 튼튼한 갑옷입니다.", 1800);
            Weapon weapon1 = new Weapon("스파르타의 창", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 2700);
            Weapon weapon2 = new Weapon("낡은 검", 2, "쉽게 볼 수 있는 낡은 검 입니다.", 600 );

            kim.AddItem(armor1);
            kim.AddItem(weapon1);
            kim.AddItem(weapon2);
            kim.OnOffTheItem(weapon1);
            kim.OnOffTheItem(armor1);

            Shop shop = new Shop();
            shop.Add(new Armor("수련자 갑옷", 5, "수련에 도움을 주는 갑옷입니다.", 1000));
            shop.Add(new Armor("무쇠갑옷", 9, "무쇠로 만들어져 튼튼한 갑옷입니다. ", null));
            shop.Add(new Armor("스파르타의 갑옷", 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500));
            shop.Add(new Armor("김광민의 갑옷", 20, "스파르타의 전사중 가장 강한 전사의 갑옷입니다.", 10000));
            shop.Add(new Weapon("낡은 검", 2, "쉽게 볼 수 있는 낡은 검 입니다.  ", null));
            shop.Add(new Weapon("청동 도끼", 5, "어디선가 사용됐던거 같은 도끼입니다.  ", 1500));
            shop.Add(new Weapon("스파르타의 창 ", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.  ", null));
            shop.Add(new Weapon("김광민 방방이 ", 20, "스파르타의 전사중 가장 강한 전사의 형태를 한 몽둥이입니다.  ", 10000));

            Stage state = Stage.Start;
            int input;
            bool isneedErrorMessages = true;
            while (true)
            {
                try
                {
                    Console.Clear();
                    if (!isneedErrorMessages)
                    {
                        Messages.Instance().ErrorMessages(state);
                        isneedErrorMessages = false;
                    }
                    switch (state)
                    {
                        case Stage.Start:
                            Messages.Instance().StartMessages();
                            input = int.Parse(Console.ReadLine());
                            if (input == 1) state = Stage.Staters;
                            else if (input == 2) state = Stage.Inventory;
                            else if (input == 3) state = Stage.Shop;
                            else if (input == 5) state = Stage.BreakTime;
                            else
                            {
                                isneedErrorMessages = false;
                            }
                            break;
                        case Stage.Staters:
                            Messages.Instance().StatersMessages(kim);
                            input = int.Parse(Console.ReadLine());
                            if (input == 0) state = Stage.Start;
                            else
                            {
                                isneedErrorMessages = false;
                            }
                            break;
                        case Stage.Inventory:
                            Messages.Instance().InventoryMessages(kim);
                            input = int.Parse(Console.ReadLine());
                            if (input == 0) state = Stage.Start;
                            if (input == 1) state = Stage.InventoryEquipItems;
                            else
                            {
                                isneedErrorMessages = false;
                            }
                            break;
                        case Stage.InventoryEquipItems:
                            Messages.Instance().InventoryEquipItemsMessages(kim);
                            input = int.Parse(Console.ReadLine());

                            if (input == 0)
                            {
                                state = Stage.Inventory;
                            }
                            else if (input > 0 && input <= kim.GetItemLength())
                            {
                                kim.OnOffTheItem(input);
                            }
                            else
                            {
                                isneedErrorMessages = false;
                            }
                            break;
                        case Stage.Shop:
                            Messages.Instance().ShopMessages(kim, shop, false, false);
                            input = int.Parse(Console.ReadLine());
                            if (input == 0) state = Stage.Start;
                            else if (input == 1) state = Stage.ShopBuyWindow;
                            else if (input == 2) state = Stage.ShopSellWindow;
                            else
                            {
                                isneedErrorMessages = false;
                            }
                            break;
                        case Stage.ShopBuyWindow:
                            Messages.Instance().ShopMessages(kim, shop, true, false);
                            input = int.Parse(Console.ReadLine());

                            if (input == 0)
                            {
                                state = Stage.Shop;
                            }
                            else if (input > 0 && input < shop.Length())
                            {
                                shop.SellItem(kim, input);
                            }
                            else
                            {
                                isneedErrorMessages = false;
                            }
                            break;
                        case Stage.ShopSellWindow:
                            Messages.Instance().ShopMessages(kim, shop, false, true);
                            input = int.Parse(Console.ReadLine());

                            if (input == 0)
                            {
                                state = Stage.Shop;
                            }
                            else if (input > 0 && input <= kim.GetItemLength())
                            {
                                shop.BuyItem(kim, input);
                            }
                            else
                            {
                                isneedErrorMessages = false;
                            }
                            break;
                        case Stage.BreakTime:
                            Messages.Instance().BreakTimeMessages(kim);
                            input = int.Parse(Console.ReadLine());

                            if (input == 0)
                            {
                                state = Stage.Start;
                            }
                            else if (input == 1)
                            {
                                kim.TakeBreakTime();
                            }
                            else
                            {
                                isneedErrorMessages = false;
                            }
                            break;

                      
                        //### 레벨업 기능 추가 (난이도 - ★★☆☆☆)

                        //던전입장 기능 추가

                        //게임 저장하기 추가

                        default: break;
                    }
                }
                catch (FormatException) { isneedErrorMessages = false; }

            }

        }
    }


}
