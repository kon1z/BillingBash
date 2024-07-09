﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Kon.AdministrationService.Data;
using Volo.Abp.DependencyInjection;

namespace Kon.AdministrationService.EntityFrameworkCore;

public class EntityFrameworkCoreAdministrationServiceDbSchemaMigrator
    : IAdministrationServiceDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAdministrationServiceDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the AdministrationServiceDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AdministrationServiceDbContext>()
            .Database
            .MigrateAsync();
    }
}
