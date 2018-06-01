using GenesisVision.Core.ViewModels.Common;
using System.ComponentModel.DataAnnotations;

namespace GenesisVision.Core.ViewModels.Manager
{
    public class NewTournamentAccountRequest : HiddenUserId
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
    }
}
