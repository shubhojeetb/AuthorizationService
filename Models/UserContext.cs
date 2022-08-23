using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationService.Models
{
    public class UserContext:DbContext
    {
        string connectionString = "Server=tcp:db-checklist.database.windows.net,1433;Initial Catalog=AuthorizationService;Persist Security Info=False;User ID=azureroot;Password=@12Shubho@12;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<User> Users { get; set; }
    }
}
