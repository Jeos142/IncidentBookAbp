using Microsoft.Extensions.Localization;
using IncidentBookAbp.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace IncidentBookAbp;

[Dependency(ReplaceServices = true)]
public class IncidentBookAbpBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<IncidentBookAbpResource> _localizer;

    public IncidentBookAbpBrandingProvider(IStringLocalizer<IncidentBookAbpResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
