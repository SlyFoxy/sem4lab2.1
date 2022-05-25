using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem4lab2._1
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CreditCard> CreditCards{ get; set; }
        public DbSet<Account> Accounts{ get; set; }
        public ApplicationContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=oopr_bank;Trusted_Connection=True;");
        }
    }
}
