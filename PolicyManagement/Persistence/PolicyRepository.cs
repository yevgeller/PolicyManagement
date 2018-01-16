using PolicyManagement.Models;

namespace PolicyManagement.Persistence
{
    public class PolicyRepository
    {
        ApplicationDbContext _db;

        public PolicyRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        //here all the methods pertaining to policy
    }
}