using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnockKnock.Services 
{
    public class FibonacciService
    {
        private Int64[] fibonacciNumbers = new Int64[93];
        public FibonacciService()
        {
            fibonacciNumbers[0] = 0;
            fibonacciNumbers[1] = 1;
            for(int i=2;i<93;i++)
            {
                fibonacciNumbers[i] = fibonacciNumbers[i-1] + fibonacciNumbers[i-2];
            }
        }

        public Int64 GetFibonacciAt(int n)
        {
            if(n > 92 || n < -92)
            {
                throw new ArgumentOutOfRangeException(nameof(n),n,"Number should be confined within -92,92");
            }
            if(n<0)
            {
                return n%2 == 0 ? -fibonacciNumbers[-n] : fibonacciNumbers[-n];
            }
            return fibonacciNumbers[n];
        }

    }
}