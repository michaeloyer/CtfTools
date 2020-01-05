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
        [DataRow("abcd", 4, "abcd")]
        [DataRow("abcd", 5, "abcd")]
        [DataRow("abcd", 0, "")]
        public void Left(string text, int length, string expected) =>
            text.Left(length).Should().BeEquivalentTo(expected);

        [DataTestMethod]
        [DataRow("abcd", 1, "d")]
        [DataRow("abcd", 2, "cd")]
        [DataRow("abcd", 4, "abcd")]
        [DataRow("abcd", 5, "abcd")]
        [DataRow("abcd", 0, "")]
        public void Right(string text, int length, string expected) =>
            text.Right(length).Should().BeEquivalentTo(expected);
    }
}
