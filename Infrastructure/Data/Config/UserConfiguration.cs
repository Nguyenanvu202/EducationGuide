using Core.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data.Config
{
	public class UserConfiguration : IEntityTypeConfiguration<Users>
	{

		public void Configure(EntityTypeBuilder<Users> builder)
		{
			builder.ToTable(nameof(Users));
			builder.HasKey(x => x.Id);
			builder.Property(p => p.Username).IsRequired().HasMaxLength(255);
			builder.Property(p => p.Email).IsRequired().HasMaxLength(255);
			builder.Property(p => p.Password).IsRequired().HasMaxLength(255);


			builder.Property(p => p.CreatedBy).IsRequired().HasMaxLength(255);
			builder.Property(p => p.CreatedDate).IsRequired();
			builder.Property(p => p.UpdatedBy).HasMaxLength(255);
			builder.Property(p => p.UpdatedDate);
		}
	}
}
