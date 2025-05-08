using Volo.Abp.Settings;

namespace IncidentBookAbp.Settings;

public class IncidentBookAbpSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(IncidentBookAbpSettings.MySetting1));
    }
}
