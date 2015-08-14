namespace OAuth.Data.DbScripts
{
    public partial class DbScripts
    {
        public class UserClaim
        {
            public static readonly string Insert = @"INSERT INTO UserClaim (UserId, ClaimValue, ClaimType, Issuer, OriginalIssuer) OUTPUT INSERTED.Id
                                                VALUES (@UserId, @ClaimValue, @ClaimType, @Issuer, @OriginalIssuer)";

            public static readonly string Delete = @"DELETE FROM UserClaim WHERE Id = @Id  SELECT @@ROWCOUNT";

            public static readonly string Update = @"UPDATE UserClaim SET UserId = @UserId, ClaimValue = @ClaimValue, ClaimType = @ClaimType, 
                                                Issuer = @Issuer, OriginalIssuer = @OriginalIssuer WHERE Id = @Id  SELECT @@ROWCOUNT";

            public static readonly string Find = @"SELECT * FROM UserClaim WHERE Id = @Id";
        }
    }
}
