using PlumpingCareSystem.Core.BaseEntity;
using PlumpingCareSystem.Repository.Repositories.Abstract;

namespace PlumpingCareSystem.Repository.UnitOfWorks.Abstract
{
	public interface IUnitOfWork
	{
		void Commit();
		Task<bool> CommitAsync();
		IGenericRepositories<T> GetGenericRepository<T>() where T : class, IBaseEntity, new();
		ValueTask DisposeAsync();
	}
}