using System.ComponentModel.DataAnnotations;

namespace BugCatcher.UI.Models.User
{
    public class LoginModel
    {
        [Required]
        [UIHint("Email")]
        public string Email { get; set; }

        [Required]
        [UIHint("Password")]
        public string Password { get; set; }
    }
}
