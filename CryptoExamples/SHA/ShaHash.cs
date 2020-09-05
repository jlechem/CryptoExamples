using System.Security.Cryptography;
using System.Text;

namespace CryptoExamples.SHA
{
    public static class ShaHash
    {
        /// <summary>
        /// Gets a SHA 512 Hash for a byte array.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] Sha512Hash(byte[] value)
        {
            using (var shaM = new SHA512Managed())
            {
                return shaM.ComputeHash(value);
            }
        }

        /// <summary>
        /// Gets a SHA 512 Hash for a string value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] Sha512Hash(string value)
        {
            using (var shaM = new SHA512Managed())
            {
                return shaM.ComputeHash(Encoding.UTF8.GetBytes(value));
            }
        }

        /// <summary>
        /// Gets a SHA 256 Hash for a string value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] Sha256Hash(string value)
        {
            using (var shaM = new SHA256Managed())
            {
                return shaM.ComputeHash(Encoding.UTF8.GetBytes(value));
            }
        }

        /// <summary>
        /// Gets a SHA 512 Hash for a byte array.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] Sha256(byte[] value)
        {
            using (var shaM = new SHA256Managed())
            {
                return shaM.ComputeHash(value);
            }
        }

    }
}
