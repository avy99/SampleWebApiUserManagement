using System.ComponentModel.DataAnnotations;

namespace UserManagement.Model.Models
{
    public class User
    {
        [Key] [Required] [EmailAddress] public string Email { get; set; }

        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^\w\d\s:])([^\s]){8,}$",
            ErrorMessage =
                "The password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        [Required]
        public string Password { get; set; }

        [Required] public string Name { get; set; }

        public string Phone { get; set; }

        public Roles Role { get; set; }
    }

    public enum Roles
    {
        Admin,
        User
    }
}