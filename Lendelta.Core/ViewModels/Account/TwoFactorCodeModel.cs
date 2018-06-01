using System.ComponentModel.DataAnnotations;

namespace GenesisVision.Core.ViewModels.Account
{
    public class TwoFactorCodeModel : PasswordModel
    {
        [Required]
        public string TwoFactorCode { get; set; }
    }
}
