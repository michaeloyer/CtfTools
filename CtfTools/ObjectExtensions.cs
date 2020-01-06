using Newtonsoft.Json;
using System;
using System.Reflection;

namespace CtfTools
{
    public static class ObjectExtensions
    {
        public static T ConsoleWrite<T>(this T obj)
        {
            Console.Write(obj);
            return obj;
        }

        public static T ConsoleWriteLine<T>(this T obj)
        {
            Console.WriteLine(obj);
            return obj;
        }

        public static T ConsoleWriteProperties<T>(this T obj, bool includePropertyNames = false)
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
            return obj;
        }
        public static string ToJson(this object obj, Formatting formatting = Formatting.Indented) =>
            JsonConvert.SerializeObject(obj, formatting);
    }
}
