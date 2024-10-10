using System.Linq.Expressions;

using BlogApp.DataAccess.Data;
using BlogApp.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DataAccess.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _db;
		internal DbSet<T> DbSet { get; init; }

		public Repository(ApplicationDbContext db)
		{
			this._db = db;
			this.DbSet = this._db.Set<T>();
		}

		public void Add(T entity)
		{
			this.DbSet.Add(entity);
		}

		public T Get(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool tracked = false)
		{
			IQueryable<T> query = tracked ? this.DbSet : this.DbSet.AsNoTracking();

			if (filter != null)
			{
				query = query.Where(filter);
			}

			if (!string.IsNullOrEmpty(includeProperties))
			{
				foreach (string property in includeProperties.Split(','))
				{
					query = query.Include(property);
				}
			}

			return query.FirstOrDefault();
		}

		public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
		{
			IQueryable<T> query = this.DbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			if (!string.IsNullOrEmpty(includeProperties))
			{
				foreach (string property in includeProperties.Split(','))
				{
					query = query.Include(property);
				}
			}

			return query.ToList();
		}

		public void Remove(T entity)
		{
			this.DbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			this.DbSet.RemoveRange(entities);
		}
	}
}
