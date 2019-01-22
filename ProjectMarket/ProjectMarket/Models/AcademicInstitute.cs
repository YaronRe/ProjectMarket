using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMarket.Models
{
    public class AcademicInstitute
    {
        [Required(ErrorMessage = "שדה זה הוא חובה")]
        public int Id { get; set; }
        [Required(ErrorMessage = "שדה זה הוא חובה")]
        [MinLength(3,ErrorMessage ="שם המוסד חייב להיות באורך 2 תווים לפחות")]
        [MaxLength(20,ErrorMessage ="שם המוסד לא יכול לעלות על 20 תווים")]
        [Display(Name = "שם")]
        public string Name { get; set; }
    }
}
