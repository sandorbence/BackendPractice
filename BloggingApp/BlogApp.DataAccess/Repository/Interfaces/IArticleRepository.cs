using BlogApp.Models.Models;

namespace BlogApp.DataAccess.Repository.Interfaces
{
    public interface IArticleRepository : IRepository<Article>
	{
		void Update(Article article);
	}
}
