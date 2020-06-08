using API.DataAccessLayer;
using API.ServiceResponses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Entities;
using API.Responses;

namespace API.Services.VideoCategoriesService
{
    public class VideoCategoryService : DatabaseAccessService, IVideoCategoryService
    {
        public VideoCategoryService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ActionResult<List<VideoCategory>>> GetVideoCategoriesList()
            => await Context.VideoCategories.ToListAsync();

        public async Task<ServiceResponse<bool>> DeleteVideoCategory(string id)
        {
            var entity = await Context.VideoCategories.FindAsync(id);

            if (entity == null)
                return ServiceResponse<bool>.Error(false, new ErrorMessage("Not Found Video Category"));

            Context.VideoCategories.Remove(entity);
            await Context.SaveChangesAsync();

            return ServiceResponse<bool>.Ok(new ErrorMessage("Video Category Deleted"));
        }

        public async Task<ServiceResponse<int>> VideoCategoryUpdateResponse(string id, string name)
        {
            var entity = await Context.VideoCategories.FindAsync(id);

            if (entity == null)
                return ServiceResponse<int>.Error(new ErrorMessage("Resource not exist"));
            var updatedVideoCategory = new VideoCategory
            {
                Id = entity.Id,
                Name = name
            };
            Context.Update(updatedVideoCategory);
            var numberOfChanges = await Context.SaveChangesAsync();

            return ServiceResponse<int>.Ok(numberOfChanges, new ErrorMessage("Video Category Updated"));
        }

        public async Task<ServiceResponse<VideoCategory>> VideoCategoryFindResponse(string id)
        {
            var videoCategory = await Context.VideoCategories.FindAsync(id);
            return videoCategory == null ? ServiceResponse<VideoCategory>.Error(new ErrorMessage("Not Found Video Category"))
                : ServiceResponse<VideoCategory>.Ok(videoCategory);
        }

        public async Task<ServiceResponse<VideoCategory>> CreateVideoCategoryResponse(VideoCategory videoCategory)
        {
            videoCategory.Id = Guid.NewGuid().ToString();
            Context.Add(videoCategory);
            await Context.SaveChangesAsync();

            return ServiceResponse<VideoCategory>.Ok(videoCategory);
        }


    }

}
