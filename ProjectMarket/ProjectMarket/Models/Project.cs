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
        public string Name { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        public FieldOfStudy FieldOfStudy { get; set; }

        public AcademicInstitute AcademicInstitute { get; set; }
    }
}
