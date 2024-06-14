using DatabaseLayer;
using DatabaseLayer.Repositories;
using DatabaseLayer.TestRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class AccountService
    {
        private IAccountRepository repo;
        public AccountService(IAccountRepository repository)
        {       
           repo = repository;
        }
        public bool AddAccount(Account newAccount)
        {
            if (newAccount == null) return false;
            else if (newAccount.username == null || newAccount.password == null || newAccount.schoolName == null) return false;

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
            var user = repo.Get(username);
            return user;
            /*using (var repo = new AccountRepository()) {
                var account = repo.Get(username);
                if (account != null) return account;
                else return null;
            }*/
        }
    }
}
