using System.ComponentModel.DataAnnotations;

namespace PriceUploadAPI.ViewModels.Users
{
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
