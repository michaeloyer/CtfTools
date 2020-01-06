using Newtonsoft.Json;
using System;
using System.Reflection;

namespace CtfTools
{
    public static class ObjectExtensions
    {
        public static void ConsoleWrite(this object obj) => Console.Write(obj);
        public static void ConsoleWriteLine(this object obj) => Console.WriteLine(obj);
        public static void ConsoleWriteProperties(this object obj, bool includePropertyNames = false)
        {
            var previousColor = Console.ForegroundColor;
            var nameColor = ConsoleColor.Yellow;
            var valueColor = ConsoleColor.Cyan;

            foreach (var property in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (includePropertyNames)
                {
                    Console.ForegroundColor = nameColor;
                    Console.Write(property.Name);
                    Console.ForegroundColor = previousColor;
                    Console.Write(": ");
                }
                Console.ForegroundColor = valueColor;
                Console.Write(property.GetValue(obj));
                Console.ForegroundColor = previousColor;
                Console.Write("; ");
            }
            Console.WriteLine();
        }
        public static string ToJson(this object obj, Formatting formatting = Formatting.Indented) =>
            JsonConvert.SerializeObject(obj, formatting);
    }
}
