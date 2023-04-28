using Counseling.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Business.Abstract
{
    public interface IClientService
    {
        Task CreateAsync(Client client);
        Task<Client> GetById(int id);
        Task<List<Client>> GetAllAsync();
        void Update(Client client);
        void Delete(Client client);
        public Task<Client> GetClientByUserName(string userName);


    }
}
