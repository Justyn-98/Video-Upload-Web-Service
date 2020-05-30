using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.DataAccessLayer.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.Content)
                .HasMaxLength(2000)
                .IsRequired()
                .IsUnicode();

            builder.Property(d => d.DateOfCreate)
                .HasDefaultValue(DateTime.Now)
                .ValueGeneratedOnAdd();
        }
    }
}
