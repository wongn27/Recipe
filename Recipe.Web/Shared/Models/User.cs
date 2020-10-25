using Recipe.Web.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Recipe.Web.Data.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        public UserType UserType { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
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
        public byte[] ProfilePicture { get; set; }
        [Required (ErrorMessage = "First name is required")]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(30)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string Bio { get; set; }
    }
}
