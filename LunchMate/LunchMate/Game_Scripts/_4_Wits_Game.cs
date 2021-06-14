using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchMate
{
    class _4_Wits_Game : IGameBox
    {
        public int input { get; set; }
        public void ShowMenu()
        {
            int _input = this.input; 
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                ClearScreen();
                Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
                Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
                Console.WriteLine("■■■■■  ■■■■■■■■■■■■■■  ■■■■■■■■■■■■■■■■■■■■■■■■  ■■");
                Console.WriteLine("■■■■■  ■■■■■■■■■■■■■■  ■■■■■■■■■■■■  ■  ■■■■    ■■■  ■■");
                Console.WriteLine("■■■■■      ■■■■■■    ■■■■  ■■■■■■■■■■■■  ■  ■■■  ■■  ■■  ■■");
                Console.WriteLine("■■■■■■■■■■■■■■■■■■■■  ■■■          ■■■■  ■  ■■■  ■■  ■■  ■■");
                Console.WriteLine("■■■              ■■            ■■  ■■■■■■■  ■■■■  ■  ■■■■    ■■■  ■■");
                Console.WriteLine("■■■■■■  ■■■■■■■ ■ ■■■■  ■■■■■■■  ■■      ■  ■■■■■■■■■  ■■");
                Console.WriteLine("■■■■  ■  ■■■■■■  ■■  ■■■  ■■■■■■■  ■■■■  ■  ■■■■■■■■■■■■");
                Console.WriteLine("■■■■  ■  ■■■■■  ■■■■  ■■  ■■■■■■■  ■■■■  ■  ■■■              ■■");
                Console.WriteLine("■■■■  ■■■■■■■■■■■■■■■  ■■■■■■■■■■■■  ■  ■■■  ■■■■■  ■■");
                Console.WriteLine("■■■■          ■■■■■■■■■■■  ■■■■■■■■■■■■  ■  ■■■  ■■■■■  ■■");
                Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■              ■■");
                Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
                Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
                Console.WriteLine("■■■■■■■■■■■■■■■■■■■■ 1.게임시작 ■■■■■■■■■■■■■■■■■■■■■■");
                Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
                Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
                Console.WriteLine("■■■■■■■■■■■■■■■■■■■■ 2.게임설명 ■■■■■■■■■■■■■■■■■■■■■■");
                Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
                Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
                Console.WriteLine("■■■■■■■■■■■■■■■■■■■■ 3.돌아가기 ■■■■■■■■■■■■■■■■■■■■■■");
                Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("입력:");
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
                    ClearScreen();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("잘못입력하셧습니다.");
                    ShowMenu();
                }
            }
        }
        public void ExplainGame()
        {
            Console.WriteLine("눈치게임 설명!");
            Console.WriteLine("3 2 1 이라는 숫자가 뜨고 숫자를 입력하라고 한다. 그러면 순서대로 1 2 3 4를 쓰면 된다. 하지만 마지막 4를 쓴 사람은 탈락을 하게 된다.");
            Console.WriteLine("그렇다고 1만 고집하다가는 같은 숫자를 쓰면 두 사람이 같이 탈락을 하게 된다. 그리고 순서를 안맞혀도 틀리게된다.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("예시");
            Console.ReadLine();
            Console.Clear();
        }
        public void InputGame()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int x, y;
            // 3 초
            Console.Beep();
            if (sw.ElapsedMilliseconds / 1000 == 0)
            {
                x = 43;
                y = 3;
                for (int i = 0; i < 25; i++)
                {
                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    Console.Write("*");
                    x++;
                }
                for (int i = 0; i < 9; i++)
                {
                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    Console.Write("*");
                    y++;
                }
                x = 43;
                for (int i = 0; i < 25; i++)
                {
                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    Console.Write("*");
                    x++;
                }
                for (int i = 0; i < 9; i++)
                {
                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    Console.Write("*");
                    y++;
                }
                x = 43;
                for (int i = 0; i < 26; i++)
                {
                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    Console.Write("*");
                    x++;
                }
                for (; ; )
                {
                    if (sw.ElapsedMilliseconds / 1000 == 1)
                        break;
                }
            }
            Console.Beep();
            // 2 초
            if (sw.ElapsedMilliseconds / 1000 == 1)
            {
                Console.Clear();
                x = 43;
                y = 3;
                for (int i = 0; i < 25; i++)
                {
                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    Console.Write("*");
                    x++;
                }
                for (int i = 0; i < 9; i++)
                {
                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    Console.Write("*");
                    y++;
                }
                for (int i = 0; i < 25; i++)
                {
                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    Console.Write("*");
                    x--;
                }
                for (int i = 0; i < 9; i++)
                {
                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    Console.Write("*");
                    y++;
                }
                for (int i = 0; i < 26; i++)
                {
                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    Console.Write("*");
                    x++;
                }
                for (; ; )
                {
                    if (sw.ElapsedMilliseconds / 1000 == 2)
                        break;
                }
            }
            Console.Beep();

            //  1 초
            if (sw.ElapsedMilliseconds / 1000 == 2)
            {
                Console.Clear();
                x = 57;
                y = 3;
                for (int i = 0; i < 19; i++)
                {
                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    Console.Write("*");
                    y++;
                }
                y = 5;
                for (int i = 0; i < 7; i++)
                {
                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    Console.Write("*");
                    x--;
                }
                x = 43;
                y = 22;
                for (int i = 0; i < 29; i++)
                {
                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    Console.Write("*");
                    x++;
                }
                for (; ; )
                {
                    if (sw.ElapsedMilliseconds / 1000 == 3)
                    { break; }
                }
                Console.Clear();
            }
            Console.Beep();
            Console.WriteLine("숫자 입력!");

        }

        public object SendPacket()
        {
            Console.WriteLine($"입력한 값은: {input}");
            return input;
        }

        public void JudgeGame()
        {
            int fir, sec, thr, fou;
            for (; ; )
            {
                for (; ; )
                {
                    fir = Int32.Parse(Console.ReadLine());
                    if (fir < 1 || fir > 4)
                    {
                        Console.WriteLine("다시 입력하세요.");
                        continue;
                    }
                    break;
                }
                if (fir != 1)
                {
                    Console.WriteLine("탈락입니다.");
                    break;
                }
                for (; ; )
                {
                    sec = Int32.Parse(Console.ReadLine());
                    if (sec < 1 || sec > 4)
                    {
                        Console.WriteLine("다시 입력하세요.");
                        continue;
                    }
                    break;
                }
                if (fir == sec || sec < fir)
                {
                    Console.WriteLine("탈락입니다.");
                    break;
                }
                for (; ; )
                {
                    thr = Int32.Parse(Console.ReadLine());
                    if (thr < 1 || thr > 4)
                    {
                        Console.WriteLine("다시 입력하세요.");
                        continue;
                    }
                    break;
                }
                if (fir == sec || sec < fir)
                {
                    Console.WriteLine("탈락입니다.");
                    break;
                }
                for (; ; )
                {
                    fou = Int32.Parse(Console.ReadLine());
                    if (fou < 1 || fou > 4)
                    {
                        Console.WriteLine("다시 입력하세요.");
                        continue;
                    }
                    break;
                }
                if (fir == sec || sec < fir)
                {
                    Console.WriteLine("탈락입니다.");
                    break;
                }
                Console.WriteLine("4번째 탈락");
                break;
            }
        }

        public void RecieveResult()
        {
            throw new NotImplementedException();
        }
        public void ClearScreen()
        {
            Console.ReadLine();
            Console.Clear();
        }

        public void PlayGame()
        {
            int max = 4;
            int min = 1;

            InputGame();
            while (true)
            {
                while (true)
                {
                    input = Int32.Parse(Console.ReadLine());
                    if (input < min || input > max)
                    {
                        Console.WriteLine("다시 입력하세요.");
                        continue;
                    }
                    break;
                }
                if (input != 1)
                {
                    Console.WriteLine("탈락입니다.");
                    break;
                }
            }
            SendPacket();
        }
    }
}
