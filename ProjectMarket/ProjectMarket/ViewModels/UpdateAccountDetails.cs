using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMarket.ViewModels
{
    public class UpdateAccountDetails
    {
        [MaxLength(20, ErrorMessage = "שם פרטי חייב להיות פחות מ20 תווים")]
        [DisplayName("שם פרטי")]
        public string FirstName { get; set; }
        [MaxLength(20, ErrorMessage = "שם משפחה חייב להיות פחות מ20 תווים")]
        [DisplayName("שם משפחה")]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "אנא הכנס כתובת מייל לגיטימית")]
        [DisplayName("E-Mail")]
        public string EMail { get; set; }
    }
}
