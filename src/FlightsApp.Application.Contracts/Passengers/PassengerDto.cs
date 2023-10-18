using System;
using Volo.Abp.Application.Dtos;

namespace FlightsApp.Passengers
{
    public class PassengerDto : AuditedEntityDto<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}