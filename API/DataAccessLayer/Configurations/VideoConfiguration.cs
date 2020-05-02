using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.DataAccessLayer.Configurations
{
    public class VideoConfiguration : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(d => d.Description)
                .HasMaxLength(5000)
                .IsUnicode();

            builder.Property(d => d.IsActive)
                .HasDefaultValue(true)
                .ValueGeneratedOnAdd();

            builder.Property(l => l.Likes).HasDefaultValue(0);
        }
    }
}
