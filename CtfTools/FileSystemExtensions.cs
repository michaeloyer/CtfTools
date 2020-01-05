using System.IO;
using System.Text;

namespace CtfTools
{
    public static class FileSystemExtensions
    {
        public static string ReadFile(this string path) =>
            ReadFile(path, Encoding.UTF8);

        public static string ReadFile(this string path, Encoding encoding) =>
            File.ReadAllText(path, encoding);

        public static void WriteFile(this string text, string path) =>
            WriteFile(text, path, Encoding.UTF8);

        public static void WriteFile(this string text, string path, Encoding encoding) =>
            File.WriteAllText(path, text, encoding);
    }
}
