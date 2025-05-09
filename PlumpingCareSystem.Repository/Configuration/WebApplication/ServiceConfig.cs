﻿

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlumpingCareSystem.Entity.WebApplication.Entities;

namespace PlumpingCareSystem.Repository.Configuration.WebApplication
{
	public class ServiceConfig : IEntityTypeConfiguration<Services>
	{
		public void Configure(EntityTypeBuilder<Services> builder)
		{
			builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
			builder.Property(x => x.UpdatedDate).HasMaxLength(10);
			builder.Property(x => x.RowVersion).IsRowVersion();

			builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
			builder.Property(x => x.Description).IsRequired().HasMaxLength(2000);
			builder.Property(x => x.Icon).IsRequired().HasMaxLength(100);

			builder.HasData(new Services
			{
				Id = 1,
				CreatedDate = "05/05/2025",
				Icon = "bi bi-service1",
				Name = "Plumbing Service 1",
				Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. In nibh mauris cursus mattis molestie a iaculis at erat. Odio ut enim blandit volutpat maecenas volutpat blandit aliquam etiam."

			}, new Services
			{
				Id = 2,
				CreatedDate = "05/05/2025",
				Icon = "bi bi-service2",
				Name = "Plumbing Service 2",
				Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. In nibh mauris cursus mattis molestie a iaculis at erat. Odio ut enim blandit volutpat maecenas volutpat blandit aliquam etiam."

			}, new Services
			{
				Id = 3,
				CreatedDate = "05/05/2025",
				Icon = "bi bi-service3",
				Name = "Plumbing Service 3",
				Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. In nibh mauris cursus mattis molestie a iaculis at erat. Odio ut enim blandit volutpat maecenas volutpat blandit aliquam etiam."

			});
		}
	}
}