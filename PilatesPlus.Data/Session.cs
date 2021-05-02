using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilatesPlus.Data
{
    public class Session
    {
        [Key]
        public int SessionId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        //[Display(Name ="First Name")]
        //[Required]
        //public string FirstName { get; set; }
        //[Display(Name = "Last Name")]
        //[Required]
        //public string LastName { get; set; }
        [Display(Name = "Session Comments")]
        [Required]
        public string SessionNote { get; set; }
        [Display(Name = "Session Date")]
        public DateTime SessionDate { get; set; }
        //[Display(Name = "Time")]
        //public string SessionTime { get; set; }
        [Display(Name ="Is Session Duet")]
        public bool IsDuet { get; set; }
        [Display(Name = "Date Session Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Date Session Modified")]
        public DateTimeOffset? SessionDateModified { get; set; }
        public virtual Equipment EquipmentSession { get; set; }

    }
}
