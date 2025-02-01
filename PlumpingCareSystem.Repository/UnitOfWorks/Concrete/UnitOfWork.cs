using Microsoft.EntityFrameworkCore;
using PlumpingCareSystem.Repository.Context;
using PlumpingCareSystem.Repository.Repositories.Abstract;
using PlumpingCareSystem.Repository.Repositories.Concrete;
using PlumpingCareSystem.Repository.UnitOfWorks.Abstract;

namespace PlumpingCareSystem.Repository.UnitOfWorks.Concrete
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _context;

		public UnitOfWork(AppDbContext context)
		{
			_context = context;
		}

		public void Commit()
		{
			_context.SaveChanges();
		}

		public async Task<bool> CommitAsync()
		{
			try
			{
				await _context.SaveChangesAsync();
				return true;

			}
			catch (DbUpdateConcurrencyException)
			{
				return false;
			}
		}

		public ValueTask DisposeAsync()
		{
			return _context.DisposeAsync();
		}

		IGenericRepositories<T> IUnitOfWork.GetGenericRepository<T>()
		{
			return new GenericRepositories<T>(_context);
		}
	}
}