using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilatesPlus.Models
{
    public class ClientListItem
    {
        [Required]
        public int ClientId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }
        [Display(Name = "Is Duet")]
        public bool IsDuet { get; set; }
        [Display(Name = "Is Client Active?")]
        public bool ClientActive { get; set; }
        [Display(Name ="Date Client Added")]
        public DateTimeOffset CreatedUtc { get; set; }
        
       
    }
}
