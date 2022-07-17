using Microsoft.EntityFrameworkCore;
using ScadaProject.Models;

namespace ScadaProject.Data
{
    public class ApplicationDbContext : DbContext
    {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
            }
            //what ever model you want to create inside the database, you will have to create a DB set inside the application DB context
            public DbSet<Account> Accounts { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<ass> Ass { get; set; }

            public DbSet<SettingCaSanXuat> SettingCaSanXuats { get; set; }
            public DbSet<SettingPLC> SettingPLCs { get; set; }

            public DbSet<SetGeneralInformation> SetGeneralInformations { get; set; }
    }
}
