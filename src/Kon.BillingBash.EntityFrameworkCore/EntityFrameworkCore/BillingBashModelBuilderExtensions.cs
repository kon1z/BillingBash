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

				b.HasMany(x => x.Items).WithOne().HasForeignKey(x => x.BillId);
			});

			builder.Entity<Item>(b =>
			{
				b.ToTable(BillingBashConsts.DbTablePrefix + "Item" + BillingBashConsts.DbSchema);

				b.Property(x => x.Name).HasMaxLength(64).IsRequired();
				b.Property(x => x.Comment).HasMaxLength(1024);

				b.HasMany(x => x.Payers).WithMany();
				b.HasMany(x => x.PayItemHistories).with

			});
		}
	}
}
