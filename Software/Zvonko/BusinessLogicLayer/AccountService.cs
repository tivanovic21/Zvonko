﻿using DatabaseLayer;
using DatabaseLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class AccountService
    {   
        public bool AddAccount(Account newAccount)
        {
            using (var repo = new AccountRepository())
            {
                int affectedRows = repo.Add(newAccount, true);
                if (affectedRows > 0)
                {
                    return true;
                } else return false;
            }
        }

        public Account GetAccount(string username) {
            using (var repo = new AccountRepository()) {
                var account = repo.Get(username);
                if (account != null) return account;
                else return null;
            }
        }
    }
}
