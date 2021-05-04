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
        public SessionDay DayOfSession { get; set; }
        [Display(Name ="Is Session Duet")]
        public bool IsDuet { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? SessionDateModified { get; set; }
        public virtual Equipment EquipmentSession { get; set; }
    }
    public enum SessionDay
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday   
    }
    //public enum SessionTime
    //{
    //    [Display(Name ="8:00")]
    //    Eight,
    //    [Display(Name ="8:30")]
    //    EightThirty,
    //    [Display(Name = "9:00")]
    //    Nine,
    //    [Display(Name = "9:30")]
    //    NineThirty,
    //    [Display(Name ="10:00")]
    //    Ten,
    //    [Display(Name = "10:30")]
    //    TenThirty,
    //    [Display(Name = "11:00")]
    //    Eleven,
    //    [Display(Name = "11:30")]
    //    ElevenThirty,
    //    [Display(Name ="12:00")]
    //    Noon,
    //    [Display(Name = "12:30")]
    //    TwelveThirty,
    //    [Display(Name ="1:00")]
    //    One,
    //    [Display(Name ="1:30")]
    //    OneThirty,
    //    [Display(Name = "2:00")]
    //    Two,
    //    [Display(Name = "2:30")]
    //    TwoThirty,
    //    [Display(Name = "3:00")]
    //    Three,
    //    [Display(Name = "3:30")]
    //    ThreeThirty,
    //    [Display(Name = "4:00")]
    //    Four,
    //    [Display(Name = "4:30")]
    //    FourThirty
    //}
}
