using System.ComponentModel.DataAnnotations;

namespace LENDELTA.Core.ViewModels.Account
{
    public class RegisterManagerViewModel : RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }
    }
}
