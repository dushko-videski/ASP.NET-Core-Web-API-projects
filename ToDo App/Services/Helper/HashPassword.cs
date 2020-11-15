using System.Security.Cryptography;
using System.Text;

namespace Services.Helper
{
    public static class HashPassword
    {
        public static string HashPass(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Encoding.ASCII.GetString(md5data);
        }



    }
}
