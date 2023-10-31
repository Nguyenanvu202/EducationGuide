using Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;

namespace Infrastructure.Data
{
    public class PageContext : DbContext
    {
        public PageContext(DbContextOptions<PageContext> dbContextOptions): base(dbContextOptions)
        {

        }
        public DbSet<Section> Sections { get; set; }
        public DbSet<CompanyInfo> CompanyInfos { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }

        public DbSet<Tutors> Tutors { get; set; }

        public DbSet<Users> Users { get; set; }
/*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(SeedProductData());
            modelBuilder.Entity<ProductBrand>().HasData(SeedProductBrandData());
            modelBuilder.Entity<ProductType>().HasData(SeedProductTypes());

            modelBuilder.Entity<Product>().HasKey(c => c.Id);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }*/

    }
}
