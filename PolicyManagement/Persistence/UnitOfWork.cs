using PolicyManagement.Models;

namespace PolicyManagement.Persistence
{
    public class UnitOfWork
    { //trying the pattern that I saw in GigHub to remove dependency, but did not finish.
        private ApplicationDbContext _db;
        public PolicyRepository Policies { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _db = context;
            Policies = new PolicyRepository(context);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}