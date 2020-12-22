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
            var start = DateTime.UnixEpoch + new TimeSpan((int)startHour, (int)startMinute, 0);
            var span = new TimeSpan((int)hoursToAdd, (int)minutesToAdd, 0);
            var end = start + span;

            var startPlanetTime = new PlanetTime<EarthTimeConfiguration>(startHour, startMinute);
            var planetTimeSpan = new PlanetTimeSpan<EarthTimeConfiguration>(hoursToAdd, minutesToAdd);
            var endPlanetTime = startPlanetTime + planetTimeSpan;

            Assert.Equal(((long)end.Hour, (long)end.Minute), endPlanetTime.ToTime());
        }

        public static IEnumerable<object[]> GetOperatorPlusTestData()
        {
            yield return new object[] { 12, 0, 1, 0 };
            yield return new object[] { 23, 59, 1, 0 };
            yield return new object[] { 13, 17, 3, 3 };
            yield return new object[] { 23, 59, 26, 17 };
        }

        [Theory]
        [MemberData(nameof(GetOperatorMinusTestData))]
        public void OperatorMinus_ReturnsCorrectValue(long startHour, long startMinute, long endHour, long endMinute)
        {
            var start = DateTime.UnixEpoch + new TimeSpan((int)startHour, (int)startMinute, 0);
            var end = DateTime.UnixEpoch + new TimeSpan((int)endHour, (int)endMinute, 0);
            if(end < start)
            {
                end = end.AddDays(1);
            }
            var span = end - start;

            var startPlanetTime = new PlanetTime<EarthTimeConfiguration>(startHour, startMinute);
            var endPlanetTime = new PlanetTime<EarthTimeConfiguration>(endHour, endMinute);
            var planetTimeSpan = endPlanetTime - startPlanetTime;

            Assert.Equal(((long)span.Hours, (long)span.Minutes), planetTimeSpan.ToTime());
        }

        public static IEnumerable<object[]> GetOperatorMinusTestData()
        {
            yield return new object[] { 12, 0, 13, 0 };
            yield return new object[] { 23, 59, 1, 0 };
            yield return new object[] { 13, 17, 3, 3 };
            yield return new object[] { 23, 59, 0, 0 };
        }

        [Fact]
        public void Ctor_ThrowsException_IfInvalidTime()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new PlanetTime<EarthTimeConfiguration>(24, 0));
        }
    }
}
