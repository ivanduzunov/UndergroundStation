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

    public class ForumArticleServiceTest
    {
        public ForumArticleServiceTest()
        {
            TestStartUp.Initialize();
        }

        [Fact]
        public async Task CreateCreatesSuccesssully()
        {
            //Arrange
            var dbOptions = new DbContextOptionsBuilder<UndergroundStationDbContext>()
                .UseInMemoryDatabase("UndergroundStationTestDb")
                .Options;

            var db = new UndergroundStationDbContext(dbOptions);

            var articleService = new ArticleService(db);

            await db.SaveChangesAsync();

            //Act
            var success = await articleService
                .CreateAsync("Title", "Content", "1", 2, DateTime.UtcNow, 1);

            //Assert
            success
             .Should()
             .Equals(true);
        }

        [Fact]
        public async Task ByThemeIdAsyncShouldReturnCorrectAnswerAndOrderCorrectly()
        {
            //Arrange
            var dbOptions = new DbContextOptionsBuilder<UndergroundStationDbContext>()
                .UseInMemoryDatabase("UndergroundStationTestDb")
                .Options;

            var db = new UndergroundStationDbContext(dbOptions);

            var articleService = new ArticleService(db);

            var firstArticle = new ForumArticle
            {
                Id = 2,
                PublishedDate = DateTime.UtcNow,
                ForumThemeId = 1
            };

            var secondArticle = new ForumArticle
            {
                Id = 3,
                PublishedDate = DateTime.UtcNow.AddDays(-1),
                ForumThemeId = 1
            };

            var thirdArticle = new ForumArticle
            {
                Id =4,
                PublishedDate = DateTime.UtcNow,
                ForumThemeId = 2
            };

            db.AddRange(firstArticle, secondArticle, thirdArticle);

            await db.SaveChangesAsync();

            //Act
            var result = await articleService.ByThemeIdAsync(1, 1);

            //Assert
            result
               .Should()
               .Match
               (r => r.ElementAt(0).Id == 3
               && r.ElementAt(1).Id == 2)
               .And
               .HaveCount(2);
        }

        [Fact]
        public async Task TotalByTypeAsyncShouldRerutnCorectInteger()
        {
            //Arrange
            var dbOptions = new DbContextOptionsBuilder<UndergroundStationDbContext>()
                .UseInMemoryDatabase("UndergroundStationTestDb")
                .Options;

            var db = new UndergroundStationDbContext(dbOptions);

            var articleService = new ArticleService(db);

            //Act
            var result = await articleService.TotalByThemeIdAsync(1);

            //Assert
            result
                .Should()
                .Equals(2);
        }
    }
}
