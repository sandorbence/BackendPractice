namespace BlogApp.DataAccess.Repository.Interfaces
{
	public interface IUnitOfWork
	{
		IArticleRepository Article { get; }

		void Save();
	}
}
