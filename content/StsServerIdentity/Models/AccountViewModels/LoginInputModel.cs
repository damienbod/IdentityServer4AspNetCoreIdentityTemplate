using System.ComponentModel.DataAnnotations;

namespace StsServerIdentity.Models.AccountViewModels
{
    public class LoginInputModel
    {
        [Required(ErrorMessage = "EMAIL_REQUIRED")]
        [EmailAddress(ErrorMessage = "EMAIL_INVALID")]
        public string Username { get; set; } // TODO Rename to Email 
        [Required(ErrorMessage = "PASSWORD_REQUIRED")]
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
    }
}