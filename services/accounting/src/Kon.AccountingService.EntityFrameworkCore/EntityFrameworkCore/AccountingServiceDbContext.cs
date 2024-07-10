using Kon.AccountingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Kon.AccountingService.EntityFrameworkCore;

[ConnectionStringName("Default")]
public class AccountingServiceDbContext : AbpDbContext<AccountingServiceDbContext>, IAccountingServiceDbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<Bill> Bills { get; set; }

    public AccountingServiceDbContext(DbContextOptions<AccountingServiceDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureAccountingService();
    }
}
