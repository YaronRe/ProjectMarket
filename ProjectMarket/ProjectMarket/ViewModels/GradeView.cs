using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMarket.ViewModels
{
    public class GradeView
    {
        [Required(ErrorMessage = "שדה זה הוא חובה")]
        public int Id { get; set; }
        [Required(ErrorMessage = "שדה זה הוא חובה")]
        [Range(1, 5,ErrorMessage ="הדירוג חייב להיות בין 1 ל5")]
        [Display(Name = "דירוג")]
        public int Rank { get; set; }
        [Required(ErrorMessage = "שדה זה הוא חובה")]
        [Range(0, 100,ErrorMessage ="ציון חייב להיות בין 0 ל100")]
        [Display(Name = "ציון")]
        public int Grade { get; set; }
    }
}
