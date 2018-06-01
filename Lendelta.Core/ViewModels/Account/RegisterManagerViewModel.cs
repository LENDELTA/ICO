using System.ComponentModel.DataAnnotations;

namespace GenesisVision.Core.ViewModels.Account
{
    public class RegisterManagerViewModel : RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }
    }
}
