using System;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.DataAccessLayer.Configurations
{
    public class VideoCategoryConfiguration : IEntityTypeConfiguration<VideoCategory>
    {
        public void Configure(EntityTypeBuilder<VideoCategory> builder)
        {
            builder.HasAlternateKey(n => n.Name);
            
            builder.Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();
        }
    }
}
