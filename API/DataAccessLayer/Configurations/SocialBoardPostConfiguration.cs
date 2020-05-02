using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.DataAccessLayer.Configurations
{
    public class SocialBoardPostConfiguration : IEntityTypeConfiguration<SocialBoardPost>
    {
        public void Configure(EntityTypeBuilder<SocialBoardPost> builder)
        {
            builder.Property(c => c.Content)
                .HasMaxLength(2000)
                .IsRequired()
                .IsUnicode();

            builder.Property(l => l.Likes)
                .HasDefaultValue(0);

        }
    }
}
