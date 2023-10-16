using AutoMapper;
using FlightsApp.Airports;

namespace FlightsApp.Web;

public class FlightsAppWebAutoMapperProfile : Profile
{
    public FlightsAppWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<AirportDto, CreateUpdateAirportDto>();
    }
}
