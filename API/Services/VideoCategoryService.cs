using API.DataAccessLayer;
using API.Models.Tabels;
using API.Responses.Messages;
using API.ServiceResponses;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static API.Responses.Messages.DatabaseMessage;

namespace API.Services
{
    public class VideoCategoryService : BaseService, IVideoCategoryService
    {
        public VideoCategoryService(ApplicationDbContext context) : base(context)
        {

        }

        public async Task DeleteVideoCategory(VideoCategory videoCategory)
        {
            _context.VideoCategories.Remove(videoCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<List<VideoCategory>>> GetVideoCategoriesList()
            => await _context.VideoCategories.ToListAsync();

        public async Task<ServiceResponse<bool>> VideoCategoryUpdateResponse(string id, VideoCategory videoCategory)
        {

            videoCategory.Id = id;
            _context.Update(videoCategory);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoCategoryExists(id))
                {
                    return ServiceResponse<bool>.Error(new DatabaseMessage(DatabaseMessageContent.RESOURCE_NOT_EXIST));
                }
                else
                {
                    throw;
                }
            }
            return ServiceResponse<bool>.Ok();
        }

        public async Task<ServiceResponse<VideoCategory>> VideoCategoryFindResponse(string id)
        {
            var videoCategory = await _context.VideoCategories.FindAsync(id);
            return videoCategory == null ? ServiceResponse<VideoCategory>.Error()
                : ServiceResponse<VideoCategory>.Ok(videoCategory);
        }

        public async Task<ServiceResponse<VideoCategory>> CreateVideoCategoryResponse(VideoCategory videoCategory)
        {
            videoCategory.Id = Guid.NewGuid().ToString();
            _context.VideoCategories.Add(videoCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VideoCategoryExists(videoCategory.Id))
                {
                    return ServiceResponse<VideoCategory>.Error(new DatabaseMessage(DatabaseMessageContent.RESOURCE_NOT_EXIST));
                }
                else
                {
                    throw;
                }
            }
            return ServiceResponse<VideoCategory>.Ok(videoCategory);
        }

        private bool VideoCategoryExists(string id)
        {
            return _context.VideoCategories.Any(e => e.Id == id);
        }
    }

}
