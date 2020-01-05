namespace CtfTools
{
    public static class Clipboard
    {
        public static void ToClipboard(this string text) =>
            TextCopy.Clipboard.SetText(text);

        public static string GetClipboard() =>
            TextCopy.Clipboard.GetText() ?? string.Empty;
    }
}
