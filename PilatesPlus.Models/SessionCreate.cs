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
    public class SessionCreate
    {
        [Key]
        public int SessionId { get; set; }
        [Required]
        [ForeignKey(nameof(Client))]
        [Display(Name = "Client Name")]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        //[Required]
        //[Display(Name ="Client First Name")]
        //public string FirstName { get; set; }
        //[Required]
        //[Display(Name = "Client Last Name")]
        //public string LastName { get; set; }
        [Required]
        [Display(Name = "Session Comments")]
        public string SessionNote { get; set; }
        [Display(Name ="Is session duet?")]
        public bool IsDuet { get; set; }
        [Required]
        [Display(Name = "Session Date")]
        public DateTime SessionDate { get; set; }
    }
}
