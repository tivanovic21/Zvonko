﻿using System;
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
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
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
