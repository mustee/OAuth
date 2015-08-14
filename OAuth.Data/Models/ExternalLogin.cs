namespace OAuth.Data.Models
{
    public class ExternalLogin
    {

        public long Id { get; set; }

        public long UserId { get; set; }

        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
}
