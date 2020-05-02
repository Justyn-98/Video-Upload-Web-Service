 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 using API.Models.Entities;
 using Microsoft.EntityFrameworkCore;
 using Microsoft.EntityFrameworkCore.Metadata.Builders;

 namespace API.DataAccessLayer.Configurations
{
    public class VideoOnPlayListConfiguration : IEntityTypeConfiguration<VideoOnPlayList>
    {
        public void Configure(EntityTypeBuilder<VideoOnPlayList> builder)
        {
            builder.HasKey(vp => new { vp.VideoId, vp.PlayListId });

            builder.HasOne(v => v.Video)
                .WithMany(p => p.VideoOnPlayLists)
                .HasForeignKey(f => f.VideoId);

            builder.HasOne(p => p.PlayList)
                .WithMany(v => v.VideosOnPlayList)
                .HasForeignKey(f => f.PlayListId);
        }
    }
}
