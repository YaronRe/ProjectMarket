using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace ProjectMarket.Models
{
    public class Project
    {
        [Required(ErrorMessage = "שדה זה הוא חובה")]
        public int Id { get; set; }

        [Required(ErrorMessage = "שדה זה הוא חובה")]
        [MinLength(4,ErrorMessage ="שם הפרויקט לא חייב להיות באורך 4 תווים לפחות")]
        [MaxLength(50,ErrorMessage ="שם הפרויקט לא יכול לעלות על 50 תווים")]
        [Display(Name = "שם")]
        public string Name { get; set; }

        [MaxLength(300,ErrorMessage ="תיאור הפרויקט לא יכול לעלות על 300 תווים")]
        [Display(Name = "תאור")]
        public string Description { get; set; }

        public int FieldOfStudyId { get; set; }
        [Display(Name = "תחום")]
        public FieldOfStudy FieldOfStudy { get; set; }

        public int AcademicInstituteId { get; set; }
        [Display(Name ="מוסד אקדמי")]
        public AcademicInstitute AcademicInstitute { get; set; }

        [Required(ErrorMessage = "שדה זה הוא חובה")]
        [Range(0.0, 10000.0, ErrorMessage = "המחיר חייב להיות בין 0 ל10000")]
        [Display(Name = "מחיר")]
        public double Price { get; set; }

        public int OwnerId { get; set; }
        public User Owner { get; set; }

        [MaxLength(300,ErrorMessage ="אורך כתובת לבירורים לא יכול לעלות על 300 תווים")]
        [Display(Name = "כתובת לברורים")]
        public string Address { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

    }
}
