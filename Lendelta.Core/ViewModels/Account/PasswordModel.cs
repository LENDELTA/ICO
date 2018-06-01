using System.ComponentModel.DataAnnotations;

namespace LENDELTA.Core.ViewModels.Account
{
    public class PasswordModel
    {
        [Required]
        public string Password { get; set; }
    }
}
