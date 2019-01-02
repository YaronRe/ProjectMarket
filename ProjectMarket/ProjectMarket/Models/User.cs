using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace ProjectMarket.Models
{
    public class User
    {
        private string _password;

        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
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

        [DisplayName("שם")]
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [MinLength(8)]
        [MaxLength(200)]
        [DisplayName("Password")]
        public string Password {
            get => _password;
            set => _password = HashPassword(value);
        }

        [Required]
        [EmailAddress]
        [DisplayName("E-Mail")]
        public string EMail { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        public User Login(ProjectMarketContext context)
        {
            var matchingUsers = context.User.Where(user => user.UserName == UserName && user.Password == Password).ToArray();
            if (matchingUsers.Length == 1)
            {
                return matchingUsers[0];
            }
            return null;
        }

        private static string HashPassword(string password)
        {
            // TODO implement
            return password;
        }
    }
}
