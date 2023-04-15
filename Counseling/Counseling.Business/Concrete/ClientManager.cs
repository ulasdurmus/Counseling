using Counseling.Business.Abstract;
using Counseling.Data.Abstract;
using Counseling.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Business.Concrete
{
    public class ClientManager : IClientService
    {
        private IClientRepository _clientRepository;
        public ClientManager(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task CreateAsync(Client client)
        {
            await _clientRepository.CreateAsync(client);
        }

        public void Delete(Client client)
        {
            _clientRepository.Delete(client);
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await _clientRepository.GetAllAsync();
        }

        public async Task<Client> GetById(int id)
        {
            return await _clientRepository.GetByIdAsync(id);
        }

        public void Update(Client client)
        {
            _clientRepository.Update(client);
        }
    }
}
