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
        [Required(ErrorMessage = "שדה זה הוא חובה")]
        [Range(0.0, 10000.0,ErrorMessage ="המחיר חייב להיות בין 0 ל10000")]
        public double Price { get; set; }
        [Range(1, 5,ErrorMessage ="הדירוג הוא בין 1 ל5")]
        [Display(Name = "דירוג")]
        public int? Rank { get; set; }
        [Range(0, 100,ErrorMessage ="ציון חייב להיות בין 0 ל100")]
        [Display(Name = "ציון")]
        public int? Grade { get; set; }
        [Display(Name = "קונה")]
        public User Buyer { get; set; }
        public int BuyerId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        [Display(Name = "מוסד אקדמי")]
        public AcademicInstitute AcademicInstitute { get; set; }
        public bool AcceptedBySeller { get; set; }
        public bool AcceptedByBuyer { get; set; }
        public int? AcademicInstituteId { get; internal set; }
    }
}
