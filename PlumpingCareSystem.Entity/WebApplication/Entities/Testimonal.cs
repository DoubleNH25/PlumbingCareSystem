using PlumpingCareSystem.Core.BaseEntity;


namespace PlumpingCareSystem.Entity.WebApplication.Entities
{
	public class Testimonal : BaseEntity
	{
		public string Comment { get; set; } = null!;
		public string FullName { get; set; } = null!;
		public string Title { get; set; } = null!;
		public string FileName { get; set; } = null!;
		public string FileType { get; set; } = null!;
	}
}
