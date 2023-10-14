using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FlightsApp.Web;

[Dependency(ReplaceServices = true)]
public class FlightsAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "FlightsApp";
}
