using Core.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data.Config
{
	public class ContactConfiguration : IEntityTypeConfiguration<Contact>
	{

		public void Configure(EntityTypeBuilder<Contact> builder)
		{
			builder.ToTable(nameof(Contact));
			builder.HasKey(x => x.Id);
			builder.Property(p => p.Name).IsRequired().HasMaxLength(255);
			builder.Property(p => p.Email).IsRequired().HasMaxLength(255);
			builder.Property(p => p.Message).IsRequired().HasMaxLength(500);


			builder.Property(p => p.CreatedBy).IsRequired().HasMaxLength(255);
			builder.Property(p => p.CreatedDate).IsRequired();
			builder.Property(p => p.UpdatedBy).HasMaxLength(255);
			builder.Property(p => p.UpdatedDate);
		}
	}
}
