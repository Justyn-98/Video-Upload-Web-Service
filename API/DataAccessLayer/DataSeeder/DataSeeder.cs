

using API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace API.DataAccessLayer.DataSeeder
{
    public static class DataSeeder
    {
        private static readonly SeederHelper Helper;

        private const string AdminUserId = "1";

        static DataSeeder()
        {
            Helper = new SeederHelper();
        }
        public static void SeedData(this ModelBuilder builder)
        {
            const int range = 7;

            for (var entityNumber = 1; entityNumber < range; entityNumber++)
            {

                string currentVideoCategoryId = Guid.NewGuid().ToString();
                string currentVideoId = Guid.NewGuid().ToString();

                builder.Entity<VideoCategory>().HasData(new VideoCategory()
                {
                    Id = currentVideoCategoryId,
                    Name = Helper.GetProductCategoryName(entityNumber)
                }) ;

                builder.Entity<Video>().HasData(new Video()
                {
                    Id = currentVideoId,
                    VideoCategoryId = currentVideoCategoryId,
                    Name =Helper._videoName + Helper.GetRandomString(),
                    Description = Helper._descriptionName + Helper.GetRandomString(),
                    DateOfCreate = DateTime.Now

                }) ;

                for (var commentNumber = 1; commentNumber < range; commentNumber++)
                {
                    string currentCommentId = Guid.NewGuid().ToString();

                    builder.Entity<Comment>().HasData(new Comment
                    {
                        Id = currentCommentId,
                        VideoId = currentVideoId,
                        UserId = AdminUserId,
                        Content = Helper._commentName + Helper.GetRandomString(),
                        DateOfCreate = DateTime.Now
                    }) ;
                }
            }
        }
    }
}

