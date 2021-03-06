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
    public class SessionDetail
    {
        [Key]
        public int SessionId { get; set; }
        [ForeignKey("Client")]
        [Display(Name ="Client Id")]
        public int ClientId { get; set; }
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Display(Name ="Session Date")]
        public DateTime SessionDate { get; set; }
        [Display(Name ="Day of Week")]
        public SessionDay DayOfSession { get; set; }
        [Display(Name ="Session Notes")]
        public string SessionNote { get; set; }
        [Display(Name ="Is Duet")]
        public bool IsDuet { get; set; }
        public DateTimeOffset? SessionDateModified { get; set; }
    }
}
