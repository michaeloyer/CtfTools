using System;

namespace CtfTools
{
    public static class Clipboard
    {
        public static void ToClipboard(this string text)
        {
            TextCopy.Clipboard.SetText(text);

            var previousColor = Console.ForegroundColor;
            Console.Write($"Text sent to clipboard: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"|");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"|");
            Console.ForegroundColor = previousColor;
        }

        public static string GetClipboard() =>
            TextCopy.Clipboard.GetText() ?? string.Empty;
    }
}
