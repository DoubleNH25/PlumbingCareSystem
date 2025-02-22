using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlumpingCareSystem.Entity.Identity.Entities;

namespace PlumpingCareSystem.Repository.Configuration.Identity
{
	public class AppUserClaimConfig : IEntityTypeConfiguration<AppUserClaim>
	{
		public void Configure(EntityTypeBuilder<AppUserClaim> builder)
		{
			builder.HasData(new AppUserClaim
			{
				Id = 1,
				UserId = Guid.Parse("6B0E483C-EBAE-4ED3-827E-8ED27F7D9131").ToString(),
				ClaimType = "AdminObserverExpireDate",
				ClaimValue = "02/03/2025"

			});
		}
	}
}