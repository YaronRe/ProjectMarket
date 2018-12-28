﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMarket.Models
{
    public class AcademicInstitute
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [Display(Name = "שם")]
        public string Name { get; set; }
    }
}
