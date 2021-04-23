using PilatesPlus.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilatesPlus.Models
{
    public class ClientSessionEquipmentListItem
    {   
        [Key]
        public int ClientId { get; set; }
        public int SessionId { get; set; }
        [Display(Name = "Session Date")]
        public DateTime SessionDate { get; set; }
        [Display(Name = "Session Notes")]
        public string SessionNote { get; set; }
        [Display(Name = "Is seesion a duet")]
        public bool IsDuet { get; set; }
        public bool Reformer { get; set; }
        public bool Cadilac { get; set; }
        public bool Mat { get; set; }
        [Display(Name = "Ladder Barrel")]
        public bool LadderBarrel { get; set; }
        public bool PediPole { get; set; }
        [Display(Name = "Magic Circle")]
        public bool MagicCircle { get; set; }
        [Display(Name = "Small Barrel")]
        public bool SmallBarrel { get; set; }
        [Display(Name = "Toe Exerciser")]
        public bool ToeExerciser { get; set; }
        [Display(Name = "Arm Chair")]
        public bool ArmChair { get; set; }
        [Display(Name = "Spine Corrector")]
        public bool SpineCorrector { get; set; }
        [Display(Name = "Wunda Chair")]
        public bool WundaChair { get; set; }
        [Display(Name = "Equipment created")]
        public DateTimeOffset CreatedUtc { get; set; }
        public virtual List<Session> ClientSession { get; set; }
        public virtual List<Equipment> CSEquipment { get; set; }
    }
}
