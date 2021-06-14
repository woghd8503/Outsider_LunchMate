using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class GuguDan
    {

        static void Main(string[] args)
        {
            Console.WriteLine("===============================================");
            Console.WriteLine("\t[박성원 두번째 코딩은 구구단 만들기]");
            Console.WriteLine("===============================================\n");
            // 반복문

            for (int i = 2; i <= 9; i++)
            {
                Console.WriteLine($"{i-1}번째");
                for (int j = 1; j <= 9; j++)
                {
                    Console.WriteLine($"{i} X {j} = {i * j}");
                }
                Console.WriteLine();
            }
        }
    }
}
