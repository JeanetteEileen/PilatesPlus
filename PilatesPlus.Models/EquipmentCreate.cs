using PilatesPlus.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilatesPlus.Models
{
    public class EquipmentCreate
    {
        [ForeignKey(nameof(Session))]
        public int EquipmentSessionId { get; set; }
        public virtual Session Session { get; set; }
        //[ForeignKey(nameof(Client))]
        //public int ClientId { get; set; }
        //public virtual Client Client { get; set; }
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
    }
}
