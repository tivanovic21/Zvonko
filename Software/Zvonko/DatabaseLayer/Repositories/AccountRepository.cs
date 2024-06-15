using DatabaseLayer.TestRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repositories
{
    public class AccountRepository: Repository<Account>, IAccountRepository
    {
        public AccountRepository(): base(new ZvonkoModel9())
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

        public Account Get(string username) {
            var query = from e in Entities
                        where e.username == username
                        select e;

            return query.FirstOrDefault();  
        }

        public override int Update(Account entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
