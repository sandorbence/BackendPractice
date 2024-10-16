using BlogApp.DataAccess.Data;
using BlogApp.DataAccess.Repository.Interfaces;
using BlogApp.Models;

namespace BlogApp.DataAccess.Repository
{
	internal class ArticleRepository : Repository<Article>, IArticleRepository
	{
		private readonly ApplicationDbContext _db;

		public ArticleRepository(ApplicationDbContext db) : base(db)
		{
			this._db = db;
		}

		public void Update(Article article)
		{
			this._db.Articles.Update(article);
		}
	}
}
