﻿using Counseling.Data.Abstract;
using Counseling.Data.Concrete.Context;
using Counseling.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Data.Concrete.EfCoreRepositories
{
    public class EfCoreClientRepository : EfCoreGenericrepository<Client>, IClientRepository
    {
        public EfCoreClientRepository(CounselingContext _appContext) : base(_appContext)
        {
        }
        CounselingContext AppContext
        {
            get { return _dbContext as CounselingContext; }
        }
        public async Task<Client> GetClientByUserName(string userName)
        {
            Client client = await AppContext
                .Clients
                .Where(c => c.User.UserName == userName)
                .FirstOrDefaultAsync();
            return client;
        }
        public async Task<List<Client>> GetAllClientsWithUserInformationsAsync()
        {
            List<Client> clients = await AppContext
                .Clients
                .Include(x=> x.User)
                .ToListAsync();
            return clients;
        }
        public async Task<int> GetClientIdByUserNameAsync(string userName)
        {
            int id = await AppContext
                .Clients
                .Where(t => t.User.UserName == userName)
                .Select(t => t.Id).FirstOrDefaultAsync();
            return id;
        }
    }
}
