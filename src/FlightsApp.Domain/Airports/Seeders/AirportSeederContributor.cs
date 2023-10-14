using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace FlightsApp.Airports.Seeders
{
    public class AirportSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Airport, Guid> repo;

        public AirportSeederContributor(IRepository<Airport, Guid> _repo)
        {
            this.repo = _repo;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            List<Airport> airports = new(){
                new Airport { City = "New York", Code = "JFK" },
                new Airport { City = "London", Code = "HTR" },
                new Airport { City = "Paris", Code = "CDH" },
                new Airport { City = "Rome", Code = "RMA" },
                new Airport { City = "Shanghai", Code = "SHA" },
            };

            await repo.InsertManyAsync(airports);
        }
    }
}