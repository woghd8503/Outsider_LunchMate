using System;

namespace LunchMate
{
    class _1_RockScissorsPaper : IGameBox
    {
        public int player { get; set; }     // 사용자 변수
        public int input { get; set; }   // 사용자 입력
        public string type1 { get; set; }   // 가위, 바위, 보  1p
        public string type2 { get; set; }   // 가위, 바위, 보  2p
        public string type3 { get; set; }   // 가위, 바위, 보  3p
        public string myId { get; set; }

        public void ShowMenu()
        {
            bool isRun = true;
           
            while (isRun)
            {
                Console.Clear();
                Console.WriteLine("1. 게임시작");
                Console.WriteLine("2. 게임설명");
                Console.WriteLine("3. 돌아가기");
                int sel = Int32.Parse(Console.ReadLine());

                if (sel == 1)
                {
                    Console.Clear();
                    PlayGame();
                    isRun = false;
                }
                else if (sel == 2)
                {
                    Console.Clear();
                    ExplainGame();
                }
                else if (sel == 3)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("잘못입력하셨습니다.");
                    Console.Clear();
                }
            }
        }
        public void PlayGame()
        {
            InputGame();
        }
        public void ExplainGame()
        {
            Console.WriteLine("====================================");
            Console.WriteLine("1. 입력방법 (1) 가위 (2) 바위 (3) 보 ");
            Console.WriteLine("2. 상대방과 비교 후 결과값 확인가능 ");
            Console.ReadKey();
        }
        public void InputGame()
        {
            bool isRun = true;
            int max = 4;
            int min = 1;

            while (isRun)
            {
                Console.WriteLine("\t=====================================");
                Console.WriteLine("\t   1 = 가위 || 2 = 바위 || 3 = 보");
                Console.WriteLine("\t=====================================");
                
                Console.Write($"\n\t{myId}입력: ");
                input = int.Parse(Console.ReadLine());
                if (input >= max || input < min)
                {
                    ClearScreen();
                    Console.WriteLine("잘못입력하셨습니다.");
                    System.Threading.Thread.Sleep(1000);
                    ClearScreen();
                    continue;
                }
                break;
            }
        }
        public object SendPacket()
        {
            string sInput = input == 1 ? "가위" : input == 2 ? "바위" : "보";
            // 사용자의 입력값을 서버로 보냄
            Console.WriteLine($"\n\t사용자가 입력한 값은: {sInput}\n");
            Console.ReadKey();
            return input;
        }
       
        public void RecieveResult()
        {
            int test = 0;
            // 서버에서 다른 사용자들의 값을 받아서 벌칙자를 선별 결과를 받음.
            ClearScreen();
            Console.WriteLine("\t=====================================");
            Console.WriteLine($"\t1 = {type1} || 2 = {type1} || 3 = {type1}");
            Console.WriteLine("\t=====================================");

            if (test == 0)
                Console.WriteLine($"\t 당신은 밥값을 내야됩니다.");
                else Console.WriteLine($"\t 당신은 밥을 얻어먹습니다..");
            Console.WriteLine("최정결과는 : ------------------");
            Console.ReadKey();
        }
        public void ClearScreen()
        {
            Console.Clear();
            Console.ReadLine();
        }
    }
}
