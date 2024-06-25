using Kon.BillingBash.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kon.BillingBash.EntityFrameworkCore
{
	public static class BillingBashModelBuilderExtensions
	{
		public static void ConfigureBillManagement(this ModelBuilder builder)
		{
			builder.Entity<Bill>(b =>
			{
				b.ToTable(BillingBashConsts.DbTablePrefix + "Bill" + BillingBashConsts.DbSchema);

				b.Property(x => x.Comment).HasMaxLength(1024);
			});
		}
	}
}
