using IncidentBookAbp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace IncidentBookAbp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(IncidentBookAbpEntityFrameworkCoreModule),
    typeof(IncidentBookAbpApplicationContractsModule)
)]
public class IncidentBookAbpDbMigratorModule : AbpModule
{
}
