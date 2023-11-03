using Core.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data.Config
{
	public class CourseConfiguration : IEntityTypeConfiguration<Course>
	{

		public void Configure(EntityTypeBuilder<Course> builder)
		{
			builder.ToTable(nameof(Course));
			builder.HasKey(p => p.Id);
			builder.Property(p => p.Subject).HasMaxLength(255);

			builder.HasMany(p => p.CourseTutors).WithOne(p => p.Course).HasForeignKey(p => p.CourseId);

			builder.Property(p => p.CreatedBy).IsRequired().HasMaxLength(255);
			builder.Property(p => p.CreatedDate).IsRequired();
			builder.Property(p => p.UpdatedBy).HasMaxLength(255);
			builder.Property(p => p.UpdatedDate);
		}
	}
}
