﻿

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlumpingCareSystem.Entity.WebApplication.Entities;

namespace PlumpingCareSystem.Repository.Configuration.WebApplication
{
	public class CategoryConfig : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
			builder.Property(x => x.UpdatedDate).HasMaxLength(10);
			builder.Property(x => x.RowVersion).IsRowVersion();

			builder.HasMany(x => x.Portfolios).WithOne(x => x.Category).OnDelete(DeleteBehavior.Restrict);

			builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

			builder.HasData(new Category
			{
				Id = 1,
				CreatedDate = "05/05/2025",
				Name = "Projects",
			}, new Category
			{
				Id = 2,
				CreatedDate = "05/05/2025",
				Name = "SiteWorks",
			});
		}
	}
}
