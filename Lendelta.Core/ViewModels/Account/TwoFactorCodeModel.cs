using System.ComponentModel.DataAnnotations;

namespace LENDELTA.Core.ViewModels.Account
{
    public class TwoFactorCodeModel : PasswordModel
    {
        [Required]
        public string TwoFactorCode { get; set; }
    }
}
