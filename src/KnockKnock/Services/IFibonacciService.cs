using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnockKnock.Services
{
    public interface IFibonacciService
    {
        Int64 GetFibonacciNumberAt(int n);
    }
}
