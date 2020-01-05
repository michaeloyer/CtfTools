using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
        public static string RegexMatch(this string text, string pattern) =>
            RegexMatch(text, pattern, RegexOptions.None);

        public static string RegexMatch(this string text, string pattern, RegexOptions options) =>
            Regex.Match(text, pattern, options).Value;

        public static IEnumerable<string> RegexMatches(this string text, string pattern) =>
            RegexMatches(text, pattern, RegexOptions.None);

        public static IEnumerable<string> RegexMatches(this string text, string pattern, RegexOptions options) =>
            Regex.Matches(text, pattern, options).Cast<Match>().Select(m => m.Value);

        public static string RegexReplace(this string text, string pattern, string replacement) =>
            RegexReplace(text, pattern, replacement, RegexOptions.None);

        public static string RegexReplace(this string text, string pattern, string replacement, RegexOptions options) =>
            Regex.Replace(text, pattern, replacement, options);

        public static IEnumerable<string> GetWords(this string text) =>
            RegexMatches(text, @"\S+");
    }
}
