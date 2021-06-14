using System;
using System.Collections.Generic;
using System.Text;

namespace LunchMate
{
    class _2_DrawLot : IGameBox
    {
        public int participantNum { get; set; }
        int loserNum { get; set; }

        public void Intro()
        {
            while (true)
            {
                Console.Write("참가 인원을 입력:");
                participantNum = Int32.Parse(Console.ReadLine());
                Console.Write("꽝의 개수를 입력:");
                loserNum = Int32.Parse(Console.ReadLine());
                if (loserNum > participantNum)
                {
                    Console.WriteLine("꽝의 개수가 참가인원을 초과할 수 없습니다.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                else break;
            }
            Console.WriteLine("제비뽑기를 시작 하시겠습니까? Y/N");
            string decision = Console.ReadLine();

            if (decision == "y" || decision == "Y")
                PlayGame();
            else if (decision == "n" || decision == "N")
                return;
        }

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
                    Console.WriteLine("잘못입력하셧습니다.");
                    Console.Clear();
                }
            }
        }
        public void PlayGame()
        {
            InputGame();
            SendPacket();
        }
        public void ExplainGame()
        {
            Console.WriteLine("====================================");
            Console.WriteLine("1. 접속 시 자동으로 번호를 지정 ");
            Console.WriteLine("2. 방장이 벌칙자의 수를 입력 ");
            Console.WriteLine("3. 지정된 번호를 기반으로 제비뽑기 결과를 받음");
            Console.ReadKey();
        }
        public void InputGame()
        {
            int captain = 0;
            if(captain == 0)
            Console.WriteLine("1. 벌칙자의 수를 입력");
            this.loserNum= Int32.Parse(Console.ReadLine());
        }
        public object SendPacket()
        {
            // 사용자의 입력값을 서버로 보냄
            Console.WriteLine($"사용자가 입력한 값은: {this.loserNum}");
            Console.ReadKey();
            return loserNum;
        }
        public void JudgeGame()
        {
            bool isSame;
            Random r = new Random();
            int[] loser = new int[loserNum];

            for (int i = 0; i < loser.Length; i++)
            {
                while (true)
                {
                    loser[i] = r.Next(0, participantNum);
                    isSame = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (loser[i] == loser[j])
                        {
                            isSame = true;
                            break;
                        }
                    }
                    if (!isSame) break;
                }
            }
            Array.Sort(loser);
            Console.Write($"참가자중 밥값을 낼 사람은");
            for (int i = 0; i < loser.Length; i++)
            {
                if (i == loser.Length - 1)
                    Console.Write($" {loser[i] + 1}번 ");
                else
                    Console.Write($" {loser[i] + 1}번,");
            }
            Console.Write("입니다.");
        }

        public void ClearScreen()
        {
            Console.Clear();
            Console.ReadLine();
        }
    }
}
