using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMarket.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        [RegularExpression(@"\w+")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string EMail { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

    }
}
