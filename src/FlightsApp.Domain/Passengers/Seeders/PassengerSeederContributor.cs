using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace FlightsApp.Passengers
{
    public class PassengerSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Passenger, Guid> passengerRepo;

       public PassengerSeederContributor(IRepository<Passenger, Guid> _passengerRepo)
       {
            this.passengerRepo = _passengerRepo;
       }

       public async Task SeedAsync(DataSeedContext context)
       {
            List<Passenger> passengers = new(){
                new Passenger{ FirstName = "John", LastName = "Doe" },
                new Passenger{ FirstName = "Joshua", LastName = "Abigale" },
                new Passenger{ FirstName = "Lily", LastName = "Fletcher" },
                new Passenger{ FirstName = "Rose", LastName = "Gamer" },
                new Passenger{ FirstName = "Carlisle", LastName = "Johnson" },
                new Passenger{ FirstName = "Isabella", LastName = "Watson" },
                new Passenger{ FirstName = "Harry", LastName = "Grint" },
                new Passenger{ FirstName = "Emily", LastName = "Dares" },
                new Passenger{ FirstName = "David", LastName = "Miles" },
                new Passenger{ FirstName = "Dean", LastName = "Simons" },
            };

            await passengerRepo.InsertManyAsync(passengers);
       }


    }

    
}