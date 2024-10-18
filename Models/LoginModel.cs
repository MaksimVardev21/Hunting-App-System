using System.ComponentModel.DataAnnotations;

namespace Hunting_App_System.Models {
    public class LoginModel
    {
        [Required] [EmailAddress] public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
