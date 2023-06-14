using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;

namespace BZPAY_BE.Helpers
{
    public static class SecurityHelper
    {
        /// Encript a string.
        public static string Encript(string _cadenaAEncript)
        {
            string result = string.Empty;
            byte[] encryted = Encoding.UTF8.GetBytes(_cadenaAEncript);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// unencript a string.
        public static string Decript(string _cadenaADecript)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaADecript);
            result = Encoding.UTF8.GetString(decryted);
            return result;
        }

        //public static bool DecriptHash(string providedPassword, string storedPasswordHash)
        //{
        //    // Obtener la sal y las iteraciones desde el PasswordHash almacenado
        //    byte[] storedSalt = new byte[16];
        //    Array.Copy(Convert.FromBase64String(storedPasswordHash), 1, storedSalt, 0, 16);
        //    //int storedIterations = BitConverter.ToInt32(Convert.FromBase64String(storedPasswordHash), 17);
        //    int storedIterations = BitConverter.ToInt32(Convert.FromBase64String(storedPasswordHash), 21);

        //    // Derivar la contraseña proporcionada usando la misma sal y las mismas iteraciones
        //    string derivedPasswordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        //        password: providedPassword,
        //        salt: storedSalt,
        //        prf: KeyDerivationPrf.HMACSHA256,
        //        iterationCount: storedIterations,
        //        numBytesRequested: 64));

        //    // Comparar el PasswordHash derivado con el PasswordHash almacenado
        //    bool passwordMatches = derivedPasswordHash.Equals(storedPasswordHash, StringComparison.OrdinalIgnoreCase);

        //    return passwordMatches;
        //}

        public static bool ValidatePassword(string providedPassword, string storedPasswordHash)
        {
            var passwordHasher = new PasswordHasher<object>(); // Puedes ajustar el tipo de objeto según tus necesidades

            // Verificar si la contraseña proporcionada coincide con el hash almacenado
            var passwordVerificationResult = passwordHasher.VerifyHashedPassword(null, storedPasswordHash, providedPassword);

            return passwordVerificationResult == PasswordVerificationResult.Success;
        }

        public static string EncodePassword(string pass, int passwordFormat, string salt)
        {
            if (passwordFormat == 0)
                return pass;
            byte[] bytes = Encoding.Unicode.GetBytes(pass);
            byte[] src = Convert.FromBase64String(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            byte[] inArray = null;
            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            if (passwordFormat == 1)
            {
                HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
                if ((algorithm == null))
                {
                    throw new Exception("Invalid HashAlgoritm");
                }
                inArray = algorithm.ComputeHash(dst);
            }
            return Convert.ToBase64String(inArray);
        }
    }
}
