using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.TestRepositories
{
    public interface IAccountRepository
    {
        Account Get(string username);

        void Dispose();
    }
}
