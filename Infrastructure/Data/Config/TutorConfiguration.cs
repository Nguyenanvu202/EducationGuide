using Core.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data.Config
{
        public class TutorConfiguration : IEntityTypeConfiguration<Tutors>
        {
            
            public void Configure(EntityTypeBuilder<Tutors> builder)
            {
                builder.Property(p => p.Id).IsRequired();
                builder.Property(p => p.Name).IsRequired().HasMaxLength(255);
                builder.Property(p => p.FacebookUrl).IsRequired();
                builder.Property(p => p.Phone).IsRequired();
                builder.Property(p => p.Email).IsRequired();
                builder.Property(p => p.Description).IsRequired();
            }
        }
}
