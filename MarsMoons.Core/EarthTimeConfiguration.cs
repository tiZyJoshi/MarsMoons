namespace MarsMoons.Core
{
    public class EarthTimeConfiguration : IPlanetTimeConfiguration
    {
        long IPlanetTimeConfiguration.MinutesPerHour => 60;
        long IPlanetTimeConfiguration.HoursPerDay => 24;
        long IPlanetTimeConfiguration.TicksPerMinute => 1;
    }
}
