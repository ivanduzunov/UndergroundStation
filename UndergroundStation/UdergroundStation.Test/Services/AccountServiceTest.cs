namespace UndergroundStation.Test.Services
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Xunit;
    using UndergroundStation.Services.Implementations;
    using Data;
    using Data.Models;

    public class AccountServiceTest
    {
        public AccountServiceTest()
        {
            TestStartUp.Initialize();
        }

        [Fact]
        public async Task AllHomeNewsAsyncShouldRerutnCorectedOrderedNewsArticles()
        {
            //Arrange
            var dbOptions = new DbContextOptionsBuilder<UndergroundStationDbContext>()
                .UseInMemoryDatabase("UndergroundStationTestDb")
                .Options;

            var db = new UndergroundStationDbContext(dbOptions);

            var accountService = new AccountService(db);

            var user = new User
            {
                Id = "1",
                UserName = "UserUsername"
            };

            db.AddRange(user);

            await db.SaveChangesAsync();
            //Act
            var result = await accountService.ProfileByUsername("UserUsername");


            //Assert
            result.Username
             .Should()
             .Equals("UserUsername");
        }
    }
}
