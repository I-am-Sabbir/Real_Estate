using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Models
{
    public class Builder
    { 
        [Key]
        public int UserID { get; set; }
        public User User { get; set; }

        [Required(ErrorMessage ="Company Name required.")]
        [Display(Name ="Company Name")]
        public string Company_Name { get; set; }

        [Required(ErrorMessage ="Company location required.")]
        [Display(Name ="Company Location")]
        public string Location { get; set; }

        [Required(ErrorMessage ="Concact required.")]
        [Display(Name ="Office Contact")]
        public string Contact { get; set; }

        [Required(ErrorMessage ="Email required.")]
        [Display(Name ="Email")]
        public string Email { get; set; }

        public ICollection<Apartment> Apartments { get; set; }
    }
}
