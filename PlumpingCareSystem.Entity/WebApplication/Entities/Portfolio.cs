using PlumpingCareSystem.Core.BaseEntity;

namespace PlumpingCareSystem.Entity.WebApplication.Entities
{
	public class Portfolio : BaseEntity
	{
		public string Title { get; set; } = null!;
		public string FileName { get; set; } = null!;
		public string FileType { get; set; } = null!;

		public int CategoryId { get; set; }
		public Category Category { get; set; } = null!;
	}
}
