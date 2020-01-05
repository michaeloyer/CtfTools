using System;
using System.Collections.Generic;

namespace CtfTools
{
    public static class Binary
    {
        public static int BinaryToByte(this IEnumerable<int> bits) => Convert.ToByte(string.Concat(bits), 2);
        public static int BinaryToByte(this string bits) => Convert.ToByte(bits, 2);
    }
}
