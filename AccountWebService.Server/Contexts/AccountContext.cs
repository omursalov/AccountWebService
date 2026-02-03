using AccountWebService.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountWebService.Server.Contexts
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public AccountContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Data/Account.db");
        }
    }
}