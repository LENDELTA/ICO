namespace GenesisVision.Core.ViewModels.Investment
{
    public interface ITournament
    {
        bool IsTournament { get; set; }
        int? RoundNumber { get; set; }
        int? Place { get; set; }
    }
}