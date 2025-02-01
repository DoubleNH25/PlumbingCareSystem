using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumpingCareSystem.Entity.WebApplication.ViewModels.Category
{
	public class CategoryUpdateVM
	{
		public int Id { get; set; }
		public string? UpdatedDate { get; set; }
		public byte[] RowVersion { get; set; } = null!;

		public string Name { get; set; } = null!;
	}
}