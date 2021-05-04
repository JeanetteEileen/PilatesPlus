using PilatesPlus.Data;
using PilatesPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilatesPlus.Services
{
    public class EquipmentService
    {
        private readonly Guid _userId;
        public EquipmentService(Guid userId)
        {
            _userId = userId;
        }
        public IEnumerable<Session> GetSessionList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Sessions.Include("Client").OrderBy(s => s.SessionDate).ThenBy(s =>s.Client.LastName).ThenBy(s => s.Client.FirstName).ToList();
            }
        }
        public bool CreateEquipment(EquipmentCreate model)
        {
            var entity = new Equipment()
            {
                OwnerId = _userId,
                EquipmentSessionId = model.EquipmentSessionId,
                //ClientId = model.ClientId,
                Reformer = model.Reformer,
                Cadilac = model.Cadilac,
                LadderBarrel = model.LadderBarrel,
                MagicCircle = model.MagicCircle,
                PediPole = model.PediPole,
                ToeExerciser = model.ToeExerciser,
                SmallBarrel = model.SmallBarrel,
                ArmChair = model.ArmChair,
                SpineCorrector = model.SpineCorrector,
                WundaChair = model.WundaChair,
                CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Equipments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EquipmentListItem> GetEquipments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Equipments.Where(e => e.OwnerId == _userId)
                    .Select(e => new EquipmentListItem
                    {
                        EquipmentSessionId = e.EquipmentSessionId,
                        //ClientId = e.Session.ClientId,
                        Reformer = e.Reformer,
                        Cadilac = e.Cadilac,
                        Mat = e.Mat,
                        LadderBarrel = e.LadderBarrel,
                        MagicCircle = e.MagicCircle,
                        PediPole = e.PediPole,
                        ToeExerciser = e.ToeExerciser,
                        SmallBarrel = e.SmallBarrel,
                        ArmChair = e.ArmChair,
                        SpineCorrector = e.SpineCorrector,
                        WundaChair = e.WundaChair,
                        CreatedUtc = e.CreatedUtc,
                        EquipmentSessionModifiedDate = e.EquipmentSessionModifiedDate
                    });
                return query.ToArray();
            }
        }
        public EquipmentDetail GetEquipmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Equipments
                    .Single(e => e.EquipmentSessionId == id && e.OwnerId == _userId);
                return new EquipmentDetail
                {
                    EquipmentSessionId = entity.EquipmentSessionId,
                    //ClientId = entity.Session.ClientId,
                    Reformer = entity.Reformer,
                    Cadilac = entity.Cadilac,
                    Mat = entity.Mat,
                    LadderBarrel = entity.LadderBarrel,
                    PediPole = entity.PediPole,
                    MagicCircle = entity.MagicCircle,
                    SmallBarrel = entity.SmallBarrel,
                    ToeExerciser = entity.ToeExerciser,
                    ArmChair = entity.ArmChair,
                    SpineCorrector = entity.SpineCorrector,
                    WundaChair = entity.WundaChair,
                    CreatedUtc = entity.CreatedUtc,
                    EquipmentSessionModifiedDate = entity.EquipmentSessionModifiedDate
                };
            }
        }
        public bool UpdateEquipment(EquipmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Equipments
                        .Single(e => e.EquipmentSessionId == model.EquipmentSessionId && e.OwnerId == _userId);

                //entity.ClientId = model.ClientId;
                entity.Reformer = model.Reformer;
                entity.Cadilac = model.Cadilac;
                entity.Mat = model.Mat;
                entity.LadderBarrel = model.LadderBarrel;
                entity.PediPole = model.PediPole;
                entity.MagicCircle = model.MagicCircle;
                entity.SmallBarrel = model.SmallBarrel;
                entity.ToeExerciser = model.ToeExerciser;
                entity.ArmChair = model.ArmChair;
                entity.SpineCorrector = model.SpineCorrector;
                entity.WundaChair = model.WundaChair;
                entity.EquipmentSessionModifiedDate = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteEquipment(int equipmentSessionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                .Equipments
                .Single(e => e.EquipmentSessionId == equipmentSessionId && e.OwnerId == _userId);
                ctx.Equipments.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
            
        }
    }
}
