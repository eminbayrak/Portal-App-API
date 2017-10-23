using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;


namespace ParentPortalAPI.Models.Data
{
    public class ParentPortalApiContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public System.Data.Entity.DbSet<ParentPortalAPI.Models.Data.AuthToken> AuthTokens { get; set; }

        public ParentPortalApiContext()
        {
            Debug.Write(Database.Connection.ConnectionString);
        }
    }
}