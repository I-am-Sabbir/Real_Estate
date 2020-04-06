using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Models
{
    public class Apartment
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="Apartment name required")]
        [Display(Name ="Apartment Name")]
        public string Apartment_Name { get; set; }

        [Required(ErrorMessage ="Apartment location required.")]
        [Display(Name ="Apartment Location")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Apartment Size required.")]
        [Display(Name ="Apartment Size")]
        public string Size { get; set; }

        [Display(Name ="Details")]
        public string Details { get; set; }

        public int BuilderID { get; set; }
        public Builder Builder { get; set; }

        public ICollection<Report> Reports { get; set; }
        public ICollection<Requested> Requesteds { get; set; }
    }
}
