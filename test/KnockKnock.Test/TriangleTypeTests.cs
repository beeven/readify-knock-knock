using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using KnockKnock.Services;

namespace KnockKnock.Test
{
    public class TriangleTypeTests
    {
        private readonly ITriangleTypeService _triangleTypeService;
        public TriangleTypeTests()
        {
            _triangleTypeService = new TriangleTypeService();
        }


        [Theory]
        [InlineData(1,1,1)]
        [InlineData(int.MaxValue, int.MaxValue, int.MaxValue)]
        public void ReturnEquilateralIfAllThreeEdgesAreOfSameLength(int a, int b, int c)
        {
            var actual = _triangleTypeService.GetTriangleType(a, b, c);
            actual.Should().Be(TriangleType.Equilateral);
        }


        [Theory]
        [InlineData(3, 3, 2)]
        [InlineData(int.MaxValue, int.MaxValue, int.MaxValue-1)]
        public void ReturnIsoscelesIfOnlyTwoEdgesAreOfSameLength(int a, int b, int c)
        {
            var actual = _triangleTypeService.GetTriangleType(a, b, c);
            actual.Should().Be(TriangleType.Isosceles);
        }

        [Theory]
        [InlineData(3, 4, 5)]
        [InlineData(int.MaxValue, int.MaxValue - 1, int.MaxValue - 2)]
        public void ReturnsceleneIfEdgesAreOfDifferentLength(int a, int b, int c)
        {
            var actual = _triangleTypeService.GetTriangleType(a, b, c);
            actual.Should().Be(TriangleType.Scalene);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(0, 1, 2)]
        [InlineData(-1,-1,-1)]
        [InlineData(int.MinValue,int.MinValue,int.MinValue)]
        public void ReturnErrorIfNotATriangle(int a, int b, int c)
        {
            var actual = _triangleTypeService.GetTriangleType(a, b, c);
            actual.Should().Be(TriangleType.Error);
        }


    }
}
