using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnockKnock.Services
{
    public interface ITriangleTypeService
    {
        TriangleType GetTriangleType(int a, int b, int c);
    }
}
