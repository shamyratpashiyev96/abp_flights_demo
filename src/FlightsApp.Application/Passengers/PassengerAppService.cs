using System;
using FlightsApp.Permissions;
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
            /* Requires these permissions for these types of operations, 
            if they're not met, service returns "unauthorized" response */
            GetPolicyName = FlightsAppPermissions.Passengers.Default;
            GetListPolicyName = FlightsAppPermissions.Passengers.Default;
            CreatePolicyName = FlightsAppPermissions.Passengers.Create;
            UpdatePolicyName = FlightsAppPermissions.Passengers.Update;
            DeletePolicyName = FlightsAppPermissions.Passengers.Delete;
        }
    }
}