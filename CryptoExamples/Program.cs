using CryptoExamples.Symmetric;
using CryptoExamples.Utilities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Threading.Tasks;

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
                    var key = KeyGenerator.GenerateByteKey(32);

                    var enc = new SymmetricEncryptorr();

                    var encrypted = enc.EncryptStringAsync(key, "Justin LeCheminant").Result;

                    Console.WriteLine(encrypted);
                    Console.WriteLine();

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
