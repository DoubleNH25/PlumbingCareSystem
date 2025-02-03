

using PlumpingCareSystem.Entity.WebApplication.ViewModels.SocialMedia;
using PlumpingCareSystem.Service.ServiceHolding.Abstract;

namespace PlumpingCareSystem.Service.ServiceHolding.Concrete
{
	public class SocialMediaService : ISocialMediaService
	{
		public Task AddSocialMediaAsync(SocialMediaAddVM request)
		{
			throw new NotImplementedException();
		}

		public Task DeleteSocialMediaAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<SocialMediaListVM>> GetAllListAsync()
		{
			throw new NotImplementedException();
		}

		public Task<SocialMediaUpdateVM> GetSocialMediaById(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateSocialMediaAsync(SocialMediaUpdateVM request)
		{
			throw new NotImplementedException();
		}
	}
}
