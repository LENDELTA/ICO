using System;
using System.ComponentModel.DataAnnotations;

namespace GenesisVision.Core.ViewModels.Account
{
    public class TwoFactorAuthenticatorConfirm : PasswordModel
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public string SharedKey { get; set; }
    }
}
