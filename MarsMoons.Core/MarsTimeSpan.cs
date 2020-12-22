using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsMoons.Core
{
    public class MarsTimeSpan
    {

        internal readonly long _ticks;

        public MarsTimeSpan(long ticks) => _ticks = ticks;
    }
}
