using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GiftManagerWebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        [Required]
        public string Role  { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }

    }
}