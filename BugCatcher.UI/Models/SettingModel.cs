using System.ComponentModel.DataAnnotations;

namespace BugCatcher.UI.Models
{
    public class SettingModel
    {
        [Required]
        public string Username { get; set; }
        [Required,UIHint("Password")]
        public string Password { get; set; }
        [Required, UIHint("Email")]
        public string Email { get; set; }
    }
}
