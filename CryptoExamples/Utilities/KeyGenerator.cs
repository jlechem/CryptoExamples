using System;
using System.Text;

namespace CryptoExamples.Utilities
{
    public static class KeyGenerator
    {
        private static Random _random = new Random();

        public static string GenerateKey(int length = 256)
        {
            var result = String.Empty;

            for (var i = 0; i < length; i++)
            {
                var letter = (char)_random.Next(32, 126);
                result = $"{result}{letter}";
            }

            return result;
        }

        public static byte[] GenerateByteKey(int length = 256)
        {
            var result = new byte[length];

            _random.NextBytes(result);

            return result;
        }

    }
}