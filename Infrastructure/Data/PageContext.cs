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
		private readonly ReadJsonFile readJsonFile;

		public PageContext(DbContextOptions<PageContext> options, ReadJsonFile readJsonFile) : base(options)
			{
			this.readJsonFile = readJsonFile;
		}

		public DbSet<Page> Pages { get; set; }
		public DbSet<Section> Sections { get; set; }
        public DbSet<CompanyInfo> CompanyInfos { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Tutors> Tutors { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<CourseTutor> CourseTutors { get; set; }

        public DbSet<Users> Users { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=SECHIII\\SQLEXPRESS; Database=EducationGuide; Trusted_Connection=True; TrustServerCertificate=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<Tutors>().HasData(readJsonFile.SeedTutorsData());
			//modelBuilder.Entity<Tutors>().HasData(readJsonFile.SeedCourseData());
			//modelBuilder.Entity<Tutors>().HasData(readJsonFile.SeedGenderData());
			//modelBuilder.Entity<Page>().ToTable(nameof(Page));
			//modelBuilder.Entity<Section>().ToTable(nameof(Section));

			//modelBuilder.Entity<Tutors>().HasKey(c => c.Id);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

	}
}
