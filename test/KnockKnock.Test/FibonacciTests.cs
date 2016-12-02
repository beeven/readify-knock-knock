using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using KnockKnock.Services;

namespace KnockKnock.Test
{
    public class FibonacciTests
    {
        private readonly IFibonacciService _fibonacciService;
        public FibonacciTests()
        {
            _fibonacciService = new FibonacciService();
            //_fibonacciService = new FibonacciMatrix();
            //_fibonacciService = new FibonacciPreCalculated();
        }

        [Fact]
        public void Return0GivenValueOf0()
        {
            var actual = _fibonacciService.GetFibonacciNumberAt(0);
            actual.ShouldBeEquivalentTo(0);
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(-4)]
        [InlineData(-92)]
        public void ReturnMinusNumbersGivenValuesOfMinusEvenNumbers(int n)
        {
            var actual = _fibonacciService.GetFibonacciNumberAt(-2);
            actual.Should().BeNegative();
        }

        [Fact]
        public void Return7540113804746346429GivenValueOf92()
        {
            var actual = _fibonacciService.GetFibonacciNumberAt(92);
            actual.ShouldBeEquivalentTo(7540113804746346429);
        }

        [Fact]
        public void ThrowArgumentOutOfRangeExceptionGivenValueOf93()
        {
            Action action = () => _fibonacciService.GetFibonacciNumberAt(93);
            action.ShouldThrow<ArgumentOutOfRangeException>();
        }
    }
}
