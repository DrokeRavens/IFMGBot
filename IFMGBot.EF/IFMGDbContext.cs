using IFMGBot.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace IFMGBot.EF
{
    public class IFMGDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=DESKTOP-49JHNDE\SQLEXPRESS;Initial Catalog=IFMG;Integrated Security=True");
        }

        public DbSet<ContactInfo> Contatos { get; set; }
    }
}
