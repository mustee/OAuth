using System;
using Microsoft.AspNet.Identity;

namespace OAuth.Data.Models
{
    public class User : IUser
    {
        public long Id { get; }       

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        string IUser<string>.Id { get { return Id.ToString(); } }
       
    }
}
