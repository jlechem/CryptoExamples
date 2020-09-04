using CryptoExamples.Utilities;
using System;
using System.ComponentModel.DataAnnotations;

namespace CryptoExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 0; i < 10; i++)
            {
                var foo = KeyGenerator.GenerateKey();
                Console.WriteLine(foo);
                Console.WriteLine();
            }
        }
    }
}
