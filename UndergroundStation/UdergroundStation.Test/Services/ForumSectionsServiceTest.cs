namespace UndergroundStation.Test.Services
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Xunit;
    using UndergroundStation.Services.Forum.Implementations;
    using Data;
    using Data.Models;

    public class ForumSectionsServiceTest
    {
        public ForumSectionsServiceTest()
        {
            TestStartUp.Initialize();
        }

        [Fact]
        public async Task AllAsyncShouldReturnCorrectAnswerAndOrderedProperly()
        {
            //Arrange
            var dbOptions = new DbContextOptionsBuilder<UndergroundStationDbContext>()
                .UseInMemoryDatabase("UndergroundStationTestDb")
                .Options;

            var db = new UndergroundStationDbContext(dbOptions);

            var sectionsService = new SectionsService(db);

            var firtSection = new ForumSection
            {
                Id = 1,
                Tittle = "b"
            };

            var secondSection = new ForumSection
            {
                Id = 2,
                Tittle = "a"
            };

            db.AddRange(firtSection, secondSection);

            await db.SaveChangesAsync();

            //Act
            var result = await sectionsService
                .AllAsync();

            //Assert
            result
               .Should()
               .Match
               (r => r.ElementAt(0).Id == 2
               && r.ElementAt(1).Id == 1)
               .And
               .HaveCount(2);
        }
    }
}
