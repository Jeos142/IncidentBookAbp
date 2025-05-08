using Volo.Abp.Modularity;

namespace IncidentBookAbp;

/* Inherit from this class for your domain layer tests. */
public abstract class IncidentBookAbpDomainTestBase<TStartupModule> : IncidentBookAbpTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
