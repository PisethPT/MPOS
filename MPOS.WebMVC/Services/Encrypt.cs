using System;
using System.Security.Cryptography;

namespace Iu_App_Lecturer.Static
{
	public static class Encrypt
	{
        public static string Encrypts(string Values)
        {
            try
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(Values);
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] keys = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes("IUIT.com.kh"));
                TripleDESCryptoServiceProvider tDESalg = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };
                ICryptoTransform transFrom = tDESalg.CreateEncryptor();
                byte[] resulte = transFrom.TransformFinalBlock(data, 0, data.Length);
                return Convert.ToBase64String(resulte, 0, resulte.Length);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
