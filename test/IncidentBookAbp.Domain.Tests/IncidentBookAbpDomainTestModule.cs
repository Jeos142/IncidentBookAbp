using Volo.Abp.Modularity;

namespace IncidentBookAbp;

[DependsOn(
    typeof(IncidentBookAbpDomainModule),
    typeof(IncidentBookAbpTestBaseModule)
)]
public class IncidentBookAbpDomainTestModule : AbpModule
{

}
