using Localization.Resources.AbpUi;
using IncidentBookAbp.Localization;
using Volo.Abp.Account;
using Volo.Abp.SettingManagement;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.Localization;
using Volo.Abp.TenantManagement;
using IncidentBookAbp;
using Volo.Abp.AspNetCore.Mvc;


namespace IncidentBookAbp;

 [DependsOn(
    typeof(IncidentBookAbpApplicationContractsModule),
    typeof(IncidentBookAbpApplicationModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpSettingManagementHttpApiModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpTenantManagementHttpApiModule),
    typeof(AbpFeatureManagementHttpApiModule)
    )]
public class IncidentBookAbpHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(IncidentBookAbpApplicationModule).Assembly);
        });
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<IncidentBookAbpResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
