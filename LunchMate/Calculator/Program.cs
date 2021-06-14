using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 100000;
            int input1 = 100000;
            int result = 0;
            string cal = "";

            Console.WriteLine("=======================");
            Console.WriteLine("[박성원 첫 코딩하는 날]");
            Console.WriteLine("=======================\n");


            Console.Write("첫 숫자를 입력:");
            input = Int32.Parse(Console.ReadLine());

            Console.Write("두번째 숫자를 입력:");
            input1 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("연산 기호를 입력(+, -, /, x):");
            cal = Console.ReadLine();


            switch (cal)
            {
                case "+":
                    result = input + input1;
                    Console.WriteLine("더하기 결과는:" + result);
                    break;
                case "-":
                    result = input - input1;
                    Console.WriteLine("뺀 결과는:" + result);
                    break;
                case "/":
                    result = input / input1;
                    Console.WriteLine("나누기 결과는:" + result);
                    break;
                case "x":
                    result = input * input1;
                    Console.WriteLine("곱하기 결과는:" + result);
                    break;
                    
            }

        }
    }
}
