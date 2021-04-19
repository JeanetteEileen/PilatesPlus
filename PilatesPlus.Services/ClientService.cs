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
        public ClientService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateClient(ClientCreate model)
        {
            var entity =
                new Client()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    CellPhone = model.CellPhone,
                    CreatedUtc = DateTimeOffset.Now,
                    ClientActive = model.ClientActive
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Clients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ClientListItem> GetClients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Clients
                        .Where(e => e.OwnerId == _userId)
                        .OrderBy(e => e.LastName).ThenBy(e => e.FirstName)
                        .Select(
                            e =>
                            new ClientListItem
                            {
                                ClientId = e.ClientId,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                Email = e.Email,
                                CellPhone = e.CellPhone,
                                ClientActive = e.ClientActive,
                                CreatedUtc = e.CreatedUtc
                            }                          
                        );
                return query.ToArray();
            }
        }
        public ClientDetail GetClientById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Clients
                        .Single(e => e.ClientId == id && e.OwnerId == _userId);
                return
                    new ClientDetail
                    {
                        ClientId = entity.ClientId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Email = entity.Email,
                        CellPhone = entity.CellPhone,
                        ClientActive = entity.ClientActive,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateClient(ClientEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Clients
                        .Single(e => e.ClientId == model.ClientId && e.OwnerId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Email = model.Email;
                entity.CellPhone = model.CellPhone;
                entity.ClientActive = model.ClientActive;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }public bool DeleteClient(int clientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Clients
                        .Single(e => e.ClientId == clientId && e.OwnerId == _userId);

                ctx.Clients.Remove(entity);

                return ctx.SaveChanges() == 1;

            }

        }
    }
}
