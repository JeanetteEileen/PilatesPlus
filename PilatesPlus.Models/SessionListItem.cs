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
    public class SessionListItem
    {
        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }
        public virtual Client client { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Session Date")]
        public DateTime SessionDate { get; set; }
        [Display(Name ="Session Notes")]
        public string SessionNote { get; set; }
        public bool IsDuet { get; set; }
    }
}
