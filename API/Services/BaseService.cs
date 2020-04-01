using API.DataAccessLayer;


namespace API.Services
{
    public class BaseService
    {

        protected readonly ApplicationDbContext _context;

        public BaseService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
