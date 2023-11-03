using Core.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data.Config
{
	public class CompanyInfoConfiguration : IEntityTypeConfiguration<CompanyInfo>
	{

		public void Configure(EntityTypeBuilder<CompanyInfo> builder)
		{
			builder.ToTable(nameof(CompanyInfo));
			builder.HasKey(x => x.Id);
			builder.Property(p => p.Name).IsRequired().HasMaxLength(255);
			builder.Property(p => p.Email).IsRequired().HasMaxLength(255);
			builder.Property(p => p.Adress).IsRequired().HasMaxLength(255);
			builder.Property(p => p.Phone).IsRequired().HasMaxLength(255);


			builder.Property(p => p.CreatedBy).IsRequired().HasMaxLength(255);
			builder.Property(p => p.CreatedDate).IsRequired();
			builder.Property(p => p.UpdatedBy).HasMaxLength(255);
			builder.Property(p => p.UpdatedDate);
		}
	}
}
