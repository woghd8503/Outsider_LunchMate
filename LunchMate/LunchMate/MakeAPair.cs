using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchMate
{
    class Selecet //좌표  const
    {
        public const string LOCATION1 = "1";
        public const string LOCATION2 = "2";
        public const string LOCATION3 = "3";
        public const string LOCATION4 = "4";
        public const string LOCATION5 = "5";
        public const string LOCATION6 = "6";
        public const string LOCATION7 = "7";
        public const string LOCATION8 = "8";
        public const string LOCATION9 = "9";
        public const string LOCATION10 = "10";
        public const string LOCATION11 = "11";
        public const string LOCATION12 = "12";
        public const string LOCATION13 = "13";
        public const string LOCATION14 = "14";
        public const string LOCATION15 = "15";
        public const string LOCATION16 = "16";
    }
    class MakeAPair
    {
        int[,] gameboard = new int[4, 4];
        int[,] defaultBoard = new int[4, 4];
        public List<int> board1 = new List<int>();
        public List<int> board2 = new List<int>();

        public void makeBoard() //1~8의 수를 각 리스트에 넣어준다
        {
            for (int i = 1; i <= 8; i++)
            {
                board1.Add(i);
                board2.Add(i);
            }
        }
        public void shuffleBoard() //각 리스트에 넣어준 수들은 gameboard배열에 랜덤으로 넣어준다
        {
            int k = 0;
            int l = 8;
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int h = rand.Next(2);
                    if (board1.Count == 0)
                    {

                        l = board2.Count;
                        k = rand.Next(l);
                        gameboard[i, j] = board2[k];
                        board2.RemoveAt(k);
                    }
                    else if (board2.Count == 0)
                    {
                        l = board1.Count;
                        k = rand.Next(l);
                        gameboard[i, j] = board1[k];
                        board1.RemoveAt(k);
                    }
                    else if (h == 0)
                    {
                        l = board2.Count;
                        k = rand.Next(l);
                        gameboard[i, j] = board2[k];
                        board2.RemoveAt(k);
                    }
                    else if (h == 1)
                    {
                        l = board1.Count;
                        k = rand.Next(l);
                        gameboard[i, j] = board1[k];
                        board1.RemoveAt(k);
                    }
                }
            }
        }
        public void testBoard() //만들어진 게임판
        {
            Console.Clear();
            Console.WriteLine("기억 하세요");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(gameboard[i, j] + " ");

                }
                Console.WriteLine();
            }
        }
        public void drawDefault() //만들어진 판을 가려줄 판
        {
            Console.Clear();
            Console.WriteLine("기억 나시나요?");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(defaultBoard[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public void game() //게임 시작
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); // 스톱워치 시작
            bool isRun = true;
            int cnt1 = 0;
            while (isRun)
            {
                testBoard();
                System.Threading.Thread.Sleep(2000); //2초간 게임판을 보여주고 가린다.
                drawDefault();                      //가려줄 판을 그려준다.
                int[] num1 = new int[2], num2 = new int[2];
                Console.Write("1) 1~16 입력(0은 종료)>>");//1~16입력 스위치문 가려줄 판이 0일때만 가려줄 판의 수를 게임판의 수로 바꿔준다
                string sel1 = Console.ReadLine();
                switch (sel1)
                {
                    case Selecet.LOCATION1:
                        num1[0] = 0; num1[1] = 0;
                        if (defaultBoard[num1[0], num1[1]] == 0)
                        {
                            defaultBoard[num1[0], num1[1]] = gameboard[num1[0], num1[1]];
                        }
                        break;
                    case Selecet.LOCATION2:
                        num1[0] = 0; num1[1] = 1;
                        if (defaultBoard[num1[0], num1[1]] == 0)
                        {
                            defaultBoard[num1[0], num1[1]] = gameboard[num1[0], num1[1]];
                        }
                        break;
                    case Selecet.LOCATION3:
                        num1[0] = 0; num1[1] = 2;
                        if (defaultBoard[num1[0], num1[1]] == 0)
                        {
                            defaultBoard[num1[0], num1[1]] = gameboard[num1[0], num1[1]];
                        }
                        break;
                    case Selecet.LOCATION4:
                        num1[0] = 0; num1[1] = 3;
                        if (defaultBoard[num1[0], num1[1]] == 0)
                        {
                            defaultBoard[num1[0], num1[1]] = gameboard[num1[0], num1[1]];
                        }
                        break;
                    case Selecet.LOCATION5:
                        num1[0] = 1; num1[1] = 0;
                        if (defaultBoard[num1[0], num1[1]] == 0)
                        {
                            defaultBoard[num1[0], num1[1]] = gameboard[num1[0], num1[1]];
                        }
                        break;
                    case Selecet.LOCATION6:
                        num1[0] = 1; num1[1] = 1;
                        if (defaultBoard[num1[0], num1[1]] == 0)
                        {
                            defaultBoard[num1[0], num1[1]] = gameboard[num1[0], num1[1]];
                        }
                        break;
                    case Selecet.LOCATION7:
                        num1[0] = 1; num1[1] = 2;
                        if (defaultBoard[num1[0], num1[1]] == 0)
                        {
                            defaultBoard[num1[0], num1[1]] = gameboard[num1[0], num1[1]];
                        }
                        break;
                    case Selecet.LOCATION8:
                        num1[0] = 1; num1[1] = 3;
                        if (defaultBoard[num1[0], num1[1]] == 0)
                        {
                            defaultBoard[num1[0], num1[1]] = gameboard[num1[0], num1[1]];
                        }
                        break;
                    case Selecet.LOCATION9:
                        num1[0] = 2; num1[1] = 0;
                        if (defaultBoard[num1[0], num1[1]] == 0)
                        {
                            defaultBoard[num1[0], num1[1]] = gameboard[num1[0], num1[1]];
                        }
                        break;
                    case Selecet.LOCATION10:
                        num1[0] = 2; num1[1] = 1;
                        if (defaultBoard[num1[0], num1[1]] == 0)
                        {
                            defaultBoard[num1[0], num1[1]] = gameboard[num1[0], num1[1]];
                        }
                        break;
                    case Selecet.LOCATION11:
                        num1[0] = 2; num1[1] = 2;
                        if (defaultBoard[num1[0], num1[1]] == 0)
                        {
                            defaultBoard[num1[0], num1[1]] = gameboard[num1[0], num1[1]];
                        }
                        break;
                    case Selecet.LOCATION12:
                        num1[0] = 2; num1[1] = 3;
                        if (defaultBoard[num1[0], num1[1]] == 0)
                        {
                            defaultBoard[num1[0], num1[1]] = gameboard[num1[0], num1[1]];
                        }
                        break;
                    case Selecet.LOCATION13:
                        num1[0] = 3; num1[1] = 0;
                        if (defaultBoard[num1[0], num1[1]] == 0)
                        {
                            defaultBoard[num1[0], num1[1]] = gameboard[num1[0], num1[1]];
                        }
                        break;
                    case Selecet.LOCATION14:
                        num1[0] = 3; num1[1] = 1;
                        if (defaultBoard[num1[0], num1[1]] == 0)
                        {
                            defaultBoard[num1[0], num1[1]] = gameboard[num1[0], num1[1]];
                        }
                        break;
                    case Selecet.LOCATION15:
                        num1[0] = 3; num1[1] = 2;
                        if (defaultBoard[num1[0], num1[1]] == 0)
                        {
                            defaultBoard[num1[0], num1[1]] = gameboard[num1[0], num1[1]];
                        }
                        break;
                    case Selecet.LOCATION16:
                        num1[0] = 3; num1[1] = 3;
                        if (defaultBoard[num1[0], num1[1]] == 0)
                        {
                            defaultBoard[num1[0], num1[1]] = gameboard[num1[0], num1[1]];
                        }
                        break;
                }
                drawDefault();
                Console.Write("2) 1~16 입력(0은 종료)>>");
                string sel2 = Console.ReadLine();
                switch (sel2)
                {
                    case Selecet.LOCATION1:
                        num2[0] = 0; num2[1] = 0;
                        if (defaultBoard[num2[0], num2[1]] == 0)
                        {
                            defaultBoard[num2[0], num2[1]] = gameboard[num2[0], num2[1]];
                        }
                        break;
                    case Selecet.LOCATION2:
                        num2[0] = 0; num2[1] = 1;
                        if (defaultBoard[num2[0], num2[1]] == 0)
                        {
                            defaultBoard[num2[0], num2[1]] = gameboard[num2[0], num2[1]];
                        }
                        break;
                    case Selecet.LOCATION3:
                        num2[0] = 0; num2[1] = 2;
                        if (defaultBoard[num2[0], num2[1]] == 0)
                        {
                            defaultBoard[num2[0], num2[1]] = gameboard[num2[0], num2[1]];
                        }
                        break;
                    case Selecet.LOCATION4:
                        num2[0] = 0; num2[1] = 3;
                        if (defaultBoard[num2[0], num2[1]] == 0)
                        {
                            defaultBoard[num2[0], num2[1]] = gameboard[num2[0], num2[1]];
                        }
                        break;
                    case Selecet.LOCATION5:
                        num2[0] = 1; num2[1] = 0;
                        if (defaultBoard[num2[0], num2[1]] == 0)
                        {
                            defaultBoard[num2[0], num2[1]] = gameboard[num2[0], num2[1]];
                        }
                        break;
                    case Selecet.LOCATION6:
                        num2[0] = 1; num2[1] = 1;
                        if (defaultBoard[num2[0], num2[1]] == 0)
                        {
                            defaultBoard[num2[0], num2[1]] = gameboard[num2[0], num2[1]];
                        }
                        break;
                    case Selecet.LOCATION7:
                        num2[0] = 1; num2[1] = 2;
                        if (defaultBoard[num2[0], num2[1]] == 0)
                        {
                            defaultBoard[num2[0], num2[1]] = gameboard[num2[0], num2[1]];
                        }
                        break;
                    case Selecet.LOCATION8:
                        num2[0] = 1; num2[1] = 3;
                        if (defaultBoard[num2[0], num2[1]] == 0)
                        {
                            defaultBoard[num2[0], num2[1]] = gameboard[num2[0], num2[1]];
                        }
                        break;
                    case Selecet.LOCATION9:
                        num2[0] = 2; num2[1] = 0;
                        if (defaultBoard[num2[0], num2[1]] == 0)
                        {
                            defaultBoard[num2[0], num2[1]] = gameboard[num2[0], num2[1]];
                        }
                        break;
                    case Selecet.LOCATION10:
                        num2[0] = 2; num2[1] = 1;
                        if (defaultBoard[num2[0], num2[1]] == 0)
                        {
                            defaultBoard[num2[0], num2[1]] = gameboard[num2[0], num2[1]];
                        }
                        break;
                    case Selecet.LOCATION11:
                        num2[0] = 2; num2[1] = 2;
                        defaultBoard[num2[0], num2[1]] = gameboard[num2[0], num2[1]];
                        break;
                    case Selecet.LOCATION12:
                        num2[0] = 2; num2[1] = 3;
                        if (defaultBoard[num2[0], num2[1]] == 0)
                        {
                            defaultBoard[num2[0], num2[1]] = gameboard[num2[0], num2[1]];
                        }
                        break;
                    case Selecet.LOCATION13:
                        num2[0] = 3; num2[1] = 0;
                        if (defaultBoard[num2[0], num2[1]] == 0)
                        {
                            defaultBoard[num2[0], num2[1]] = gameboard[num2[0], num2[1]];
                        }
                        break;
                    case Selecet.LOCATION14:
                        num2[0] = 3; num2[1] = 1;
                        if (defaultBoard[num2[0], num2[1]] == 0)
                        {
                            defaultBoard[num2[0], num2[1]] = gameboard[num2[0], num2[1]];
                        }
                        break;
                    case Selecet.LOCATION15:
                        num2[0] = 3; num2[1] = 2;
                        if (defaultBoard[num2[0], num2[1]] == 0)
                        {
                            defaultBoard[num2[0], num2[1]] = gameboard[num2[0], num2[1]];
                        }
                        break;
                    case Selecet.LOCATION16:
                        num2[0] = 3; num2[1] = 3;
                        if (defaultBoard[num2[0], num2[1]] == 0)
                        {
                            defaultBoard[num2[0], num2[1]] = gameboard[num2[0], num2[1]];
                        }
                        break;
                }
                drawDefault();

                if (sel1 == "0" || sel2 == "0")  //0입력시 종료
                {
                    isRun = false;
                }
                if (gameboard[num1[0], num1[1]] == gameboard[num2[0], num2[1]]) //입력한 2개의 수가 같으면 0으로 바궈준다.
                {
                    double stSec = stopwatch.Elapsed.TotalMilliseconds / 1000;
                    gameboard[num1[0], num1[1]] = 0;
                    gameboard[num2[0], num2[1]] = 0;
                    cnt1++; //종료를 위한 카운트
                    if (cnt1 == 8)   //8턴이 다 지나면
                    {
                        testBoard();    // 0이된 게임판을 그려주고
                        stopwatch.Stop(); //스탑워치를 멈춰주고
                        Console.WriteLine("{0:0.##}", stSec);   //스탑워치를 소수점2자리까지 출력
                        stopwatch.Restart(); //스탑워치를 리셋해준다.
                        isRun = false;
                    }
                }
                else //입력한 2개의 수가 다르다면 바꿔준 가려준 판의 수를 0으로 바꿔준다.
                {
                    defaultBoard[num1[0], num1[1]] = 0;
                    defaultBoard[num2[0], num2[1]] = 0;
                }
            }
        }
        public void MemoryGame()
        {
            makeBoard();
            shuffleBoard();
            game();
        }
    }
}
