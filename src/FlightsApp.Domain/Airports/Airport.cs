using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace FlightsApp.Airports
{
    public class Airport : AuditedAggregateRoot<Guid>
    {
        [Required]
        [Column(TypeName = "VARCHAR(200)")]
        public string City { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(200)")]
        public string Code { get; set; }
    }
}