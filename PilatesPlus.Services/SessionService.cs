﻿using PilatesPlus.Data;
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

        public bool CreateSession(SessionCreate model)
        {
            var entity =
                new Session()
                {
                    OwnerId = _userId,
                    ClientId = model.ClientId,
                    FirstName = model.Client.FirstName,
                    LastName = model.Client.LastName,
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
        public IEnumerable<SessionListItem> GetSessionsByClientId(int ClientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Sessions
                        .Where(e => e.ClientId == ClientId && e.OwnerId == _userId)
                        .Select(
                            e =>
                            new SessionListItem
                            {
                                ClientId = e.ClientId,
                                FirstName = e.FirstName,
                                LastName = e.LastName,              
                                SessionDate = e.SessionDate,
                                SessionNote = e.SessionNote,
                                IsDuet = e.IsDuet
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
                        ClientId = entity.ClientId,
                        FirstName = entity.Client.FirstName,
                        LastName = entity.LastName,
                        SessionDate = entity.SessionDate,
                        SessionNote = entity.SessionNote,
                        IsDuet = entity.IsDuet
                    };
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

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.SessionDate = model.SessionDate;
                entity.SessionNote = model.SessionNote;
                entity.IsDuet = model.IsDuet;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}