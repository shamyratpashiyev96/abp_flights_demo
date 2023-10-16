using System.Threading.Tasks;
using FlightsApp.Airports;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FlightsApp.Web.Pages.Airports
{
    public class CreateModal : FlightsAppPageModel
    {
        private readonly AirportAppService airportAppService;

        [BindProperty]
        public CreateUpdateAirportDto airport { get; set; }

        public CreateModal(AirportAppService _airportAppService)
        {
            this.airportAppService = _airportAppService;
        }

        public void OnGet()
        {
            airport = new CreateUpdateAirportDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await airportAppService.CreateAsync(airport);
            return NoContent();
        }
    }
}