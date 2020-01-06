using System.Collections.Generic;
using System.Text;

namespace CtfTools
{
    public static class EnumerableExtensions
    {
        public static string ToFlag(this IEnumerable<object> collection, string prefix = "")
        {
            var builder = new StringBuilder();

            using (var e = collection.GetEnumerator())
            {
                builder.Append(prefix);
                e.MoveNext();
                var part = e.Current.ToString();

                if (part != prefix)
                {
                    builder.Append("-");
                    builder.Append(part);
                }

                while (e.MoveNext())
                {
                    builder.Append("-");
                    builder.Append(e.Current);
                }
            }

            return builder.ToString();
        }
    }
}
