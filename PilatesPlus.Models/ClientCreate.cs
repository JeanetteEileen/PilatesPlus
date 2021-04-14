using DataAnnotationsExtensions;
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
        [Display(Name = "Client First Name")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter a name of at least 2 characters.")]
        [Display(Name = "Client Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "The email address is required.")]
        [DataType(DataType.EmailAddress)]
        [Email(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
        [Display(Name = "Cell Phone")]
        [Required(ErrorMessage = "Please enter a valid cell phone number.")]
        [DataType(DataType.PhoneNumber)]
        public string CellPhone { get; set; }
        public bool ClientActive { get; set; }
    }
}
