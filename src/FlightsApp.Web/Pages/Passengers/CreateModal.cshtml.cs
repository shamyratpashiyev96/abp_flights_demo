using System.Threading.Tasks;
using FlightsApp.Passengers;
using Microsoft.AspNetCore.Mvc;

namespace FlightsApp.Web.Pages.Passengers
{
    public class CreateModal : FlightsAppPageModel
    {
        private readonly PassengerAppService passengerService;
        [BindProperty]
        public CreateUpdatePassengerDto passenger { get; set; }

        public CreateModal(PassengerAppService _passengerService)
        {
            this.passengerService = _passengerService;
        }

        public void OnGet()
        {
            passenger = new CreateUpdatePassengerDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await passengerService.CreateAsync(passenger);
            return NoContent();
        }
        
    }
}