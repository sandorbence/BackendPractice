using BlogApp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;

        public DbInitializer(ApplicationDbContext db)
        {
            this._db = db;
        }

        public void Initialize()
        {
            try
            {
                if (this._db.Database.GetPendingMigrations().Count() > 0)
                {
                    this._db.Database.Migrate();
                }
            }
            catch (Exception ex) { }
        }
    }
}
