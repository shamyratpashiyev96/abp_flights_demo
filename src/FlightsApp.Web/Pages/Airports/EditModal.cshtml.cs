using System;
using System.Threading.Tasks;
using FlightsApp.Airports;
using Microsoft.AspNetCore.Mvc;
namespace FlightsApp.Web.Pages.Airports
{
    public class EditModal : FlightsAppPageModel
    {
        [BindProperty(SupportsGet = true)]
        [HiddenInput]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateAirportDto airport { get; set; }
        private readonly AirportAppService airportAppService;

        public EditModal(AirportAppService _airportAppService)
        {
            this.airportAppService = _airportAppService;
        }

        public async Task OnGetAsync()
        {
            var airportDto = await airportAppService.GetAsync(Id);
            airport = ObjectMapper.Map<AirportDto,CreateUpdateAirportDto>(airportDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await airportAppService.UpdateAsync(Id,airport);
            return NoContent();
        }
    }
}