using Volo.Abp.Modularity;

namespace IncidentBookAbp;

public abstract class IncidentBookAbpApplicationTestBase<TStartupModule> : IncidentBookAbpTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
