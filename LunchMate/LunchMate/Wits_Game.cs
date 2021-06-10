using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchMate
{
    class Wits_Game : Game
    {
        public void gameExit()
        {
            throw new NotImplementedException();
        }

        public void gameStartView()
        {
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
            int sel = Int32.Parse(Console.ReadLine());

            if (sel == 1)
            {
                Console.Clear();
                gameStart();
            }
            else if(sel == 2)
            {
                Console.Clear();
                gameExplan();
            }
            else if(sel == 3)
            {

            }
            else
            {
                Console.WriteLine("잘못입력하셧습니다.");
                Console.Clear();
                gameStartView();
            }
        }
        public void gameExplan()
        {
            Console.WriteLine("눈치게임 설명!");
            Console.WriteLine("3 2 1 이라는 숫자가 뜨고 숫자를 입력하라고 한다. 그러면 순서대로 1 2 3 4를 쓰면 된다. 하지만 마지막 4를 쓴 사람은 탈락을 하게 된다.");
            Console.WriteLine("그렇다고 1만 고집하다가는 같은 숫자를 쓰면 두 사람이 같이 탈락을 하게 된다. 그리고 순서를 안맞혀도 틀리게된다.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("예시");
            Console.ReadLine();
            Console.Clear();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int x, y;
            // 3
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
            // 2
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
            // 1
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
            Console.WriteLine("성공적일때");
            int a, b, c, d;
            Random rand = new Random();

            Console.WriteLine("숫자 입력!");
            for (; ; )
            {
                for (; ; )
                {
                    a = 1;
                    if (a < 1 || a > 4)
                    {
                        Console.WriteLine("다시 입력하세요.");
                        continue;
                    }
                    Console.WriteLine(a);
                    break;
                }
                if (a != 1)
                {
                    Console.WriteLine("탈락입니다.");
                    break;
                }
                for (; ; )
                {
                    b = 2;
                    if (b < 1 || b > 4)
                    {
                        Console.WriteLine("다시 입력하세요.");
                        continue;
                    }
                    Console.WriteLine(b);
                    break;
                }
                if (b <= a)
                {
                    Console.WriteLine("탈락입니다.");
                    break;
                }
                for (; ; )
                {
                    c = 3;
                    if (c < 1 || c > 4)
                    {
                        Console.WriteLine("다시 입력하세요.");
                        continue;
                    }
                    Console.WriteLine(c);
                    break;
                }
                if (c <= b)
                {
                    Console.WriteLine("탈락입니다.");
                    break;
                }
                for (; ; )
                {
                    d = 4;
                    if (d < 1 || d > 4)
                    {
                        Console.WriteLine("다시 입력하세요.");
                        continue;
                    }
                    Console.WriteLine(d);
                    break;
                }
                if (d <= c)
                {
                    Console.WriteLine("탈락입니다.");
                    break;
                }
                Console.WriteLine("4번째 탈락");
                break;
            }
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("실패했을때");

            for (; ; )
            {
                for (; ; )
                {
                    a = rand.Next(4) + 1;
                    if (a < 1 || a > 4)
                    {
                        Console.WriteLine("다시 입력하세요.");
                        continue;
                    }
                    Console.WriteLine(a);
                    break;
                }
                if (a != 1)
                {
                    Console.WriteLine("탈락입니다.");
                    break;
                }
                for (; ; )
                {
                    b = rand.Next(4) + 1;
                    if (b < 1 || b > 4)
                    {
                        Console.WriteLine("다시 입력하세요.");
                        continue;
                    }
                    Console.WriteLine(b);
                    break;
                }
                if (b <= a)
                {
                    Console.WriteLine("탈락입니다.");
                    break;
                }
                for (; ; )
                {
                    c = rand.Next(4) + 1;
                    if (c < 1 || c > 4)
                    {
                        Console.WriteLine("다시 입력하세요.");
                        continue;
                    }
                    Console.WriteLine(c);
                    break;
                }
                if (c <= b)
                {
                    Console.WriteLine("탈락입니다.");
                    break;
                }
                for (; ; )
                {
                    d = rand.Next(4) + 1;
                    if (d < 1 || d > 4)
                    {
                        Console.WriteLine("다시 입력하세요.");
                        continue;
                    }
                    Console.WriteLine(d);
                    break;
                }
                if (d <= c)
                {
                    Console.WriteLine("탈락입니다.");
                    break;
                }
                Console.WriteLine("4번째 탈락");
                break;
            }
        }
        public void gameStart()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int x,y;
                // 3
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
                for(; ; )
                {
                    if (sw.ElapsedMilliseconds / 1000 == 1)
                        break;
                }
            }
            // 2
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
                for(; ; )
                {
                    if (sw.ElapsedMilliseconds / 1000 == 2)
                        break;
                }
            }

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
                for(; ; )
                {
                    if (sw.ElapsedMilliseconds / 1000 == 3)
                    { break; }
                }
                
                Console.Clear();
            }
            gamePlay();

        }

        public void gamePlay()
        {
            int fir, sec, thr, fou;
            Console.WriteLine("숫자 입력!");
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
    }
}
