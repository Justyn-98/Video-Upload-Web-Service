using API.Models.Tabels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DataAccessLayer
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

       public DbSet<Video> Videos { get; set; }
       public DbSet<Comment> Comments { get; set; }
       public DbSet<PlayList> PlayLists { get; set; }
       public DbSet<VideoCategory> VideoCategories { get; set; }
       public DbSet<VideoOnPlayList> VideosOnPlayLists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<VideoOnPlayList>().HasKey(vp => new { vp.VideoId, vp.PlayListId });

            builder.Entity<VideoOnPlayList>()
                .HasOne(v => v._Video)
                .WithMany(p => p.VideoOnPlayLists)
                .HasForeignKey(f => f.VideoId);

            builder.Entity<VideoOnPlayList>()
                .HasOne(p => p._PlayList)
                .WithMany(v => v.VideosOnPlayList)
                .HasForeignKey(f => f.PlayListId);

        }
    }
}
