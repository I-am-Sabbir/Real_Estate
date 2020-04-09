using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Models
{
    public class Buyer
    {
        public int userID { get; set; }
        
        public User User { get; set; }

        [Required(ErrorMessage ="Name required.")]
        [Display(Name ="Name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Phone Number required.")]
        [Display(Name ="Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage ="Address required.")]
        [Display(Name ="Address")]
        public string Address { get; set; }

        [Required(ErrorMessage ="Email required.")]
        [Display(Name ="Email")]
        public string Email { get; set; }

        public ICollection<Report> Reports { get; set; }
        public ICollection<Requested> Requesteds { get; set; }

    }
}
