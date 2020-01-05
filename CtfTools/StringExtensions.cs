using Newtonsoft.Json;
using Superpower;
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

        public static string RegexRemove(this string text, string pattern) =>
            RegexReplace(text, pattern, string.Empty, RegexOptions.None);

        public static string RegexRemove(this string text, string pattern, RegexOptions options) =>
            RegexReplace(text, pattern, string.Empty, options);

        public static IEnumerable<string> GetWords(this string text) =>
            RegexMatches(text, @"\S+");

        public static string Left(this string text, int length) =>
            length == 0 || length < -text.Length
                ? string.Empty
            : length > text.Length
                ? text
            : length < 0
                ? text.Substring(0, length + text.Length)
            :
                text.Substring(0, length);

        public static string Right(this string text, int length) =>
            length == 0 || length < -text.Length
                ? string.Empty
            : length > text.Length
                ? text
            : length < 0
                ? text.Substring(length * -1)
            :
                text.Substring(text.Length - length);

        private static readonly Phonix.Soundex soundex = new Phonix.Soundex();
        public static string Soundex(this string text) => soundex.BuildKey(text);
        public static T FromJson<T>(this string text) => JsonConvert.DeserializeObject<T>(text);

        public static T TextParse<TToken, T>(this string text, TextParser<T> parser) =>
            parser.Parse(text);

        public static T TokenParse<TToken, T>(this string text, Tokenizer<TToken> tokenizer, TokenListParser<TToken, T> tokenParser) =>
            tokenParser.Parse(tokenizer.Tokenize(text));
    }
}
