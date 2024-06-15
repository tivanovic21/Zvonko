using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.TestRepositories
{
    public interface IAccountRepository
    {
        int Add(Account account, bool saveChanges);
        Account Get(string username);
        int Update(Account entity, bool saveChanges = true);
    }
}
