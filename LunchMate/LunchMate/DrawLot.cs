using System;
using System.Collections.Generic;
using System.Text;

namespace LunchMate
{
    class DrawLot
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
                Play();
            else if (decision == "n" || decision == "N")
                return;
        }
        public void Play()
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
        public void Manager()
        {
            while (true)
            {
                Console.ReadLine();
                Console.Clear();
                Intro();
            }
        }
    }
}
