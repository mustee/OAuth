namespace OAuth.Data.Models
{
    public class UserClaim
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string ClaimValue { get; set; }

        public string ClaimType { get; set; }

        public string Issuer { get; set; }

        public string OriginalIssuer { get; set; }
    }
}
