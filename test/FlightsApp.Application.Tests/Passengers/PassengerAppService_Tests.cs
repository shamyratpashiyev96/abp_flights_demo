using System;
using System.Linq;
using System.Threading.Tasks;
using FlightsApp.Airports;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;

namespace FlightsApp.Passengers
{
    public class PassengerAppService_Tests : FlightsAppApplicationTestBase
    {
        private readonly PassengerAppService passengerService;

        public PassengerAppService_Tests()
        {
            this.passengerService = GetRequiredService<PassengerAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Passengers()
        {
            var result = await passengerService.GetListAsync(new PagedAndSortedResultRequestDto());
            result.TotalCount.ShouldBeGreaterThan(4);
            result.Items.ShouldContain(item=>item.LastName == "Johnson");
        }

        [Fact]
        public async Task Should_Create_Valid_Passenger()
        {
            var result = await passengerService.CreateAsync(
                new CreateUpdatePassengerDto{
                    FirstName = "John",
                    LastName = "Wick"
                }
            );
            result.Id.ShouldNotBe(Guid.Empty);
            result.LastName.ShouldBe("Wick");
        }

        public async Task Should_Not_Create_A_Passenger_Without_Name()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async()=>{
                await passengerService.CreateAsync(
                    new CreateUpdatePassengerDto{
                        FirstName = "",
                        LastName = "Carter"
                    }
                );
            });

            exception.ValidationErrors.ShouldContain(err => err.MemberNames.Any(mem => mem == "FirstName"));
        }

    }
}