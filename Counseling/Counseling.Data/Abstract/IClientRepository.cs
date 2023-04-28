using Counseling.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Data.Abstract
{
    public interface IClientRepository : IGenericRepository<Client>
    {
        public Task<Client> GetClientByUserName(string userName);
    }
}
