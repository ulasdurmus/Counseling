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
        public Task<List<Client>> GetAllClientsWithUserInformationsAsync();
        public Task<int> GetClientIdByUserNameAsync(string userName);
    }
}
