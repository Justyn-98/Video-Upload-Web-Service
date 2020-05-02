using System;
using API.DataAccessLayer;


namespace API.Services
{
    public abstract class DatabaseAccessService
    {

        protected readonly ApplicationDbContext Context;

        protected DatabaseAccessService(ApplicationDbContext context)
        {
            Context = context;
        }

     

        
    }
}
