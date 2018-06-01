using System.ComponentModel.DataAnnotations;

namespace GenesisVision.Core.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        public string Email { get; set; }
    }
}
