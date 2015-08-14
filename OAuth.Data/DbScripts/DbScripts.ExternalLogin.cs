namespace OAuth.Data.DbScripts
{
    public partial class DbScripts
    {
        public static class ExternalLogin
        {
            public static readonly string Insert = @"INSERT INTO ExternalLogin(UserId, LoginProvider, ProviderKey) OUTPUT INSERTED.Id
                                                VALUES(@UserId, @LoginProvider, @ProviderKey)";

            public static readonly string Delete = @"DELETE FROM ExternalLogin WHERE Id = @Id  SELECT @@ROWCOUNT";

            public static readonly string Update = @"UPDATE ExternalLogin SET UserId = @UserId, LoginProvider = @LoginProvider, 
                                                ProviderKey = @ProviderKey WHERE Id = @Id  SELECT @@ROWCOUNT";

            public static readonly string Find = @"SELECT * FROM ExternalLogin WHERE Id = @Id";

            public static readonly string FindLogins = @"SELECT LoginProvider, ProviderKey FROM ExternalLogin WHERE UserId = @UserId";

            public static readonly string DeleteLogin = @"DELETE FROM ExternalLogin WHERE UserId = @UserId AND LoginProvider = @LoginProvider AND ProviderKey = @ProviderKey   SELECT @@ROWCOUNT";
        }
    }
}
