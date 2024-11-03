namespace BlogApp.DataAccess.Repository.Interfaces
{
	public interface IUnitOfWork
	{
		IArticleRepository Article { get; }
		IApplicationUserRepository ApplicationUser { get; }

		void Save();
	}
}
