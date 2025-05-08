using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace IncidentBookAbp.Data;

/* This is used if database provider does't define
 * IIncidentBookAbpDbSchemaMigrator implementation.
 */
public class NullIncidentBookAbpDbSchemaMigrator : IIncidentBookAbpDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
