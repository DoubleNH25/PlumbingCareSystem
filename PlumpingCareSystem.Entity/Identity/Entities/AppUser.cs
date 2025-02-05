

using Microsoft.AspNetCore.Identity;

namespace PlumpingCareSystem.Entity.Identity.Entities
{
	public class AppUser : IdentityUser
	{
		public string? FileName { get; set; }
		public string? FileType { get; set; }
	}
}
