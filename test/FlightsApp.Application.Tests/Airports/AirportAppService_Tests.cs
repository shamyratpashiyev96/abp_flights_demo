using System;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;

namespace FlightsApp.Airports
{
    public class AirportAppService_Tests : FlightsAppApplicationTestBase
    {
        private readonly AirportAppService airportAppService;

        public AirportAppService_Tests()
        {
            this.airportAppService = GetRequiredService<AirportAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Airports()
        {
            var result = await airportAppService.GetListAsync(new PagedAndSortedResultRequestDto());
            result.TotalCount.ShouldBeGreaterThan(4);
            result.Items.ShouldContain(item=>item.City == "New York");
        }

        [Fact]
        public async Task Should_Create_A_Valid_Airport()
        {
            var result = await airportAppService.CreateAsync(
                new CreateUpdateAirportDto
                {
                    City = "Washington",
                    Code = "WIA"
                }
            );

            result.Id.ShouldNotBe(Guid.Empty);
            result.City.ShouldBe("Washington");
        }

        [Fact]
        public async Task Should_Not_Create_A_Book_Without_Name()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async()=>{
                await airportAppService.CreateAsync(
                    new CreateUpdateAirportDto{
                        City = "",
                        Code = "AAA"
                    }
                );
            });

            exception.ValidationErrors.ShouldContain(err => err.MemberNames.Any(mem=>mem == "City"));
        }
    }
}