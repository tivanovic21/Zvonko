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
            if (string.IsNullOrEmpty(password)) return "";
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        public bool ValidateInput(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) return false;
            else return true;
        }

        public bool ValidateRegistrationInput(string username, string password, string schoolName)
        {
            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(schoolName))
            {
                return false;
            }

            return true;
        }
    }
}
