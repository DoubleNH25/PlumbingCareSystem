using PlumpingCareSystem.Core.BaseEntity;

namespace PlumpingCareSystem.Entity.WebApplication.Entities
{
	public class Category : BaseEntity
	{
		public string Name { get; set; } = null!;

		public List<Portfolio> Portfolios { get; set; } = null!;

	}
}
