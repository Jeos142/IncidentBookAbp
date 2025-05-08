using Volo.Abp.Modularity;

namespace IncidentBookAbp;

[DependsOn(
    typeof(IncidentBookAbpApplicationModule),
    typeof(IncidentBookAbpDomainTestModule)
)]
public class IncidentBookAbpApplicationTestModule : AbpModule
{

}
