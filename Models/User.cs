using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="User Name required.")]
        [Display(Name ="User Name")]
        public string user_name { get; set; }

        [Required(ErrorMessage ="Password required.")]
        [Display(Name ="Password")]
        public string Password { get; set; }

        [Required(ErrorMessage ="User Type required.")]
        [Display(Name ="User Type")]
        public string Type { get; set; }
       
    }

}
