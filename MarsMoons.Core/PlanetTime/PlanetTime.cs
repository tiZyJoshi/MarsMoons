namespace MarsMoons.Core
{
    public class PlanetTime<TTimeConfiguration> where TTimeConfiguration : IPlanetTimeConfiguration, new()
    {
        private static IPlanetTimeConfiguration TimeConfiguration = new TTimeConfiguration();
        private readonly long _ticks;

        public PlanetTime(long ticks) => 
            _ticks = TimeConfiguration.TicksToDayTicks(ticks);

        public PlanetTime(long hour, long minute) : 
            this(TimeConfiguration.TimeToTicks(hour, minute)) { }

        public (long hour, long minute) ToTime() => 
            TimeConfiguration.TicksToTime(_ticks);

        public static PlanetTimeSpan<TTimeConfiguration> operator -(PlanetTime<TTimeConfiguration> a, PlanetTime<TTimeConfiguration> b) =>
            new(TimeConfiguration.TicksToDayTicks(a._ticks - b._ticks));

        public static PlanetTime<TTimeConfiguration> operator +(PlanetTime<TTimeConfiguration> time, PlanetTimeSpan<TTimeConfiguration> span) =>
            new(time._ticks + span._ticks);
    }
}
