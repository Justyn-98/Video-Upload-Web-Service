using API.DataAccessLayer;
using API.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class LikesService : DatabaseAccessService, ILikesService
    {
        public LikesService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
