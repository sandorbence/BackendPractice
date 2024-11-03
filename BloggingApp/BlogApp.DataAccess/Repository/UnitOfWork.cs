using BlogApp.DataAccess.Data;
using BlogApp.DataAccess.Repository.Interfaces;

namespace BlogApp.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IArticleRepository Article { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            this._db = db;
            this.Article = new ArticleRepository(this._db);
            this.ApplicationUser = new ApplicationUserRepository(this._db);
        }

        public void Save()
        {
            this._db.SaveChanges();
        }
    }
}
