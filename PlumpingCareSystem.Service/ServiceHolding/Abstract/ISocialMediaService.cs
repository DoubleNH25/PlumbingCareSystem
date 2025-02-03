

using PlumpingCareSystem.Entity.WebApplication.ViewModels.SocialMedia;

namespace PlumpingCareSystem.Service.ServiceHolding.Abstract
{
	public interface ISocialMediaService
	{
		Task<List<SocialMediaListVM>> GetAllListAsync();
		Task AddSocialMediaAsync(SocialMediaAddVM request);
		Task DeleteSocialMediaAsync(int id);
		Task<SocialMediaUpdateVM> GetSocialMediaById(int id);
		Task UpdateSocialMediaAsync(SocialMediaUpdateVM request);
	}
}