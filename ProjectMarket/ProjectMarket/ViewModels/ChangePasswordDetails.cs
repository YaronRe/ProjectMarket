using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMarket.ViewModels
{
    public class ChangePasswordDetails
    {
        [Required]
        [MinLength(8)]
        [MaxLength(200)]
        [DataType(DataType.Password)]
        [DisplayName("סיסמה נוכחית")]
        public string Password { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(200)]
        [DataType(DataType.Password)]
        [DisplayName("סיסמה חדשה")]
        public string NewPassword { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(200)]
        [DataType(DataType.Password)]
        [DisplayName("חזור על הסיסמה")]
        public string ReNewPassword { get; set; }

    }
}
