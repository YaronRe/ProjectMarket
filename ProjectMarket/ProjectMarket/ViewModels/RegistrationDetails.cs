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
        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        [RegularExpression(@"\w+")]
        [DisplayName("שם משתמש")]
        public string UserName { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(200)]
        [DataType(DataType.Password)]
        [DisplayName("סיסמה")]
        public string Password { get; set; }

        [MaxLength(20)]
        [DisplayName("שם פרטי")]
        public string FirstName { get; set; }

        [MaxLength(20)]
        [DisplayName("שם משפחה")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("E-Mail")]
        public string EMail { get; set; }
    }
}
