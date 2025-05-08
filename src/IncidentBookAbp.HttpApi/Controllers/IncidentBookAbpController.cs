using IncidentBookAbp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace IncidentBookAbp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class IncidentBookAbpController : AbpControllerBase
{
    protected IncidentBookAbpController()
    {
        LocalizationResource = typeof(IncidentBookAbpResource);
    }
}
