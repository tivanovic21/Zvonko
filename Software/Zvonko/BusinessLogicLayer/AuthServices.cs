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
        public string HashPassword(string password) {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedPassword;
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            bool passwordMatch = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            return passwordMatch;
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
