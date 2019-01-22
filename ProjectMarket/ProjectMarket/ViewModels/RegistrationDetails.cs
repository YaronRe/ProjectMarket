using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMarket.ViewModels
{
    public class RegistrationDetails
    {
        [Required(ErrorMessage = "שדה זה הוא חובה")]
        [MinLength(4, ErrorMessage = "שם משתמש חייב להיות 4 תווים ומעלה")]
        [MaxLength(20, ErrorMessage = "שם משתמש חייב להיות פחות מ20 תווים")]
        [RegularExpression(@"\w+", ErrorMessage = "שם משתמש חייב להיות מורכב רק צאותיות ומספרים")]
        [DisplayName("שם משתמש")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "שדה זה הוא חובה")]
        [MinLength(8, ErrorMessage = "סיסמה חייבת להיות באורך של 8 תווים לפחות")]
        [MaxLength(200, ErrorMessage = "סיסמה חייבת להיות פחות מ200 תווים")]
        [DataType(DataType.Password)]
        [DisplayName("סיסמה")]
        public string Password { get; set; }

        [MaxLength(20, ErrorMessage = "שם פרטי חייב להיות פחות מ20 תווים")]
        [DisplayName("שם פרטי")]
        public string FirstName { get; set; }

        [MaxLength(20, ErrorMessage = "שם משפחה חייב להיות פחות מ20 תווים")]
        [DisplayName("שם משפחה")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "שדה זה הוא חובה")]
        [EmailAddress(ErrorMessage = "אנא הכנס כתובת מייל לגיטימית")]
        [DisplayName("E-Mail")]
        public string EMail { get; set; }
    }
}
