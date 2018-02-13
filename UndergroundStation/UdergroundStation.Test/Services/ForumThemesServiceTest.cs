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

    public class ForumThemesServiceTest
    {
        public ForumThemesServiceTest()
        {
            TestStartUp.Initialize();
        }

        [Fact]
        public async Task BySectionIdAsyncReturnsTheRightAnswerOrderedProperly()
        {
            //Arrange
            var dbOptions = new DbContextOptionsBuilder<UndergroundStationDbContext>()
                .UseInMemoryDatabase("UndergroundStationTestDb")
                .Options;

            var db = new UndergroundStationDbContext(dbOptions);

            var themesService = new ThemesService(db);

            var firstTheme = new ForumTheme
            {
                Id = 1,
                PublishedDate = DateTime.UtcNow,
                ForumSectionId = 1
            };

            var secondTheme = new ForumTheme
            {
                Id = 2,
                PublishedDate = DateTime.UtcNow.AddDays(-1),
                ForumSectionId = 1
            };

            var thirdTheme = new ForumTheme
            {
                Id = 3,
                IsDeleted = true,
                ForumSectionId = 1
            };

            var fourthTheme = new ForumTheme
            {
                Id = 4,
                ForumSectionId = 2
            };

            db.AddRange(firstTheme, secondTheme, thirdTheme, fourthTheme);

            await db.SaveChangesAsync();

            //Act
            var result = await themesService
                .BySectionIdAsync(1);

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
