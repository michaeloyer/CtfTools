using System;

namespace CtfTools
{
    public static class ObjectExtensions
    {
        public static void ConsoleWrite(this object obj) => Console.Write(obj);
        public static void ConsoleWriteLine(this object obj) => Console.WriteLine(obj);
    }
}
