using System;
using FlightsApp.Permissions;
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
            CreateUpdateAirportDto>
    {
        public AirportAppService(IRepository<Airport, Guid> repo) : base(repo)
        {
            /* Requires these permissions for these types of operations, 
            if they're not met, service returns "unauthorized" response */
            GetPolicyName = FlightsAppPermissions.Airports.Default;
            GetListPolicyName = FlightsAppPermissions.Airports.Default;
            CreatePolicyName = FlightsAppPermissions.Airports.Create;
            UpdatePolicyName = FlightsAppPermissions.Airports.Update;
            DeletePolicyName = FlightsAppPermissions.Airports.Delete;
        }
    }
}