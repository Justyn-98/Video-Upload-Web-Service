using API.Helpers.CommentResponseHelper;
using API.Helpers.EmailSenderHelper;
using API.Helpers.PlayListResponseHelper;
using API.Helpers.SubscriptionResponseHelper;
using API.Helpers.UserSignInHelper;
using API.Helpers.VideoResponseHelper;
using API.Services.AccountDetailsService;
using API.Services.AccountService;
using API.Services.CommentsService;
using API.Services.DataSeedServices;
using API.Services.LikesService;
using API.Services.PlayListsService;
using API.Services.SearchService;
using API.Services.SubscriptionsService;
using API.Services.UserRolesServices;
using API.Services.UserRolesServices.Interfaces;
using API.Services.VideoCategoriesService;
using API.Services.VideosService;
using Microsoft.Extensions.DependencyInjection;


namespace API.ServicesConfiguration
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IVideoCategoryService, VideoCategoryService>();
            services.AddScoped<IRolesCreateService, RolesCreateService>();
            services.AddScoped<IDefaultAdminService, DefaultAdminService>();
            services.AddScoped<IAccountDetailsService, AccountDeatilsService>();
            services.AddScoped<IVideosService, VideosService>();
            services.AddScoped<ICommentsService, CommentsService>();
            services.AddScoped<IPlaylistService, PlayListsSerivce>();
            services.AddScoped<ILikesService, LikesService>();
            services.AddScoped<IDataSeedService, DataSeedService>();
            services.AddScoped<ISubscriptionsService, SubscriptionService>();
            services.AddScoped<ISearchService, SearchService>();

            return services;
        }

        public static IServiceCollection AddHelpers(this IServiceCollection services)
        {
            services.AddScoped<IUserSignInHelper, UserSignInHelper>();
            services.AddScoped<ISubscriptionResponseHelper, SubscriptionResponseHelper>();
            services.AddScoped<ICommentResponseHelper, CommentResponseHelper>();
            services.AddScoped<IEmailSenderHelper, EmailSender>();
            services.AddScoped<IVideoResponseHelper, VideoReponseHelper>();
            services.AddScoped<IPlayListResponseHelper, PlayListReponseHelper>();

            return services;
        }
    }
}
