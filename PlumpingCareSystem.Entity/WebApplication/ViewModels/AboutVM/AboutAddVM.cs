﻿using Microsoft.AspNetCore.Http;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.SocialMedia;

namespace PlumpingCareSystem.Entity.WebApplication.ViewModels.AboutVM
{
	public class AboutAddVM
	{
		public string Header { get; set; } = null!;
		public string Description { get; set; } = null!;
		public int Clients { get; set; }
		public int Projects { get; set; }
		public int HoursOfSupport { get; set; }
		public int HardWorkers { get; set; }
		public string FileName { get; set; } = null!;
		public string FileType { get; set; } = null!;

		public IFormFile Photo { get; set; } = null!;


		public int SocialMediaId { get; set; }
		public SocialMediaAddVM SocialMedia { get; set; } = null!;
	}
}