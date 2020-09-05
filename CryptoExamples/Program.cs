using CryptoExamples.Symmetric;
using CryptoExamples.Utilities;
using System;

namespace CryptoExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 0; i < 10; i++)
            {
                try
                {
                    var key = KeyGenerator.GenerateKey(32);

                    var enc = new SymmetricEncryptorr();

                    var encrypted = enc.EncryptStringAsync(key, "Justin LeCheminant").Result;

                    Console.WriteLine(encrypted);

                    var decrypted = enc.DecryptStringAsync(key, encrypted).Result;

                    Console.WriteLine(decrypted);
                    Console.WriteLine();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}