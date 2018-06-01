namespace GenesisVision.Core.ViewModels.Common
{
    public class PlatformStatus
    {
        public bool IsTournamentActive { get; set; }
        public bool IsTournamentRegistrationActive { get; set; }
        public int TournamentCurrentRound { get; set; }
        public int TournamentTotalRounds { get; set; }
        public decimal ProgramsMinAvgProfit { get; set; }
        public decimal ProgramsMaxAvgProfit { get; set; }
        public decimal ProgramsMinTotalProfit { get; set; }
        public decimal ProgramsMaxTotalProfit { get; set; }

        public IOsAppVersion iOSVersion { get; set; }
        public AndroidAppVersion AndroidVersion { get; set; }
    }

    public class AndroidAppVersion
    {
        public AndroidVersion MinVersion { get; set; }
        public AndroidVersion LastVersion { get; set; }
    }

    public class AndroidVersion
    {
        public string VersionCode { get; set; }
        public string VersionName { get; set; }
    }

    public class IOsAppVersion
    {
        public string MinVersion { get; set; }
        public string LastVersion { get; set; }
    }
}
