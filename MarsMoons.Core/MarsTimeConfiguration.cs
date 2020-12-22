namespace MarsMoons.Core
{
    public class MarsTimeConfiguration : IPlanetTimeConfiguration
    {
        long IPlanetTimeConfiguration.MinutesPerHour => 100;
        long IPlanetTimeConfiguration.HoursPerDay => 25;
        long IPlanetTimeConfiguration.TicksPerMinute => 1;
    }
}
