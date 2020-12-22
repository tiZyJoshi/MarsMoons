namespace MarsMoons.Core
{
    public class PlanetTimeSpan<TTimeConfiguration> where TTimeConfiguration : IPlanetTimeConfiguration, new()
    {
        private static IPlanetTimeConfiguration TimeConfiguration = new TTimeConfiguration();
        internal readonly long _ticks;

        public PlanetTimeSpan(long ticks) => _ticks = ticks;
        public PlanetTimeSpan(long hours, long minutes) : this(TimeConfiguration.TimeSpanToTicks(hours, minutes)) { }
    }
}
