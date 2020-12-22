using System;

namespace MarsMoons.Core
{
    public class MarsDateTime
    {
        private const long MinutesPerHour = 100;
        private const long HoursPerDay = 25;

        private const long TicksPerMinute = 1;
        private const long TicksPerHour = TicksPerMinute * MinutesPerHour;
        private const long TicksPerDay = TicksPerHour * HoursPerDay;

        readonly long _ticks;

        public MarsDateTime(long ticks) => _ticks = ticks;
        public MarsDateTime(long hour, long minute) : this(TimeToTicks(hour, minute)) { }
        
        static long TimeToTicks(long hour, long minute)
        {
            if (hour is < 0 or >= HoursPerDay || minute is < 0 or >= MinutesPerHour)
            {
                throw new ArgumentOutOfRangeException($"{hour}:{minute} is not a valid MarsTime");
            }
            var minutes = hour * HoursPerDay + minute;
            return minutes * TicksPerMinute;
        }

        static (long hour, long minute) TicksToTime(long ticks)
        {
            if(ticks is < 0 or >= TicksPerDay)
            {
                throw new ArgumentOutOfRangeException($"Ticks ({ticks}) is not a valid");
            }
            var hour = ticks / TicksPerHour;
            var minute = (ticks % TicksPerHour) / TicksPerMinute;
            return (hour, minute);
        }

        public static MarsTimeSpan operator -(MarsDateTime a, MarsDateTime b) => 
            a._ticks > b._ticks ?
                new MarsTimeSpan(a._ticks - b._ticks) :
                new MarsTimeSpan(a._ticks - b._ticks + TicksPerDay);

        public static MarsDateTime operator +(MarsDateTime time, MarsTimeSpan span) => 
            time._ticks + span._ticks < TicksPerDay ?
                new MarsDateTime(time._ticks + span._ticks) :
                new MarsDateTime(time._ticks)
    }
}
