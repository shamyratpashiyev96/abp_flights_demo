using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace FlightsApp.Passengers
{
    public class PassengerAppService : 
        CrudAppService<
            Passenger,
            PassengerDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdatePassengerDto>
    {
        public PassengerAppService(IRepository<Passenger,Guid> passengerRepo) : base(passengerRepo)
        {
            
        }
    }
}