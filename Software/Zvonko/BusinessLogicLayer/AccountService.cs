using DatabaseLayer.Repositories;
using EntitiesLayer;
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
    }
}
