using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using FlightsApp.Airports;
using FlightsApp.Passengers;
using Microsoft.AspNetCore.Mvc;
namespace FlightsApp.Web.Pages.Passengers
{
    public class EditModal : FlightsAppPageModel
    {
        [BindProperty(SupportsGet = true)]
        [HiddenInput]
        public Guid Id { get; set; }
        [BindProperty]
        public CreateUpdatePassengerDto passenger { get; set; }
        private readonly PassengerAppService passengerService;
        public EditModal(PassengerAppService _passengerService)
        {
            passengerService = _passengerService;    
        }

        public async Task OnGetAsync()
        {
            var passengerDto = await passengerService.GetAsync(Id);
            passenger = ObjectMapper.Map<PassengerDto, CreateUpdatePassengerDto>(passengerDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await passengerService.UpdateAsync(Id,passenger);
            return NoContent();
        }
    }
}