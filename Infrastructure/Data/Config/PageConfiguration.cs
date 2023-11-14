using Core.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data.Config
{
	public class PageConfiguration : IEntityTypeConfiguration<Page>
	{

		public void Configure(EntityTypeBuilder<Page> builder)
		{
			builder.ToTable(nameof(Page));
			builder.HasKey(p => p.Id);

			builder.Property(p => p.Url).IsRequired().HasMaxLength(255);

			builder.HasMany(p => p.Sections).WithOne(p => p.Page).HasForeignKey(p => p.PageId);

			builder.Property(p => p.CreatedBy).IsRequired().HasMaxLength(255);
			builder.Property(p => p.CreatedDate).IsRequired();
			builder.Property(p => p.UpdatedBy).HasMaxLength(255);
			builder.Property(p => p.UpdatedDate);

		}
	}
}
