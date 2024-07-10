using Kon.AccountingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Kon.AccountingService.EntityFrameworkCore
{
	public static class AccountingServiceDbContextModelBuilderExtensions
	{
		public static void ConfigureAccountingService(this ModelBuilder builder)
		{
			builder.Entity<Bill>(b =>
			{
				b.ToTable(AccountingServiceConstants.DbTablePrefix + "Bill" + AccountingServiceConstants.DbSchema);
				b.ConfigureByConvention();

				b.Property(x => x.Comment).HasMaxLength(1024);

				b.HasMany(x => x.Items).WithOne().HasForeignKey(x => x.BillId);

				b.HasIndex(x => x.CreationTime);
			});

			builder.Entity<Item>(b =>
			{
				b.ToTable(AccountingServiceConstants.DbTablePrefix + "Item" + AccountingServiceConstants.DbSchema);
				b.ConfigureByConvention();

				b.Property(x => x.Name).HasMaxLength(64).IsRequired();
				b.Property(x => x.Price).HasColumnType("decimal(9,2)");
				b.Property(x => x.Comment).HasMaxLength(1024);

				b.HasIndex(x => x.CreationTime);
			});

			builder.Entity<PayItemHistory>(b =>
			{
				b.ToTable(AccountingServiceConstants.DbTablePrefix + "PayItemHistory" + AccountingServiceConstants.DbSchema);
				b.ConfigureByConvention();

				b.HasKey(x => new { x.ItemId, x.UserId });

				b.HasIndex(x => x.CreationTime);
			});
		}
	}
}
