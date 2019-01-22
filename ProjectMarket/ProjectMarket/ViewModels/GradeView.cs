using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMarket.ViewModels
{
    public class GradeView
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Range(1, 5)]
        [Display(Name = "דירוג")]
        public int? Rank { get; set; }
        [Required]
        [Range(0, 100)]
        [Display(Name = "ציון")]
        public int? Grade { get; set; }
    }
}
