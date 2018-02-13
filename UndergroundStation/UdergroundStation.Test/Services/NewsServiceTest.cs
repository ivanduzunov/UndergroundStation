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
    using Data.Models.Enums;

    public class NewsServiceTest
    {
        public NewsServiceTest()
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

            var newsService = new NewsService(db);

            var firstNewsArticle = new NewsArticle
            {
                Id = 1,
                Title = "First Article",
                PublishedDate = DateTime.UtcNow.AddDays(-1),
                ArticleType = ArticleType.Interviews
            };

            var secondNewsArticle = new NewsArticle
            {
                Id = 2,
                Title = "Second Article",
                PublishedDate = DateTime.UtcNow.AddHours(1),
                ArticleType = ArticleType.Interviews
            };

            var thirdNewsArticle = new NewsArticle
            {
                Id = 3,
                Title = " Third Article",
                PublishedDate = DateTime.UtcNow,
                ArticleType = ArticleType.History
            };

            db.AddRange(firstNewsArticle, secondNewsArticle, thirdNewsArticle);

            await db.SaveChangesAsync();
            //Act
            var result = await newsService.AllHomeNewsAsync();


            //Assert
            result
                .Should()
                .Match
                (r => r.ElementAt(0).Id == 2
                && r.ElementAt(1).Id == 3
                && r.ElementAt(2).Id == 1)
                .And
                .HaveCount(3);
        }

        [Fact]
        public async Task AllAsyncShouldRerutnCorectedOrderedNewsArticles()
        {
            //Arrange
            var dbOptions = new DbContextOptionsBuilder<UndergroundStationDbContext>()
                .UseInMemoryDatabase("UndergroundStationTestDb")
                .Options;

            var db = new UndergroundStationDbContext(dbOptions);

            var newsService = new NewsService(db);

            //Act
            var result = await newsService.AllAsync(1);


            //Assert
            result
                .Should()
                .Match
                (r => r.ElementAt(0).Id == 2
                && r.ElementAt(1).Id == 3
                && r.ElementAt(2).Id == 1)
                .And
                .HaveCount(3);
        }

        [Fact]
        public async Task AllByTypeAsyncShouldRerutnCorectedOrderedAndCorectTypeNewsArticles()
        {
            //Arrange
            var dbOptions = new DbContextOptionsBuilder<UndergroundStationDbContext>()
                .UseInMemoryDatabase("UndergroundStationTestDb")
                .Options;

            var db = new UndergroundStationDbContext(dbOptions);

            var newsService = new NewsService(db);
         
            //Act
            var result = await newsService.AllByTypeAsync(ArticleType.Interviews.ToString(), 1);

            //Assert
            result
                .Should()
                .Match
                (r => r.ElementAt(0).Id == 2
                && r.ElementAt(1).Id == 1)
                .And
                .HaveCount(2);
        }

        [Fact]
        public async Task TotalAsyncShouldRerutnCorectInteger()
        {
            //Arrange
            var dbOptions = new DbContextOptionsBuilder<UndergroundStationDbContext>()
                .UseInMemoryDatabase("UndergroundStationTestDb")
                .Options;

            var db = new UndergroundStationDbContext(dbOptions);

            var newsService = new NewsService(db);

            //Act
            var result = await newsService.TotalAsync();

            //Assert
            result
                .Should()
                .Equals(3);
        }

        [Fact]
        public async Task TotalByTypeAsyncShouldRerutnCorectInteger()
        {
            //Arrange
            var dbOptions = new DbContextOptionsBuilder<UndergroundStationDbContext>()
                .UseInMemoryDatabase("UndergroundStationTestDb")
                .Options;

            var db = new UndergroundStationDbContext(dbOptions);

            var newsService = new NewsService(db);

            //Act
            var result = await newsService.TotalByTypeAsync(ArticleType.Interviews.ToString());

            //Assert
            result
                .Should()
                .Equals(2);
        }

        [Fact]
        public async Task ByIdAsyncShouldRerutnCorectEntity()
        {
            //Arrange
            var dbOptions = new DbContextOptionsBuilder<UndergroundStationDbContext>()
                .UseInMemoryDatabase("UndergroundStationTestDb")
                .Options;

            var db = new UndergroundStationDbContext(dbOptions);

            var newsService =  new NewsService(db);

            //Act
            var result = newsService.ByIdAsync(1);

            //Assert
            result.Id
                .Should()
                .Equals(1);
        }
    }
}
