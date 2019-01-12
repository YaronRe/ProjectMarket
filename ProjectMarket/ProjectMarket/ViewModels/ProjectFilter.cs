using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMarket.ViewModels
{
    public class ProjectFilter
    {
        [MaxLength(50)]
        [Display(Name = "שם")]
        public string Name { get; set; }
        [Display(Name = "מחיר מינימום")]
        public double? MinPrice { get; set; }
        [Display(Name = "מחיר מקסימום")]
        public double? MaxPrice { get; set; }
        [Display(Name = "תחום לימודים")]
        public int? FieldOfStudyId { get; set; }
        [Display(Name = "כלול פרויקטים מחוקים")]
        public bool? IsDeleted { get; set; }
    }
}
