using Recipe.Web.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Recipe.Web.Data
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        public UserType UserType { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        public int FailedLoginAttempts { get; set; }
        [Required]
        public bool IsLocked { get; set; }
        [Required]
        [MaxLength(100)]
        public string SecurityQuestion1 { get; set; }
        [Required]
        [MaxLength(100)]
        public string SecurityQuestion2 { get; set; }
        [Required]
        [MaxLength(100)]
        public string SecurityAnswer1 { get; set; }
        [Required]
        [MaxLength(100)]
        public string SecurityAnswer2 { get; set; }

    }
}
