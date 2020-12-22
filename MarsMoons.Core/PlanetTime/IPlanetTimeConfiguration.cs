using System;

namespace MarsMoons.Core
{
    public interface IPlanetTimeConfiguration
    {
        public long MinutesPerHour { get; }
        public long HoursPerDay { get; }
        public long TicksPerMinute { get; }
        public long TicksPerHour => MinutesPerHour * TicksPerMinute;
        public long TicksPerDay => HoursPerDay * TicksPerHour;

        public long TimeSpanToTicks(long hours, long minutes) =>
            (hours * MinutesPerHour + minutes) * TicksPerMinute;

        public long TimeToTicks(long hour, long minute) =>
            (hour < 0 || hour >= HoursPerDay || minute < 0 || minute >= MinutesPerHour) ?
                throw new ArgumentOutOfRangeException($"{hour}:{minute} is not a valid {GetType()}") :
                TimeSpanToTicks(hour, minute);

        public (long hour, long minute) TicksToTime(long ticks)
        {
            var dayTicks = LoopRangeLong.Repeat(ticks, TicksPerDay);
            var hour = dayTicks / TicksPerHour;
            var minute = (dayTicks % TicksPerHour) / TicksPerMinute;
            return (hour, minute);
        }

        public long TicksToDayTicks(long ticks) =>
            LoopRangeLong.Repeat(ticks, TicksPerDay);
    }
}
