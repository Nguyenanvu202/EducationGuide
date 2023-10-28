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
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> dbContextOptions): base(dbContextOptions)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(SeedProductData());
            modelBuilder.Entity<ProductBrand>().HasData(SeedProductBrandData());
            modelBuilder.Entity<ProductType>().HasData(SeedProductTypes());

            modelBuilder.Entity<Product>().HasKey(c => c.Id);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public List<Product> SeedProductData()
        {
            var products = new List<Product>();
            using (StreamReader r = new StreamReader(@"E:\TTTN\HatHub\Infrastructure\Data\SeedData\products.json"))
            {
                string json = r.ReadToEnd();
                products = JsonConvert.DeserializeObject<List<Product>>(json);
            }
            return products;
        }


        public List<ProductBrand> SeedProductBrandData()
        {
            var productBrand = new List<ProductBrand>();
            using (StreamReader r = new StreamReader(@"E:\TTTN\HatHub\Infrastructure\Data\SeedData\brands.json"))
            {
                string json = r.ReadToEnd();
                productBrand = JsonConvert.DeserializeObject<List<ProductBrand>>(json);
            }
            return productBrand;
        }

        public List<ProductType> SeedProductTypes()
        {
            var productType = new List<ProductType>();
            using (StreamReader r = new StreamReader(@"E:\TTTN\HatHub\Infrastructure\Data\SeedData\types.json"))
            {
                string json = r.ReadToEnd();
                productType = JsonConvert.DeserializeObject<List<ProductType>>(json);
            }
            return productType;
        }


    }
}
