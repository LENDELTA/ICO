using System.ComponentModel.DataAnnotations;

namespace GenesisVision.Core.ViewModels.Account
{
    public class PasswordModel
    {
        [Required]
        public string Password { get; set; }
    }
}
