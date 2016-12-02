using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnockKnock.Services
{
    public class FibonacciMatrix : IFibonacciService
    {
        Int64[] F = new Int64[4] { 1, 1, 1, 0 };

        private Int64[] matrix_multiply(Int64[] A, Int64[] B)
        {
            return new Int64[4]
            {
                A[0]*B[0]+A[1]*B[2],
                A[0]*B[1]+A[1]*B[3],
                A[2]*B[0]+A[3]*B[2],
                A[2]*B[1]+A[3]*B[3]
            };
        }

        private Int64[] matrix_power(Int64[] A, int n)
        {
            Int64[] x = new Int64[4] { 1, 0, 1, 0 };
            while (n > 0)
            {
                if (n % 2 == 1)
                {
                    x = matrix_multiply(x, A);
                    if (n == 1) break;
                }
                A = matrix_multiply(A, A);
                n /= 2;
            }
            return x;
        }


        public Int64 GetFibonacciNumberAt(int n)
        {
            if (n > 92 || n < -92)
            {
                throw new ArgumentOutOfRangeException(nameof(n), n, "Input number should be between -92 and 92");
            }
            if (n < 0)
            {
                n = -n;
                if (n % 2 == 0)
                {
                    return -matrix_power(F, n)[1];
                }
            }
            return matrix_power(F, n)[1];

        }
    }
}
