using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.DTO;
namespace MyLibrary
{
    public class Helpers
       
    {
        //List giờ khởi hành
        public static readonly List<string> Hours = new List<string>()
        {
            "00:00", "01:00", "02:00", "03:00", "04:00", "05:00", "06:00", "07:00",
            "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "14:00",
            "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00",
            "23:00"
        };
        //1k cho mỗi km
        public static readonly int PricePerKm = 1000;
        public static readonly List<Roles> roles = new List<Roles>()
        {
            new Roles(){RoleID=1, RoleName="Admin"},
            new Roles(){RoleID=2, RoleName="User"}
        };

        public static string EncryptSHA256(string plainText)
        {
            string res = "";
            using (SHA256 sha256 = SHA256.Create())
            {
                //Chuyển plaintText thành mảng Byte
                //Convert plaint text to a bytes array

                byte[] sourceData = Encoding.UTF8.GetBytes(plainText);
                byte[] hashRes = sha256.ComputeHash(sourceData);

                res = BitConverter.ToString(hashRes, 0, hashRes.Length).Replace("-", string.Empty);

                return res;
            }
        }
    }

}
