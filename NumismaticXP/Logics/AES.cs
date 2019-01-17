using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace NumismaticXP.Logics
{
    public class AES
    {
        private readonly Random random;
        private readonly byte[] key;
        private readonly RijndaelManaged rm;
        private readonly UTF8Encoding encoder;

        public AES()
        {
            random = new Random();
            rm = new RijndaelManaged();
            encoder = new UTF8Encoding();
            key = Convert.FromBase64String("hAO9PBvOdH2QkGQz");
        }

        public string Encrypt(string unencrypted)
        {
            var vector = new byte[16];
            random.NextBytes(vector);
            var cryptogram = vector.Concat(Encrypt(encoder.GetBytes(unencrypted), vector));
            return Convert.ToBase64String(cryptogram.ToArray());
        }

        public string Decrypt(string encrypted)
        {
            var cryptogram = Convert.FromBase64String(encrypted);
            if (cryptogram.Length < 17)
            {
                //throw new ArgumentException("Not a valid encrypted string", "encrypted");
                return null;
            }

            var vector = cryptogram.Take(16).ToArray();
            var buffer = cryptogram.Skip(16).ToArray();
            return encoder.GetString(Decrypt(buffer, vector));
        }

        private byte[] Encrypt(byte[] buffer, byte[] vector)
        {
            var encryptor = rm.CreateEncryptor(key, vector);
            return Transform(buffer, encryptor);
        }

        private byte[] Decrypt(byte[] buffer, byte[] vector)
        {
            var decryptor = rm.CreateDecryptor(key, vector);
            return Transform(buffer, decryptor);
        }

        private byte[] Transform(byte[] buffer, ICryptoTransform transform)
        {
            var stream = new MemoryStream();
            using (var cs = new CryptoStream(stream, transform, CryptoStreamMode.Write))
            {
                cs.Write(buffer, 0, buffer.Length);
            }

            return stream.ToArray();
        }
    }
}
