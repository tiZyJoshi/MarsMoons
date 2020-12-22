using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsMoons.Core
{
    internal class MarsTimeTicks
    {
        private const long MinutesPerHour = 100;
        private const long HoursPerDay = 25;

        private const long TicksPerMinute = 1;
        private const long TicksPerHour = TicksPerMinute * MinutesPerHour;
        private const long TicksPerDay = TicksPerHour * HoursPerDay;

        private readonly long _value;

        public MarsTimeTicks(long value) => 
            _value = value switch
            {
                >
            }


    }
}
