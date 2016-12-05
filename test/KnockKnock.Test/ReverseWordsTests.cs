using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnockKnock.Services;
using Xunit;
using FluentAssertions;

namespace KnockKnock.Test
{
    public class ReverseWordsTests
    {
        private readonly IReverseWordsService _reverseWordsService;
        public ReverseWordsTests()
        {
            _reverseWordsService = new ReverseWordsService();
        }

        [Fact]
        public void ShouldReturnEmptyGivenEmptySentence()
        {
            var actual = _reverseWordsService.ReverseWords("");
            actual.Should().BeEmpty();
        }

        [Fact]
        public void ShouldReverseOnlyWordsGivenSentenceWithWhiteSpaces()
        {
            var actual = _reverseWordsService.ReverseWords("  abc  def ");
            actual.Should().Be("  cba  fed ");
        }

        [Fact]
        public void ShouldReverseWordsGivenSentenceWithUnicodeCharacter()
        {
            var actual = _reverseWordsService.ReverseWords("\u65E5\u672C\u8BED");
            actual.Should().Be("\u8BED\u672C\u65E5");
        }
    }
}
