using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Calculate_factorials
{
    class FactorialCalculator
    {
        static void Main(string[] args)
        {
            int n = 100;
        }

        public int GetFactorial(int x)
        {
            int factorial = 1;
            int i = 1;
            while (i <= x)
            {
                factorial = factorial * i;
                i++;
            }
            return factorial;
        }
    }
}
