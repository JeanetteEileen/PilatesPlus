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
                SessionId = model.SessionId,
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
    }
}
