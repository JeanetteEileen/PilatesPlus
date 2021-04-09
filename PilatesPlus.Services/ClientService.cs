using PilatesPlus.Models;
using PilatesPlus.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilatesPlus.Services
{
    public class ClientService
    {
        private readonly Guid _userId;
        public ClientService(Guid _userId)
        {
            _userId = _userId;
        }
        public bool CreateClient(ClientCreate model)
        {
            var entity =
                new Client()
                {
                    OwnerId = _userId,
                    firstName = model.firstName,
                    lastName = model.lastName,
                    email = model.email,
                    cellPhone = model.cellPhone,
                    createdUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Clients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        
    }
}
