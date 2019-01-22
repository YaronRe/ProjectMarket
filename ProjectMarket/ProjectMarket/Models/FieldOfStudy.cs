using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMarket.Models
{
    public class FieldOfStudy
    {
        [Required(ErrorMessage = "שדה זה הוא חובה")]
        public int Id { get; set; }
        [Required(ErrorMessage = "שדה זה הוא חובה")]
        [MinLength(4,ErrorMessage ="שם תחום הלימוד חייב להיות באורך 4 תווים לפחות")]
        [MaxLength(20,ErrorMessage ="שם תחום הלימוד לא יכול לעלות על 20 תווים")]
        [Display(Name = "שם")]
        public string Name { get; set; }
    }
}
