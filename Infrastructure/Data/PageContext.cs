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
using Infrastructure.Data.SeedData;

namespace Infrastructure.Data
{
    public class PageContext : DbContext
    {
		private readonly ReadJsonFile readJsonFile;

		public PageContext(ReadJsonFile readJsonFile)
        {
			this.readJsonFile = readJsonFile;
		}
        public PageContext(DbContextOptions<PageContext> dbContextOptions): base(dbContextOptions)
        {

        }
        public DbSet<Section> Sections { get; set; }
        public DbSet<CompanyInfo> CompanyInfos { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }

        public DbSet<Tutors> Tutors { get; set; }

        public DbSet<Users> Users { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=SECHIII\\SQLEXPRESS; Database=EducationGuide; Trusted_Connection=True; TrustServerCertificate=True");
		}
		/*
				protected override void OnModelCreating(ModelBuilder modelBuilder)
				{
					modelBuilder.Entity<Product>().HasData(SeedProductData());
					modelBuilder.Entity<ProductBrand>().HasData(SeedProductBrandData());
					modelBuilder.Entity<ProductType>().HasData(SeedProductTypes());

					modelBuilder.Entity<Product>().HasKey(c => c.Id);
					modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
				}*/
		protected virtual void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Tutors>().HasData(readJsonFile.SeedTutorsData());
			modelBuilder.Entity<Tutors>().HasData(readJsonFile.SeedCourseData());
			modelBuilder.Entity<Tutors>().HasData(readJsonFile.SeedGenderData());
		}


	}
}
