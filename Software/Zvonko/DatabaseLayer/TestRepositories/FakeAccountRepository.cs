using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.TestRepositories
{
    public class FakeAccountRepository : IAccountRepository
    {
        public Account AccountToReturn { get; set; }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Account Get(string username)
        {
            return AccountToReturn;
        }
    }
}
