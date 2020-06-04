using API.DataAccessLayer;
using API.Models.Entities;
using API.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DataSeedServices
{
    public class DataSeedService : DatabaseAccessService, IDataSeedService
    {
        private readonly SeederHelper _helper = new SeederHelper();
        private readonly Random _random = new Random();

        public DataSeedService(ApplicationDbContext context) : base(context)
        {

        }

        public async Task SeedData()
        {
            const int range = 20;

            var users = await GenerateUsers(range);
            var videoCategories =await  GenerateVideoCategories(5);
            var playLists = await GeneratePlayLists(5);
            var videos = await GenerateVideos(users, videoCategories, 30);
            await GenereateVideosOnPlayLists(playLists, videos);
            await GenerateComents(users, videos, 300);
            await GenerateLikes(users, videos);
        }

        //public async Task RemoveData()
        //{
        //    Context.Users.RemoveRange(Context.Users);
        //    Context.VideoCategories.RemoveRange(await Context.VideoCategories.ToListAsync());
        //    Context.PlayLists.RemoveRange(await Context.PlayLists.ToListAsync());
        //    Context.VideoOnPlayLists.RemoveRange(await Context.VideoOnPlayLists.ToListAsync());
        //    Context.Comments.RemoveRange(await Context.Comments.ToListAsync());
        //    Context.Likes.RemoveRange(await Context.Likes.ToListAsync());
        //    await Context.SaveChangesAsync();
        //}


        private async Task<List<VideoOnPlayList>> GenereateVideosOnPlayLists(List<PlayList> playLists, List<Video> videos)
        {
            var videosOnPlayLists = new List<VideoOnPlayList>();
            foreach (var playlist in playLists)
            {
                foreach (var video in videos) 
                {
                    var videoOnPlayList = new VideoOnPlayList()
                    {
                        PlayListId = playlist.Id,
                        VideoId = video.Id,
                    };
                    videosOnPlayLists.Add(videoOnPlayList);
                    Context.Add(videoOnPlayList);
            }
            }
            await Context.SaveChangesAsync();
            return videosOnPlayLists;
        }

            private async Task<List<VideoLike>> GenerateLikes(List<User> users, List<Video> videos)
        {
            var likes = new List<VideoLike>();

            for (var usersNumber = 0; usersNumber < users.Count(); usersNumber++)
            {
                for (var videoNumber = 0; videoNumber < videos.Count(); videoNumber++)
                {
                    var user = new VideoLike()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserId = users.ElementAt(usersNumber).Id,
                        VideoId = videos.ElementAt(videoNumber).Id
                    };
                    Context.Add(user);
                    likes.Add(user);
                }
            }
            await Context.SaveChangesAsync();
            return likes;
        }

        private async Task<List<Video>> GenerateVideos(List<User> users, List<VideoCategory> videoCategories, int range)
        {
            var videos = new List<Video>();

            for (var videoCount = 1; videoCount < range; videoCount++)
            {
                var user = new Video()
                {
                    Id = Guid.NewGuid().ToString(),
                    VideoCategoryId = videoCategories.ElementAt(_random.Next(videoCategories.Count())).Id,
                    UserId = users.ElementAt(_random.Next(users.Count())).Id,
                    Name = _helper._videoName + _helper.GetRandomString(),
                    Description = _helper._descriptionName + _helper.GetRandomString()
                };
                Context.Add(user);
                videos.Add(user);
            }
            await Context.SaveChangesAsync();
            return videos;
        }

        private async Task<List<Comment>> GenerateComents(List<User> users, List<Video> videos, int range)
        {
            var comments = new List<Comment>();

            for (var commentCount = 1; commentCount < range; commentCount++)
            {
                var user = new Comment()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = users.ElementAt(_random.Next(users.Count())).Id,
                    VideoId = videos.ElementAt(_random.Next(videos.Count())).Id,
                    Content = _helper._commentName + _helper.GetRandomString()
                };
                Context.Add(user);
                comments.Add(user);
            }
            await Context.SaveChangesAsync();
            return comments;
        }

        private async Task<List<User>> GenerateUsers(int range)
        {
            var users = new List<User>();

            for (var userCount = 1; userCount < range; userCount++)
            {
                var user = new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = _helper.GetRandomShortString() + _helper._emailAddress,
                    UserName = _helper._userName + _helper.GetRandomShortString()
                };
                Context.Add(user);
                users.Add(user);
            }
            await Context.SaveChangesAsync();
            return users;
        }

        public async Task<List<VideoCategory>> GenerateVideoCategories(int range)
        {
            var videoCategories = new List<VideoCategory>();
            for (var videoCategoryNumber = 1; videoCategoryNumber < range; videoCategoryNumber++)
            {
                var videoCategory = new VideoCategory()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = _helper.GetProductCategoryName(videoCategoryNumber)
                };
                videoCategories.Add(videoCategory);
                Context.Add(videoCategory);
            }
            await Context.SaveChangesAsync();
            return videoCategories;
        }
        public async Task<List<PlayList>> GeneratePlayLists(int range)
        {
            var playLists = new List<PlayList>();
            for (var playlistNumber = 1; playlistNumber < range; playlistNumber++)
            {
                var playList = new PlayList()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "PlayLista: " + _helper.GetRandomShortString()
                };
                playLists.Add(playList);
                Context.Add(playList);
            }
            await Context.SaveChangesAsync();
            return playLists;
        }
    }
}
