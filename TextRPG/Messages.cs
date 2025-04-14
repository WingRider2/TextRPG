using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Messages
    {
        public void StartMessages()
        {
            Console.Write(
                """     
                스파르타 마을에 오신 여러분 환영합니다.
                이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.

                1. 상태 보기
                2. 인벤토리
                3. 상점

                원하시는 행동을 입력해주세요.
                >>
                """);
        }
        public void StatersMessages(Character character)
        {
            character.showStaters();
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
            character.showItems();
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
                
            character.showItems(0);
            Console.Write(
                """
                0. 나가기

                원하시는 행동을 입력해주세요.  
                >>
                """);
        }
        public void ShopMessages(Shop shop)
        {
            Console.WriteLine(
                """      
                [보유 골드]
                800 G

                [아이템 목록]
                """
                );
            shop.showItems();
            Console.Write(
                """
                    
                1. 아이템 구매
                0. 나가기

                원하시는 행동을 입력해주세요.   
                >>
                
                """);
        }
        public void ShopBueWindowMessages(Shop shop)
        {
            Console.WriteLine(
                """      
                [보유 골드]
                800 G

                [아이템 목록]

                """
                );
            shop.showItems(0);
            Console.Write(
                """
                    
                1. 아이템 구매
                0. 나가기

                원하시는 행동을 입력해주세요.   
                >>
                
                """);
        }
        public void ErrorMessages()
        {
            Console.WriteLine(
                """               
                잘못된 입력입니다.
                """);
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
