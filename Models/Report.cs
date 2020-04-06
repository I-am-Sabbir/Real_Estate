﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Models
{
    public class Report
    {
        [Key]
        public int ID { get; set; }
        
        public Apartment Apartment { get; set; }

        public Buyer Buyer { get; set; }
    }
}
