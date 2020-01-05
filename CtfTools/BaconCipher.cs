using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CtfTools
{
    public class BaconCipher
    {
        private readonly Dictionary<char, int> CharToInt = new Dictionary<char, int>();
        private readonly Dictionary<int, char> IntToChar = new Dictionary<int, char>();

        private BaconCipher(IEnumerable<(char character, int number)> collection)
        {
            foreach (var (character, number) in collection)
            {
                CharToInt.Add(character, number);
                IntToChar.Add(number, character);
            }
        }

        /// <summary>
        /// Bacon Cipher, Excludes 'J' and 'V'
        /// </summary>
        public static BaconCipher Normal = new BaconCipher(new[] {
            ('A', 0),
            ('B', 1),
            ('C', 2),
            ('D', 3),
            ('E', 4),
            ('F', 5),
            ('G', 6),
            ('H', 7),
            ('I', 8),
            ('K', 9),
            ('L', 10),
            ('M', 11),
            ('N', 12),
            ('O', 13),
            ('P', 14),
            ('Q', 15),
            ('R', 16),
            ('S', 17),
            ('T', 18),
            ('U', 19),
            ('W', 20),
            ('X', 21),
            ('Y', 22),
            ('Z', 23),
        });


        /// <summary>
        /// Bacon Cipher Inclues 'J' and 'V'
        /// </summary>
        public static BaconCipher Full = new BaconCipher(new[] {
            ('A', 0),
            ('B', 1),
            ('C', 2),
            ('D', 3),
            ('E', 4),
            ('F', 5),
            ('G', 6),
            ('H', 7),
            ('I', 8),
            ('J', 9),
            ('K', 10),
            ('L', 11),
            ('M', 12),
            ('N', 13),
            ('O', 14),
            ('P', 15),
            ('Q', 16),
            ('R', 17),
            ('S', 18),
            ('T', 19),
            ('U', 20),
            ('V', 21),
            ('W', 22),
            ('X', 23),
            ('Y', 24),
            ('Z', 25),
        });

        public int this[char character]
        {
            get
            {
                var c = char.ToUpper(character);
                switch (character)
                {
                    case 'J':
                    case 'V':
                        if (!CharToInt.ContainsKey(character))
                            throw new BaconCipherException($"'J' and 'V' are not in Bacon Cipher, Consider using {nameof(BaconCipher)}.{nameof(Full)}");
                        return CharToInt[character];
                    default:
                        if (!CharToInt.ContainsKey(character))
                            throw new BaconCipherException($"Character not in Bacon Cipher: '{character}'");
                        return CharToInt[character];
                }
            }
        }

        public char this[int number]
        {
            get
            {
                switch (number)
                {
                    case 24:
                    case 25:
                        if (!IntToChar.ContainsKey(number))
                            throw new BaconCipherException($"'24' and '25' are not in Bacon Cipher, Consider using {nameof(BaconCipher)}.{nameof(Full)}");
                        return IntToChar[number];
                    default:
                        if (!IntToChar.ContainsKey(number))
                            throw new BaconCipherException($"Number not in Bacon Cipher: '{number}'");
                        return IntToChar[number];
                }
            }
        }
    }

    public class BaconCipherException : Exception
    {
        public BaconCipherException()
        {
        }

        public BaconCipherException(string message) : base(message)
        {
        }

        public BaconCipherException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BaconCipherException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
