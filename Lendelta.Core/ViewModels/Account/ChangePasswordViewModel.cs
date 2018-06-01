using System.ComponentModel.DataAnnotations;

namespace GenesisVision.Core.ViewModels.Account
{
    public class ChangePasswordViewModel
    {
        [Required]
        public string OldPassword { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
