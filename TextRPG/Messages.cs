using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Messages
    {
        public static Messages instance;
        public static Messages Instance()
        {
            if (instance == null)
            {
                instance = new Messages();
            }
            return instance;
        }
        public void StartMessages()
        {
            Console.Write(
                """     
                스파르타 마을에 오신 여러분 환영합니다.
                이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.

                1. 상태 보기
                2. 인벤토리
                3. 상점
                4. 던전입장
                5. 휴식하기

                원하시는 행동을 입력해주세요.
                >>
                """);
        }
        public void StatersMessages(Character character)
        {
            character.ShowStaters();
            Console.Write(
                """              
                0. 나가기    
                
                원하시는 행동을 입력해주세요.   
                >>
                """);
        }
        public void InventoryMessages(Character character)
        {
            Console.WriteLine("[아이템 목록]");
            character.ShowItems(null);
            Console.Write(
                """    
                
                1. 장착 관리
                0. 나가기

                원하시는 행동을 입력해주세요.   
                >>
                """);
        }
        public void InventoryEquipItemsMessages(Character character)
        {
            Console.WriteLine("""       
                인벤토리 - 장착 관리
                
                보유 중인 아이템을 관리할 수 있습니다.

                [아이템 목록]
                """
                );
                
            character.ShowItems(0);
            Console.Write(
                """

                0. 나가기

                원하시는 행동을 입력해주세요.  
                >>
                """);
        }
        public void ShopMessages(Character character, Shop shop , bool isBuyWindow,bool isSellWindow)
        {
            Console.WriteLine(
                $"""      
                [보유 골드]
                {character.Gold} G

                [아이템 목록]

                """
                );
            if (isBuyWindow)
            {
                shop.ShowItems(0);
            }
            if (isSellWindow)
            {
                character.ShowItems(0);
            }
            else
            {
                shop.ShowItems(null);
                Console.WriteLine(
                    """
                    
                    1. 아이템 구매
                    2. 아이템 판매
                    """);
            }

            Console.Write(
                """                    
                0. 나가기

                원하시는 행동을 입력해주세요.   
                >>
                """);
        }
        public void BreakTimeMessages(Character character)
        {
            Console.WriteLine(
                $"""
                500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {character.Gold} G)

                1. 휴식하기
                0. 나가기

                원하시는 행동을 입력해주세요.
                >>
                
                """);
        }
        public void NotEnoughGold()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Gold 가 부족합니다. ");
            Console.ResetColor();
        }
        public void ErrorMessages()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(
                """               
                잘못된 입력입니다.
                """);
            Console.ResetColor();
        }
        public void ErrorMessages(Stage stage)
        {
            Console.WriteLine(
                $"""           
                {stage}
                잘못된 입력입니다.
                """);
        }
    }
}
