using API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DataAccessLayer.Configurations
{
    public class VideoLikeConfiguration : IEntityTypeConfiguration<VideoLike>
    {
        public void Configure(EntityTypeBuilder<VideoLike> builder)
        {
        }
    }
}
