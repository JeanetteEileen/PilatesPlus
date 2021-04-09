using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilatesPlus.Models
{
    public class ClientCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter a name of at least 2 characters.")]
        public string firstName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter a name of at least 2 characters.")]
        public string lastName { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string cellPhone { get; set; }
    }
}
