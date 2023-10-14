using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace FlightsApp.Airports
{
    public class AirportAppService : 
        CrudAppService<
            Airport,
            AirportDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateDto>
    {
        public AirportAppService(IRepository<Airport, Guid> repo) : base(repo)
        {
            
        }
    }
}