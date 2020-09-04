using System;
using System.Collections.Generic;   
using System.Text;

namespace CryptoExamples.Utilities
{
    public static class KeyGenerator
    {
        private static Random _random = new Random();

        public static string GenerateKey(int length = 1028)
        {
            if (length < 1028)
            {
                throw new ArgumentException($"Invalid key length {length}");
            }

            var result = String.Empty;

            for (var i = 0; i < length; i++)
            {
                var letter = (char)_random.Next(32, 126);
                result = $"{result}{letter}";
            }

            return result;
        }

    }
}