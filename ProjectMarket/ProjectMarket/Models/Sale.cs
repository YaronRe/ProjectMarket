using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace ProjectMarket.Models
{
    public class Sale
    {
        public int Id { get; set; }
        [Range(0.0, 10000.0)]
        public double Price { get; set; }
        [Range(0, 100)]
        [Display(Name ="ציון")]
        public int ProjectsGrade { get; set; }
        [Range(1, 5)]
        [Display(Name = "דירוג")]
        public int Rank { get; set; }
        [Range(0, 100)]
        [Display(Name = "ציון")]
        public int Grade { get; set; }
        [Display(Name = "קונה")]
        public User Buyer { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        [Display(Name = "מוסד אקדמי")]
        public AcademicInstitute AcademicInstitute { get; set; }
        public Meeting Meeting { get; set; }
        public bool AcceptedBySeller { get; set; }
        public bool AcceptedByBuyer { get; set; }
    }
}
