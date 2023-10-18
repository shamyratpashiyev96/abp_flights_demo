using FlightsApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FlightsApp.Permissions;

public class FlightsAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var FlightStoreGroup = context.AddGroup(FlightsAppPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(FlightsAppPermissions.MyPermission1, L("Permission:MyPermission1"));
        var airportPermissons = FlightStoreGroup.AddPermission(FlightsAppPermissions.Airports.Default, L("Permission:Airports"));
        airportPermissons.AddChild(FlightsAppPermissions.Airports.Create, L("Permission:Create"));
        airportPermissons.AddChild(FlightsAppPermissions.Airports.Update, L("Permission:Update"));
        airportPermissons.AddChild(FlightsAppPermissions.Airports.Delete,L("Permission:Delete"));

        var passengerPermissions = FlightStoreGroup.AddPermission(FlightsAppPermissions.Passengers.Default, L("Permission:Passengers"));
        passengerPermissions.AddChild(FlightsAppPermissions.Passengers.Create, L("Permission:Create"));
        passengerPermissions.AddChild(FlightsAppPermissions.Passengers.Update, L("Permission:Update"));
        passengerPermissions.AddChild(FlightsAppPermissions.Passengers.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<FlightsAppResource>(name);
    }
}
