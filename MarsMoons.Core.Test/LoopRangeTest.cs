using System;
using System.Collections.Generic;
using Xunit;

namespace MarsMoons.Core.Test
{
    public class LoopRangeTest
    {
        [Theory]
        [MemberData(nameof(GetRepeatTestData))]
        public void Repeat_ReturnsCorrectValue(long value, long length, long expectedMod)
        {
            Assert.Equal(expectedMod, LoopRangeLong.Repeat(value, length));
        }

        [Fact]
        public void Repeat_ThrowsException_IfLengthIsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => LoopRangeLong.Repeat(1, 0));
        }

        public static IEnumerable<object[]> GetRepeatTestData()
        {
            yield return new object[] { 1, 1, 0 };
            yield return new object[] { 0, 1, 0 };
            yield return new object[] { 2, 10, 2 };
            yield return new object[] { 12, 10, 2 };
            yield return new object[] { 22, 10, 2 };
            yield return new object[] { -2, 10, 8 };
            yield return new object[] { -12, 10, 8 };
            yield return new object[] { -22, 10, 8 };
            yield return new object[] { 2, -10, -8 };
            yield return new object[] { 12, -10, -8 };
            yield return new object[] { 22, -10, -8 };
            yield return new object[] { -2, -10, -2 };
            yield return new object[] { -12, -10, -2 };
            yield return new object[] { -22, -10, -2 };
        }
    }
}
