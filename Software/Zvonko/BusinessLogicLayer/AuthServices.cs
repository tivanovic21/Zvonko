using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt;
using BCrypt.Net;

namespace BusinessLogicLayer
{
    public class AuthServices
    {
        public string HashPassword(string password, string salt) {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            if (hashedPassword.Length > 50) {
                hashedPassword = hashedPassword.Substring(0, 50);
            }
            return hashedPassword;
        }

        public string GenerateSalt()
        {
            string salt = "";
            //string salt = BCrypt.Net.BCrypt.GenerateSalt();
            return salt;
        }

        public bool ValidateInput(string username, string password, string schoolName = null)
        {
            if (schoolName == null)
            {
                if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(password) || !string.IsNullOrEmpty(schoolName)) return true;
            }else
            {
                if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(password)) return true;
            }
            return false;
        }
    }
}
