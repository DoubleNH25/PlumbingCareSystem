﻿
namespace PlumpingCareSystem.Entity.WebApplication.ViewModels.Contact
{
	public class ContactListVM
	{
		public int Id { get; set; }
		public string CreatedDate { get; set; } = null!;
		public string? UpdatedDate { get; set; }

		public string Location { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string Call { get; set; } = null!;
		public string Map { get; set; } = null!;
	}
}