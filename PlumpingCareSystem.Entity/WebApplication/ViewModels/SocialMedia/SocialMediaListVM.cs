using PlumpingCareSystem.Entity.WebApplication.ViewModels.AboutVM;

namespace PlumpingCareSystem.Entity.WebApplication.ViewModels.SocialMedia
{
	public class SocialMediaListVM
	{
		public int Id { get; set; }
		public string CreatedDate { get; set; } = DateTime.Now.ToString("d");
		public string? UpdatedDate { get; set; }

		public string? Twitter { get; set; }
		public string? LinkedIn { get; set; }
		public string? FaceBook { get; set; }
		public string? Instagram { get; set; }

		public AboutListVM About { get; set; } = null!;
	}
}