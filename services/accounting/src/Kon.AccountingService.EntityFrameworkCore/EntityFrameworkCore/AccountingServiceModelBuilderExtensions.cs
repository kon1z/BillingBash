using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kon.AccountingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;

namespace Kon.AccountingService.EntityFrameworkCore
{
	public static class AccountingServiceModelBuilderExtensions
	{
		public static void ConfigureBillManagement(this ModelBuilder builder)
		{
			builder.Entity<Bill>(b =>
			{
				b.ToTable(AccountingServiceConsts.DbTablePrefix + "Bill" + AccountingServiceConsts.DbSchema);
				b.ConfigureByConvention();

				b.Property(x => x.Comment).HasMaxLength(1024);

				b.HasMany(x => x.Items).WithOne().HasForeignKey(x => x.BillId);

				b.HasIndex(x => x.CreationTime);
			});

			builder.Entity<Item>(b =>
			{
				b.ToTable(AccountingServiceConsts.DbTablePrefix + "Item" + AccountingServiceConsts.DbSchema);
				b.ConfigureByConvention();

				b.Property(x => x.Name).HasMaxLength(64).IsRequired();
				b.Property(x => x.Price).HasColumnType("decimal(9,2)");
				b.Property(x => x.Comment).HasMaxLength(1024);

				b.HasMany<IdentityUser>().WithMany()
					.UsingEntity<PayItemHistory>(
						l => l.HasOne<IdentityUser>().WithMany().HasForeignKey(x => x.UserId),
						r => r.HasOne<Item>().WithMany(x => x.PayItemHistories).HasForeignKey(x => x.ItemId)
					);

				b.HasIndex(x => x.CreationTime);
			});

			builder.Entity<PayItemHistory>(b =>
			{
				b.ToTable(AccountingServiceConsts.DbTablePrefix + "PayItemHistory" + AccountingServiceConsts.DbSchema);
				b.ConfigureByConvention();

				b.HasKey(x => new { x.ItemId, x.UserId });

				b.HasIndex(x => x.CreationTime);
			});
		}
	}
}
