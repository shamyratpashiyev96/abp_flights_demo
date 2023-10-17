using System.Threading.Tasks;
using FlightsApp.Localization;
using FlightsApp.MultiTenancy;
using FlightsApp.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace FlightsApp.Web.Menus;

public class FlightsAppMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<FlightsAppResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                FlightsAppMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        var FlightsMenu = new ApplicationMenuItem(
                "FlightsApp",
                l["Menu:FlightsApp"],
                icon: "fa fa-plane"
            );

        if(await context.IsGrantedAsync(FlightsAppPermissions.Airports.Default))
        {
            FlightsMenu.AddItem(
                new ApplicationMenuItem(
                    "FlightsApp.Airports",
                    l["Menu:Airports"],
                    url: "/Airports",
                    icon: "fa fa-building"
                )
            );
        }

        context.Menu.AddItem(FlightsMenu);

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        // return Task.CompletedTask;
    }
}
