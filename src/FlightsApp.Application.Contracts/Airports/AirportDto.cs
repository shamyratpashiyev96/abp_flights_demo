using System;
using Volo.Abp.Application.Dtos;

namespace FlightsApp.Airports
{
    public class AirportDto : AuditedEntityDto<Guid>
    {
        public string City { get; set; }

        public string Code { get; set; }
    }
}