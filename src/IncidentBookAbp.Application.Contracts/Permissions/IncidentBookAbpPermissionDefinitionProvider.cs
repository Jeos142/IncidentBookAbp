using IncidentBookAbp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace IncidentBookAbp.Permissions;

public class IncidentBookAbpPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(IncidentBookAbpPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(IncidentBookAbpPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<IncidentBookAbpResource>(name);
    }
}
