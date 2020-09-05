using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptoExamples.Symmetric
{
    public class SymmetricEncryptorr
    {
        /// <summary>
        /// Encrypts the string as an asynchronous operation.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<string> EncryptStringAsync(string key, string value)
        {
            if (key.Length != 32)
            {
                throw new ArgumentException("Key length must be 32 bits");
            }

            return await EncryptStringAsync(Encoding.UTF8.GetBytes(key), value);
        }

        /// <summary>
        /// Encrypts the string as an asynchronous operation.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<string> EncryptStringAsync(byte[] key, string value)
        {
            if(key.Length != 32)
            {
                throw new ArgumentException("Key length must be 32 bits");
            }

            var iv = new byte[16];

            byte[] array;

            using (var aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var memoryStream = new MemoryStream())
                using (var cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (var streamWriter = new StreamWriter((Stream)cryptoStream))
                    {
                        await streamWriter.WriteAsync(value);
                    }

                    array = memoryStream.ToArray();
                }
            }

            return Convert.ToBase64String(array);
        }

        /// <summary>
        /// Decrypts the string as an asynchronous operation.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<string> DecryptStringAsync(string key, string value)
        {
            if (key.Length != 32)
            {
                throw new ArgumentException("Key length must be 32 bits");
            }

            return await DecryptStringAsync(Encoding.UTF8.GetBytes(key), value);
        }

        /// <summary>
        /// Decrypts the string as an asynchronous operation.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<string> DecryptStringAsync(byte[] key,string value)
        {
            if (key.Length != 32)
            {
                throw new ArgumentException("Key length must be 32 bits");
            }

            var iv = new byte[16];
            var buffer = Convert.FromBase64String(value);

            using (var aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var memoryStream = new MemoryStream(buffer))
                using (var cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                using (var streamReader = new StreamReader((Stream)cryptoStream))
                {
                    return await streamReader.ReadToEndAsync();
                }
            }
        }

        /// <summary>
        /// Encrypts the file as an asynchronous operation.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public async Task<byte[]> EncryptFileAsync(string key, string filePath)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Encrypts the file as an asynchronous operation.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fileData"></param>
        /// <returns></returns>
        public async Task<byte[]> EncryptFileAsync(string key, byte[] fileData)
        {
            throw new NotImplementedException();
        }

    }
}