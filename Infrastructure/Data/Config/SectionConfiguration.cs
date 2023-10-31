using Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class SectionConfiguraiton : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p=>p.Title).IsRequired().HasMaxLength(255);
            builder.Property(p=>p.Content).IsRequired();
            builder.Property(p => p.ImageUrl);

            builder.HasOne(b => b.CompanyInfo).WithOne();
            builder.HasOne(b => b.ContactForm).WithOne();
        }
    }
}
