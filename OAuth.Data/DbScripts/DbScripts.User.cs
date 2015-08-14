namespace OAuth.Data.DbScripts
{
    public partial class DbScripts
    {
        public static class User
        {

            public static readonly string Insert = @"INSERT INTO [User](UserName, PasswordHash, SecurityStamp) OUTPUT INSERTED.Id
                                                VALUES(@UserName, @PasswordHash, @SecurityStamp)";

            public static readonly string Delete = @"DELETE FROM [User] WHERE Id = @Id  SELECT @@ROWCOUNT";

            public static readonly string Update = @"UPDATE [User] SET UserName = @UserName, PasswordHash = @PasswordHash, 
                                                SecurityStamp = @SecurityStamp WHERE Id = @Id  SELECT @@ROWCOUNT";

            public static readonly string Find = @"SELECT * FROM [User] WHERE Id = @Id";

            public static readonly string FindByUserName = @"SELECT * FROM [User] WHERE UserName = @UserName";

            public static readonly string FindByExternalLogin = @"SELECT u.* from [User] u INNER JOIN ExternalLogin l on l.UserId = u.UserId 
                                                where l.LoginProvider = @LoginProvider and l.ProviderKey = @ProviderKey";

        }
    }
}
