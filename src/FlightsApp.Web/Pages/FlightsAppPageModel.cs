using FlightsApp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FlightsApp.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class FlightsAppPageModel : AbpPageModel
{
    protected FlightsAppPageModel()
    {
        LocalizationResourceType = typeof(FlightsAppResource);
    }
}
