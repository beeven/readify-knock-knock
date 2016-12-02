using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnockKnock.Services
{
    public class TriangleTypeService:ITriangleTypeService
    {
        public TriangleType GetTriangleType(int a, int b, int c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                return TriangleType.Error;
            }
            if (a - c >= b || b - c >= a || c - b >= a) // using + may cause overflow
            {
                return TriangleType.Error;
            }
            if (a == b && b == c)
            {
                return TriangleType.Equilateral;
            }
            if (a == b || b == c || c == a)
            {
                return TriangleType.Isosceles;
            }
            return TriangleType.Scalene;
        }
    }

    public enum TriangleType
    {
        Error,
        Equilateral,
        Isosceles,
        Scalene
    }

}