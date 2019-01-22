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
        [MaxLength(20, ErrorMessage = "שם משתמש חייב להיות פחות מ20 תווים")]
        [RegularExpression(@"\w+", ErrorMessage = "שם משתמש חייב להיות מורכב רק צאותיות ומספרים")]
        [DisplayName("שם משתמש")]
        public string UserName { get; set; }

        [MaxLength(20, ErrorMessage = "שם פרטי חייב להיות פחות מ20 תווים")]
        [DisplayName("שם פרטי")]
        public string FirstName { get; set; }
        [MaxLength(20, ErrorMessage = "שם משפחה חייב להיות פחות מ20 תווים")]
        [DisplayName("שם משפחה")]
        public string LastName { get; set; }
        [Display(Name = "כלול משתמשים מחוקים")]
        public bool IncludeDeleted { get; set; }
    }
}
