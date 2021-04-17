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
        public bool CreateEquipment(EquipmentCreate model)
        {
            var entity = new Equipment()
            {
                OwnerId = _userId,
                EquipmentSessionId = model.EquipmentSessionId,
                ClientId = model.ClientId,
                Reformer = model.Reformer,
                Cadilac = model.Cadilac,
                LadderBarrel = model.LadderBarrel,
                MagicCircle = model.MagicCircle,
                PediPole = model.PediPole,
                ToeExerciser = model.ToeExerciser,
                SmallBarrel = model.SmallBarrel,
                ArmChair = model.ArmChair,
                SpineCorrector = model.SpineCorrector,
                WundaChair = model.WundaChair
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
                        ClientId = e.ClientId,
                        Reformer = e.Reformer,
                        Cadilac = e.Cadilac,
                        LadderBarrel = e.LadderBarrel,
                        MagicCircle = e.MagicCircle,
                        PediPole = e.PediPole,
                        ToeExerciser = e.ToeExerciser,
                        SmallBarrel = e.SmallBarrel,
                        ArmChair = e.ArmChair,
                        SpineCorrector = e.SpineCorrector,
                        WundaChair = e.WundaChair,
                        CreatedUtc = e.CreatedUtc,
                        ModifiedUtc = e.ModifiedUtc
                    });
                return query.ToArray();
            }
        }
    }
}
