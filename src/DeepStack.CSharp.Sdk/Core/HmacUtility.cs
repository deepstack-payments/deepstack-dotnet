using System;
using System.Security.Cryptography;
using System.Text;

namespace DeepStack.Core
{
    /// <summary>
    /// HMAC Utility Class, used for HMACSHA256 hash generation
    /// </summary>
    internal static class HmacUtility
    {
        /// <summary>
        /// Create Hmac Header
        /// </summary>
        /// <param name="message">The message string that to be hashed</param>
        /// <param name="sharedSecret">The Globally Paid Shared Secret</param>
        /// <param name="appId">The Globally Paid APP ID</param>
        /// <returns></returns>
        public static string CreateHmacHeader(string message, string sharedSecret, string appId, string requestMethod)
        {
            var guid = Guid.NewGuid();
            var requestTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            var stringToHash = $"{appId}|{requestMethod}|{requestTime}|{guid}|{message}";
            var hashInBase64 = GenerateHMACSHA256Hash(stringToHash, sharedSecret);
            var hmac = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{appId}|{requestMethod}|{requestTime}|{guid}|{hashInBase64}"));
            return hmac;
        }

        /// <summary>
        /// Generate HMAC SHA256 Hash
        /// </summary>
        /// <param name="message">The message string that to be hashed</param>
        /// <param name="secret">The secret used to hash the message string</param>
        /// <returns></returns>
        public static string GenerateHMACSHA256Hash(string message, string secret)
        {
            secret = secret ?? "";
            var encoding = new ASCIIEncoding();
            byte[] keyByte = Convert.FromBase64String(secret);
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }
    }
}
