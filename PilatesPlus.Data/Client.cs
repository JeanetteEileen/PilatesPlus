using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilatesPlus.Data
{
    public class Client
    {
        [Key]
        public int clientId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string cellPhone { get; set; }
        [Required]
        public DateTimeOffset createdUtc { get; set; }
        public DateTimeOffset modifiedUtc { get; set; }

    }
}
