using CryptoExamples.SHA;
using CryptoExamples.Symmetric;
using CryptoExamples.Utilities;
using System;
using System.Collections.Generic;
using System.IO;

namespace CryptoExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = new List<string>();
            words.AddRange(File.ReadAllLines("c:\\words.txt"));

            using (var writer = File.CreateText("C:\\Words256.txt"))
            {
                foreach (var word in words)
                {
                    var hashed = ShaHash.Sha256Hash(word);
                    writer.WriteLine($"{word}:{Convert.ToBase64String(hashed)}");
                }
            }

            using (var writer = File.CreateText("C:\\Words512.txt"))
            {
                foreach (var word in words)
                {
                    var hashed = ShaHash.Sha512Hash(word);
                    writer.WriteLine($"{word}:{Convert.ToBase64String(hashed)}");
                }
            }

        }
    }
}