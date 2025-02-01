

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlumpingCareSystem.Entity.WebApplication.Entities;

namespace PlumpingCareSystem.Repository.Configuration.WebApplication
{
	public class SocialMediaConfig : IEntityTypeConfiguration<SocialMedia>
	{
		public void Configure(EntityTypeBuilder<SocialMedia> builder)
		{
			builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
			builder.Property(x => x.UpdatedDate).HasMaxLength(10);
			builder.Property(x => x.RowVersion).IsRowVersion();

			builder.HasData(new SocialMedia
			{
				Id = 1,
				CreatedDate = "05/05/2025",
				FaceBook = "testFacebook",
				Instagram = "testInstagram",
			});
		}
	}
}