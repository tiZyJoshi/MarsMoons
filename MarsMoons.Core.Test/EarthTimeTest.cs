using System;
using System.Collections.Generic;
using Xunit;

namespace MarsMoons.Core.Test
{
    public class EarthTimeTest
    {
        [Theory]
        [MemberData(nameof(GetOperatorPlusTestData))]
        public void OperatorPlus_ReturnsCorrectValue(long startHour, long startMinute, long hoursToAdd, long minutesToAdd)
        {
            var start = new DateTime(0, 0, 0, (int)startHour, (int)startMinute, 0, 0);
            var span = new TimeSpan((int)hoursToAdd, (int)minutesToAdd, 0);
            var end = start + span;

            Assert.Equal(((long)end.Hour, (long)end.Minute), (new PlanetTime<EarthTimeConfiguration>(startHour, startMinute) + new PlanetTimeSpan<EarthTimeConfiguration>(hoursToAdd, minutesToAdd)).ToTime());
        }

        [Fact]
        public void Repeat_ThrowsException_IfLengthIsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => LoopRangeLong.Repeat(1, 0));
        }

        public static IEnumerable<object[]> GetOperatorPlusTestData()
        {
            yield return new object[] { 12, 0, 1, 0 };
        }
    }
}
