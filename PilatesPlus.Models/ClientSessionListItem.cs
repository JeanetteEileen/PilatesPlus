using PilatesPlus.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilatesPlus.Models
{
    public class ClientSessionListItem
    {
        [Required]
        public int ClientId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Session Id")]
        public int SessionId { get; set; }
        [Display(Name = "Session Date")]
        public DateTime SessionDate { get; set; }
        [Display(Name = "Session Note")]
        public string SessionNote { get; set; }
        [Display(Name ="Session Time")]
        public string SessionTime { get; set; }
        [Display(Name = "Is Duet")]
        public bool IsDuet { get; set; }
        [Display(Name = "Is Client Active?")]
        public bool ClientActive { get; set; }
        public DateTimeOffset? SessionDateModified { get; set; }
        public virtual List<Session> ClientSession { get; set; }

    }
}
