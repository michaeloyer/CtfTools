using System;
using System.Text;

namespace CtfTools
{
    public static class StringExtensions
    {
        public static string DecodeBase64(this string text) =>
            DecodeBase64(text, Encoding.UTF8);

        public static string DecodeBase64(this string text, Encoding encoding) =>
            encoding.GetString(Convert.FromBase64String(text));

        public static string EncodeBase64(this string text) =>
            EncodeBase64(text, Encoding.UTF8);

        public static string EncodeBase64(this string text, Encoding encoding) =>
            Convert.ToBase64String(encoding.GetBytes(text));
    }
}
