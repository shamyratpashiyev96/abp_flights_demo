using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace FlightsApp.Pages;

public class Index_Tests : FlightsAppWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
