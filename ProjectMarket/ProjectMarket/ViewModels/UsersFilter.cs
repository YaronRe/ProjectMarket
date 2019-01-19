using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMarket.ViewModels
{
    public class UsersFilter
    {
        [MaxLength(20)]
        [RegularExpression(@"\w+")]
        [DisplayName("שם משתמש")]
        public string UserName { get; set; }

        [MaxLength(20)]
        [DisplayName("שם פרטי")]
        public string FirstName { get; set; }
        [MaxLength(20)]
        [DisplayName("שם משפחה")]
        public string LastName { get; set; }
        [Display(Name = "כלול משתמשים מחוקים")]
        public bool IncludeDeleted { get; set; }
    }
}
