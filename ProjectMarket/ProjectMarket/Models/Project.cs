using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace ProjectMarket.Models
{
    public class Project
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        [Display(Name = "שם")]
        public string Name { get; set; }

        [MaxLength(300)]
        [Display(Name = "תאור")]
        public string Description { get; set; }

        public int FieldOfStudyId { get; set; }
        [Display(Name = "תחום")]
        public FieldOfStudy FieldOfStudy { get; set; }

        public int AcademicInstituteId { get; set; }
        [Display(Name ="מוסד אקדמי")]
        public AcademicInstitute AcademicInstitute { get; set; }
        
        [Display(Name = "מחיר")]
        public double Price { get; set; }

        public User Owner { get; set; }
        public int OwnerId { get; set; }

        public double LocationLongitude { get; set; }
        public double LocationLatitude { get; set; }
        [MaxLength(300)]
        [Display(Name = "כתובת לברורים")]
        public string Address { get; set; }

    }
}
