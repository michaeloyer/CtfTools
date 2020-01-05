using Newtonsoft.Json;
using System;

namespace CtfTools
{
    public static class ObjectExtensions
    {
        public static void ConsoleWrite(this object obj) => Console.Write(obj);
        public static void ConsoleWriteLine(this object obj) => Console.WriteLine(obj);
        public static string ToJson(this object obj, Formatting formatting = Formatting.Indented) =>
            JsonConvert.SerializeObject(obj, formatting);
    }
}
