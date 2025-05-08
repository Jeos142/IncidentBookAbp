using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IncidentBookAbp.Data;
using Volo.Abp.DependencyInjection;

namespace IncidentBookAbp.EntityFrameworkCore;

public class EntityFrameworkCoreIncidentBookAbpDbSchemaMigrator
    : IIncidentBookAbpDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreIncidentBookAbpDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the IncidentBookAbpDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<IncidentBookAbpDbContext>()
            .Database
            .MigrateAsync();
    }
}
