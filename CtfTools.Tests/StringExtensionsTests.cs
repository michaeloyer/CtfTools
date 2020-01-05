using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CtfTools.Tests
{
    [TestClass]
    public class StringExtensionsTests
    {
        [DataTestMethod]
        [DataRow("abcd", 1, "a")]
        [DataRow("abcd", 2, "ab")]
        [DataRow("abcd", 3, "abc")]
        [DataRow("abcd", 4, "abcd")]
        [DataRow("abcd", 5, "abcd")]
        [DataRow("abcd", 0, "")]
        [DataRow("abcd", -1, "abc")]
        [DataRow("abcd", -2, "ab")]
        [DataRow("abcd", -3, "a")]
        [DataRow("abcd", -4, "")]
        public void Left(string text, int length, string expected) =>
            text.Left(length).Should().BeEquivalentTo(expected);

        [DataTestMethod]
        [DataRow("abcd", 1, "d")]
        [DataRow("abcd", 2, "cd")]
        [DataRow("abcd", 3, "bcd")]
        [DataRow("abcd", 4, "abcd")]
        [DataRow("abcd", 5, "abcd")]
        [DataRow("abcd", 0, "")]
        [DataRow("abcd", -1, "bcd")]
        [DataRow("abcd", -2, "cd")]
        [DataRow("abcd", -3, "d")]
        [DataRow("abcd", -4, "")]
        public void Right(string text, int length, string expected) =>
            text.Right(length).Should().BeEquivalentTo(expected);
    }
}
