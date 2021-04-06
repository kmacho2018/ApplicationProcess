using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Data.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Employee Table
            modelBuilder.Entity<Asset>().HasData(new Asset
            {
                Id = 1,
                AssetName = "Asset 1",
                Broken = false,
                CountryOfDepartment = "Dominican Republic",
                EMailAdressOfDepartment = "Department@dominican.com.do",
                PurchaseDate = DateTime.Now
            });
        }
        public DbSet<Asset> Assets { get; set; }

    }
}
