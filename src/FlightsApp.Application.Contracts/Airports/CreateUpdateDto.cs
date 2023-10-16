using System.ComponentModel.DataAnnotations;

namespace FlightsApp.Airports
{
    public class CreateUpdateAirportDto
    {
        [Required]
        public string City { get; set; }

        public string Code { get; set; }
    }
}