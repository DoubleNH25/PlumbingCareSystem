

using PlumpingCareSystem.Core.BaseEntity;

namespace PlumpingCareSystem.Entity.WebApplication.Entities
{
	public class Service : BaseEntity
	{
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public string Icon { get; set; } = null!;
	}
}
