namespace LENDELTA.Core.Models
{
    public class NewWalletAddress
    {
        public string Address { get; set; }
        public string WalletId { get; set; }
        public string VerificationCode { get; set; }
        public string Currency { get; internal set; }
    }
}
