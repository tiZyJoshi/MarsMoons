using System;

namespace MarsMoons.Core
{
    public static class LoopRangeLong
    {
        public static long Repeat(long value, long length)
        {
            if (length == 0)
                throw new ArgumentOutOfRangeException("length", $"({value} mod 0) is undefined.");

            var remainder = value % length;

            if ((length > 0 && remainder < 0) ||
                (length < 0 && remainder > 0))
                return remainder + length;
            return remainder;
        }
    }
}
