namespace FlightsApp.Permissions;

public static class FlightsAppPermissions
{
    public const string GroupName = "FlightsApp";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public class Airports
    {
        public const string Default = GroupName + ".Airports";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public class Passengers
    {
        public const string Default = GroupName + ".Passengers";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }
}
