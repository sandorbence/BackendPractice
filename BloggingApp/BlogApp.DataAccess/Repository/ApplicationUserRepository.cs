using BlogApp.DataAccess.Data;
using BlogApp.DataAccess.Repository.Interfaces;
using BlogApp.Models;

namespace BlogApp.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(ApplicationUser applicationUser)
        {
            this._db.Update(applicationUser);
        }
    }
}
