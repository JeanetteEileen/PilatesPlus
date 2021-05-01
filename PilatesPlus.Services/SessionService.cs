using PilatesPlus.Data;
using PilatesPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilatesPlus.Services
{
    public class SessionService
    {
        private readonly Guid _userId;
        public SessionService(Guid userId)
        {
            _userId = userId;
        }
        public IEnumerable<Client> GetClientList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Clients.OrderBy(e => e.LastName)
                    .ThenBy(e => e.FirstName).ToList();
            }
        
        }
        public bool CreateSession(SessionCreate model)
        {
            var entity =
                new Session()
                {
                    OwnerId = _userId,
                    ClientId = model.ClientId,
                    //FirstName = model.FirstName,
                    //LastName = model.LastName,
                    SessionDate = model.SessionDate,
                    SessionNote = model.SessionNote,
                    IsDuet = model.IsDuet
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Sessions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<SessionListItem> GetSessions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Sessions
                        .Where(e => e.OwnerId == _userId)
                        .OrderBy(e => e.ClientId).ThenBy(e => e.SessionId)
                        .Select(
                            e =>
                            new SessionListItem
                            {
                                SessionId = e.SessionId,
                                ClientId = e.ClientId,
                                FirstName = e.Client.FirstName,
                                LastName = e.Client.LastName,
                                SessionDate = e.SessionDate,
                                SessionNote = e.SessionNote,
                                IsDuet = e.IsDuet,
                                SessionDateModified = e.SessionDateModified
                            }

                        );
                return query.ToArray();

            }
        }
        public SessionDetail GetSessionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sessions
                        .Single(e => e.SessionId == id && e.OwnerId == _userId);

                return
                   new SessionDetail
                   {
                       SessionId = entity.SessionId,
                       ClientId = entity.ClientId,
                       FirstName = entity.Client.FirstName,
                       LastName = entity.Client.LastName,
                       SessionDate = entity.SessionDate,
                       SessionNote = entity.SessionNote,
                       IsDuet = entity.IsDuet,
                       SessionDateModified = entity.SessionDateModified
                   };
            }
        }
        public IEnumerable<SessionListItem> GetSessionsByClientId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Sessions
                       .Where(e => e.ClientId == id && e.OwnerId == _userId)
                       .OrderBy(e => e.SessionId).ThenBy(e => e.SessionDate)
                       .Select(e =>
               new SessionListItem
               {
                   SessionId = e.SessionId,
                   ClientId = e.ClientId,
                   FirstName = e.Client.FirstName,
                   LastName = e.Client.LastName,
                   SessionDate = e.SessionDate,
                   SessionNote = e.SessionNote,
                   IsDuet = e.IsDuet,
                   SessionDateModified = e.SessionDateModified
               }
               );
                return query.ToArray();
            }
        }
        public bool UpdateSession(SessionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sessions
                        .Single(e => e.SessionId == model.SessionId && e.OwnerId == _userId);

                entity.ClientId = model.ClientId;
                //entity.Client.FirstName = model.FirstName;
                //entity.Client.LastName = model.LastName;
                entity.SessionDate = model.SessionDate;
                entity.SessionNote = model.SessionNote;
                entity.IsDuet = model.IsDuet;
                entity.SessionDateModified = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteSession(int sessionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sessions
                        .Single(e => e.SessionId == sessionId && e.OwnerId == _userId);

                ctx.Sessions.Remove(entity);

                return ctx.SaveChanges() == 1;

            }

        }
    }
}
