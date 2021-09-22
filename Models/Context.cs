using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = localhost; database = UserDb; integrated security = true;");
        }
        public DbSet<Dashboard> Users { get; set; }
        public DbSet<LoginAccounts> LoginAccounts { get; set; }
    }
}
