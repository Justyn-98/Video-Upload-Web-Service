

using API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace API.DataAccessLayer.DataSeeder
{
    public static class DataSeeder
    {
        private static readonly SeederHelper Helper;

        static DataSeeder()
        {
            Helper = new SeederHelper();
        }
        public static void SeedData(this ModelBuilder builder)
        {
            const int range = 20;
            var users = new List<User>();

            var defaultUser = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Email = Helper.GetRandomShortString() + Helper._emailAddress,
                UserName = Helper._userName + Helper.GetRandomShortString()
            };

            var defaultUserID = defaultUser.Id;

            for (var userCount = 1; userCount<range; userCount++)
            {
                var user = new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = Helper.GetRandomShortString() + Helper._emailAddress,
                    UserName = Helper._userName + Helper.GetRandomShortString()
                };
                builder.Entity<User>().HasData(user);
                users.Add(user);
            }
            string playListOneId = Guid.NewGuid().ToString();
            string playListTwoId = Guid.NewGuid().ToString();

            //builder.Entity<PlayList>().HasData(new PlayList()
            //{
            //    Id = playListOneId,
            //    Name = Helper._playListName + Helper.GetRandomString(),
            //    UserId = defaultUserID
            //});

            //builder.Entity<PlayList>().HasData(new PlayList()
            //{
            //    Id = playListTwoId,
            //    Name = Helper._playListName + Helper.GetRandomString(),
            //    UserId = defaultUserID,
            //});
            string firstcat = Guid.NewGuid().ToString();

            builder.Entity<VideoCategory>().HasData(new VideoCategory()
            {
                Id = firstcat,
                Name = "Domyślna kategoria"
            });
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
                    VideoCategoryId = firstcat,
                    Name =Helper._videoName + Helper.GetRandomString(),
                    Description = Helper._descriptionName + Helper.GetRandomString(),
                    DateOfCreate = DateTime.Now

                }) ;

                //builder.Entity<VideoOnPlayList>().HasData(new VideoOnPlayList()
                //{
                //    PlayListId = playListOneId,
                //    VideoId = currentVideoId,                 
                //});

                //builder.Entity<VideoOnPlayList>().HasData(new VideoOnPlayList()
                //{
                //    PlayListId = playListTwoId,
                //    VideoId = currentVideoId
                //});

                for (var likeNumber = 1; likeNumber < range; likeNumber++)
                {
                    builder.Entity<VideoLike>().HasData(new VideoLike
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserId = users.ElementAt(likeNumber - 1).Id,
                        VideoId = currentVideoId
                    });
                }

                for (var commentNumber = 1; commentNumber < 10; commentNumber++)
                {
                    string currentCommentId = Guid.NewGuid().ToString();

                    builder.Entity<Comment>().HasData(new Comment
                    {
                        Id = currentCommentId,
                        UserId = users.ElementAt(commentNumber).Id,
                        VideoId = currentVideoId,
                        Content = Helper._commentName + Helper.GetRandomString(),
                        DateOfCreate = DateTime.Now
                    }) ;
                }
            }
        }
    }
}

