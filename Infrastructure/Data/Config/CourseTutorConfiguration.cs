using Core.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data.Config
{
	public class CourseTutorConfiguration : IEntityTypeConfiguration<CourseTutor>
	{

		public void Configure(EntityTypeBuilder<CourseTutor> builder)
		{
			builder.ToTable(nameof(CourseTutor));
			builder.HasKey(x => x.Id);

			builder.Property(x => x.CourseId).IsRequired();
			builder.Property(x => x.TutorId).IsRequired();

			builder.Property(p => p.CreatedBy).IsRequired().HasMaxLength(255);
			builder.Property(p => p.CreatedDate).IsRequired();
			builder.Property(p => p.UpdatedBy).HasMaxLength(255);
			builder.Property(p => p.UpdatedDate);
		}
	}
}
