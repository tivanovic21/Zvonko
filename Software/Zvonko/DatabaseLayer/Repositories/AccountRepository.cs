using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repositories
{
    public class AccountRepository: Repository<Account>
    {
        public AccountRepository(): base(new ZvonkoModel())
        {
            
        }

        public override int Add(Account newAccount, bool saveChanges = true)
        {
            var account = new Account
            {
                username = newAccount.username,
                password = newAccount.password,
                schoolName = newAccount.schoolName
            };
            Entities.Add(account);
            if (saveChanges)
            {
                return SaveChanges();
            } else return 0;
        }

        public Account Get(string username, string password) {
            var query = from e in Entities
                        where e.username == username && e.password == password
                        select e;

            return query.FirstOrDefault();  
        }
    }
}
