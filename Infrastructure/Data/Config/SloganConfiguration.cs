using Core.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data.Config
{
	public class SloganConfiguration : IEntityTypeConfiguration<Slogan>
	{

		public void Configure(EntityTypeBuilder<Slogan> builder)
		{
			builder.ToTable(nameof(Slogan));
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Title);
			builder.Property(x => x.Content);


			builder.Property(p => p.CreatedBy).IsRequired().HasMaxLength(255);
			builder.Property(p => p.CreatedDate).IsRequired();
			builder.Property(p => p.UpdatedBy).HasMaxLength(255);
			builder.Property(p => p.UpdatedDate);
		}
	}
}
