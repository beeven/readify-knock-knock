using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnockKnock.Services 
{
    /// <summary>
    /// Pre calculate Fibonacci sequence to speed up.
    /// </summary>
    public class FibonacciService:IFibonacciService
    {

        private Int64 FibonacciNumber(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if(n==1)
            {
                return 1;
            }
            else
            {
                Int64 a = 0, b = 1, c=1;
                for(int i=2;i<=n;i++)
                {
                    c = a + b;
                    a = b;
                    b = c;
                }
                return c;
            }
        }

        public Int64 GetFibonacciNumberAt(int n)
        {
            if(n > 92 || n < -92)
            {
                throw new ArgumentOutOfRangeException(nameof(n),n,"Input number should be between -92 and 92");
            }
            if(n<0)
            {
                return n%2 == 0 ? -FibonacciNumber(-n) : FibonacciNumber(-n);
            }
            return FibonacciNumber(n);
        }

    }
}