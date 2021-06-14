using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] test = new string[3];
            test[0] = "ddd";
            for(int i = 0; i < test.Length; i++)
            {
                if (test[i] == null)
                    test[i] = "hhhh";
                Console.WriteLine( test[i] ); 
            }
        }
    }
}
