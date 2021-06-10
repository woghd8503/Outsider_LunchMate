using System;
using System.Collections.Generic;
using System.Text;

namespace LunchMate
{
    class GameManager
    {
        public const int ROCKSCISSORSPAPER = 1;
        public const int DRAWLOT = 2;
        public const int MEMORYGAME = 3;
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            RockScissorsPaper rsp = new RockScissorsPaper();
            DrawLot drawLot = new DrawLot();
            MakeAPair map = new MakeAPair();
            bool isRun = true;
            

            while(isRun)
            {
                PrintMenu();
                int sel = Int32.Parse(Console.ReadLine());
                switch (sel)
                {
                    case ROCKSCISSORSPAPER:
                        rsp.RSPmanager();
                        break;
                    case DRAWLOT:
                        drawLot.Manager();
                        break;
                    case MEMORYGAME:
                        map.MemoryGame();
                        break;
                    default:
                        Console.WriteLine("잘못 입력하셨습니다.");
                        break;
                }
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("-----------");
            Console.WriteLine("----메뉴---");
            Console.WriteLine("-----------");
            Console.WriteLine("1. 가위 바위 보");
            Console.WriteLine("2. 제비뽑기");
            Console.WriteLine("3. 짝맞추기");
            Console.Write("입력:");

        }
    }
}
