using System;

namespace LunchMate
{
    class RockScissorsPaper
    {
        public string type1 { get; set; }
        public string type2 { get; set; }
        public string type3 { get; set; }
        public int player { get; set; }

        string InputRSP(int[] player, int playerNum)
        {
            bool isRun = true;
            string input = "";
            while (isRun)
            {
                Console.Write("\t=====================================");
                Console.WriteLine($"\n\t  1p:{type1}   2p:{type2}   3p:{type3} ");
                Console.WriteLine("\t=====================================");

                Console.WriteLine("\t   1 = 가위 || 2 = 바위 || 3 = 보");
                Console.Write($"\n\t[{playerNum + 1}p 입력]\n");
                Console.Write("\n\t입력: ");

                int inputNum = int.Parse(Console.ReadLine());
                if (inputNum >= 4 || inputNum < 1)
                {
                    ClearScreen();
                    Console.WriteLine("잘못입력하셨습니다.");
                    System.Threading.Thread.Sleep(1000);
                    ClearScreen();
                    continue;
                }

                player[playerNum] = inputNum;
                player[playerNum] = player[playerNum] - 1;

                if (player[playerNum] == 0)
                    input = "가위";
                else if (player[playerNum] == 1)
                    input = "바위";
                else if (player[playerNum] == 2)
                    input = "보";
                ClearScreen();
                isRun = false;
            }
            return input;
        }

        void JudgeRSP(int player, int player1, int player2)
        {
            if ((player == player1 && player == player2) || (player != player1 && player != player2 && player1 != player2))
            {
                Console.WriteLine("\t\n\n 승부를 가릴 수없음... 비김");
                return;
            }
            else
            {
                if (((player + 1) % 3 == player2) && (player == player1)) // 패패승
                {
                    Console.WriteLine("\n승자: [3p] 패자: [1p와 2p] 밥값내세요!!\n\n");
                }
                if (((player + 1) % 3 == player1) && (player == player2)) // 패승패
                {
                    Console.WriteLine("\n승자: [2p] 패자: [1p와 3p] 밥값내세요!!\n\n");
                }
                if (((player1 + 1) % 3 == player) && (player == player2)) //승패승
                {
                    Console.WriteLine("\n승자: [1p와 3p] 패자: [2p] 밥값내세요!!\n\n");
                }
                if (((player + 1) % 3 == player1) && (player1 == player2)) // 안됨 233, 패승승
                {
                    Console.WriteLine("\n승자: [2p와 3p] 패자: [1p] 밥값내세요!!\n\n");
                }
                if (((player1 + 1) % 3 == player) && (player2 == player1)) // 안됨 311 ,승패패
                {
                    Console.WriteLine("\n승자: [1p] 패자: [2p와 3p] 밥값내세요!!\n\n");
                }
                if (((player2 + 1) % 3 == player) && (player == player1)) // 승승패
                {
                    Console.WriteLine("\n승자: [1p와 2p] 패자: [3p] 밥값내세요!!\n\n");
                }
                /*else if (player > player2 && player1 > player2)
                    Console.WriteLine("\n승자: [1p와 2p] 패자: [3p] 밥값내세요!!\n\n");
                else if (player > player1 && player2 > player1)
                    Console.WriteLine("\n승자: [1p와 3p] 패자: [2p] 밥값내세요!!\n\n");
                else if (player1 > player && player2 > player)
                    Console.WriteLine("\n승자: [2p와 3p] 패자: [1p] 밥값내세요!!\n\n");*/
            }
        }

        public void RSPmanager()
        {
            bool isRun = true;
            int[] player = new int[3];
            int _player = 0;
            int _player1 = 0;
            int _player2 = 0;

            while (isRun)
            {
                ClearScreen();
                type1 = "대기중";
                type2 = "대기중";
                type3 = "대기중";

                for (int i = 0; i < player.Length; i++)
                {
                    if (i == 0)
                    {
                        type1 = InputRSP(player, i);
                        _player = player[i];
                    }
                    if (i == 1)
                    {
                        type2 = InputRSP(player, i);
                        _player1 = player[i];
                    }
                    if (i == 2)
                    {
                        type3 = InputRSP(player, i);
                        _player2 = player[i];
                    }
                }
                Console.WriteLine($"\t1p:{type1} 2p:{type2} 3p:{type3} \n");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("과연 결과는.");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("과연 결과는..");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("과연 결과는...");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("과연 결과는...?");

                System.Threading.Thread.Sleep(2000);
                JudgeRSP(_player, _player1, _player2);
                Console.ReadKey();
            }
        }
        void ClearScreen()
        {
            Console.Clear();
            Console.ReadLine();
        }
    }
}
