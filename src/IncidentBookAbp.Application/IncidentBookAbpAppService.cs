using IncidentBookAbp.Localization;
using Volo.Abp.Application.Services;

namespace IncidentBookAbp;

/* Inherit your application services from this class.
 */
public abstract class IncidentBookAbpAppService : ApplicationService
{
    protected IncidentBookAbpAppService()
    {
        LocalizationResource = typeof(IncidentBookAbpResource);
    }
}
