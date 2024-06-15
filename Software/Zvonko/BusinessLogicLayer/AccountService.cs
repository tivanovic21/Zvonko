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
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public bool AddAccount(Account newAccount)
        {
            if (newAccount == null || newAccount.username == null || newAccount.password == null || newAccount.schoolName == null)
                return false;

            int affectedRows = _accountRepository.Add(newAccount, true);
            return affectedRows > 0;
        }

        public Account GetAccount(string username)
        {
            return _accountRepository.Get(username);
        }
    }
}
