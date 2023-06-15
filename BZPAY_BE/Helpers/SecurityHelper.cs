using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

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

        public static bool ValidatePassword(string providedPassword, string storedPasswordHash)
        {
            var passwordHasher = new PasswordHasher<object>(); // Puedes ajustar el tipo de objeto según tus necesidades

            // Verificar si la contraseña proporcionada coincide con el hash almacenado
            var passwordVerificationResult = passwordHasher.VerifyHashedPassword(null, storedPasswordHash, providedPassword);

            return passwordVerificationResult == PasswordVerificationResult.Success;
        }

        public static string GenerateUserId()
        {
            return Guid.NewGuid().ToString();
        }

        public static string HashPassword(string password)
        {
            var passwordHasher = new PasswordHasher<string>();
            return passwordHasher.HashPassword(null, password);
        }

        public static string RemoveAccents(string input)
        {
            string normalizedString = input.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }

        public static string ConvertToUpperCase(string input)
        {
            return input.ToUpper();
        }

        public static string NormalizeString(string input)
        {
            string removedAccents = RemoveAccents(input);
            string upperCase = ConvertToUpperCase(removedAccents);
            return upperCase;
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
