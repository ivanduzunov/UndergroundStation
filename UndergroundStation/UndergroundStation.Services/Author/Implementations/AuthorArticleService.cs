namespace UndergroundStation.Services.Author.Implementations
{
    using System;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using System.Linq;

    public class AuthorArticleService : IAuthorArticleService
    {
        private readonly UndergroundStationDbContext db;

        public AuthorArticleService(UndergroundStationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> CreateAsync
            (string title,
            string content,
            string imageUrl,
            string videoUrl,
            ArticleType type)
        {

            if (title == null 
                || content == null 
                || imageUrl == null)
            {
                return false;
            }

            var article = new NewsArticle
            {
                Title = title,
                Content = content,
                ImageUrl = imageUrl,
                VideoUrl = "https://www.youtube.com/embed/" + videoUrl, //this is just the id of the youtubeVideo
                ArticleType = type,
                PublishedDate = DateTime.UtcNow
            };

            this.db.NewsArticles.Add(article);

            await this.db.SaveChangesAsync();

            return true;
        }

    }
}
