using System.ComponentModel.DataAnnotations;

namespace LENDELTA.Core.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        public string Email { get; set; }
    }
}
