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
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<string> EncryptStringAsync(byte[] key, string value)
        {
            var iv = new byte[16];

            byte[] array;

            using (var aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            await streamWriter.WriteAsync(value);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<string> DecryptStringAsync(byte[] key,string value)
        {
            var iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(value);

            using (var aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return await streamReader.ReadToEndAsync();
                        }
                    }
                }
            }
        }
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public async Task<byte[]> EncryptFileAsync(string key, string filePath)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
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