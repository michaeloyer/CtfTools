using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CtfTools.Tests
{
    [TestClass]
    public class BaconCipherTests
    {
        [DataTestMethod]
        [DataRow('A', 0)]
        [DataRow('B', 1)]
        [DataRow('Z', 23)]
        public void NormalUsingValidCharacter_ReturnsNumber(char character, int number)
        {
            BaconCipher.Normal[character].Should().Be(number);
        }

        [DataTestMethod]
        [DataRow('J')]
        [DataRow('V')]
        [DataRow('?')]
        public void NormalUsingInvalidCharacter_ThrowsBaconCipherException(char invalidCharacter)
        {
            Assert.ThrowsException<BaconCipherException>(() =>
                BaconCipher.Normal[invalidCharacter]
            );
        }

        [DataTestMethod]
        [DataRow(0, 'A')]
        [DataRow(1, 'B')]
        [DataRow(23, 'Z')]
        public void NormalUsingValidNumber_ReturnsCharacter(int number, char character)
        {
            BaconCipher.Normal[number].Should().Be(character);
        }

        [DataTestMethod]
        [DataRow(24)]
        [DataRow(25)]
        [DataRow(26)]
        [DataRow(27)]
        public void NormalUsingInvalidNumber_ThrowsBaconCipherException(int invalidNumber)
        {
            Assert.ThrowsException<BaconCipherException>(() =>
                BaconCipher.Normal[invalidNumber]
            );
        }

        [DataTestMethod]
        [DataRow('A', 0)]
        [DataRow('B', 1)]
        [DataRow('J', 9)]
        [DataRow('V', 21)]
        [DataRow('Z', 25)]
        public void FullUsingValidCharacter_ReturnsNumber(char character, int number)
        {
            BaconCipher.Full[character].Should().Be(number);
        }

        [DataTestMethod]
        [DataRow('?')]
        public void FullUsingInvalidCharacter_ThrowsBaconCipherException(char invalidCharacter)
        {
            Assert.ThrowsException<BaconCipherException>(() =>
                BaconCipher.Full[invalidCharacter]
            );
        }

        [DataTestMethod]
        [DataRow(0, 'A')]
        [DataRow(1, 'B')]
        [DataRow(9, 'J')]
        [DataRow(21, 'V')]
        [DataRow(25, 'Z')]
        public void FullUsingValidNumber_ReturnsCharacter(int number, char character)
        {
            BaconCipher.Full[number].Should().Be(character);
        }

        [DataTestMethod]
        [DataRow(26)]
        [DataRow(27)]
        public void FullUsingInvalidNumber_ThrowsBaconCipherException(int invalidNumber)
        {
            Assert.ThrowsException<BaconCipherException>(() =>
                BaconCipher.Full[invalidNumber]
            );
        }
    }
}
