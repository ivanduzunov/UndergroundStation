namespace UndergroundStation.Services.Forum.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using Data;
    using Data.Models;
    using Models;

    using static ServiceConstants;

    public class ArticleService : IArticleService
    {
        private readonly UndergroundStationDbContext db;

        public ArticleService(UndergroundStationDbContext db)
        {
            this.db = db;
        }


        public async Task<bool> CreateAsync
            (string title,
            string content,
            string authorId,
            int forumThemeId,
            DateTime publishedDate,
            int motherArticleId)
        {
            if (content == null || title == null)
            {
                return false;
            }


            var article = new ForumArticle
            {
                Title = title,
                Content = content,
                AuthorId = authorId,
                ForumThemeId = forumThemeId,
                PublishedDate = publishedDate
            };

            this.db.Add(article);

            await this.db.SaveChangesAsync();


            return true;
        }

        public async Task<bool> CreateAnswerAsync
            (string title,
            string content,
            string authorId,
            DateTime publishedDate,
            int motherArticleId)
        {
            if (content == null || motherArticleId == 0)
            {
                return false;
            }

            var article = new ForumArticle
            {
                Title = "Re: " + title,
                Content = content,
                AuthorId = authorId,
                MotherArticleId = motherArticleId,
                PublishedDate = publishedDate
            };

            this.db.Add(article);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ArticleListingServiceModel>> ByThemeIdAsync(int themeId, int page)
         => await this.db
                 .ForumArticles
                 .Where(fa => fa.ForumThemeId == themeId && fa.IsDeleted == false)
                 .OrderBy(a => a.PublishedDate)
                 .ThenBy(a => a.PublishedDate.TimeOfDay)
                 .Skip((page - 1) * ForumArticlesPageSize)
                 .Take(NewsArticlesPageSize)
                 .ProjectTo<ArticleListingServiceModel>()
                 .ToListAsync();


        public async Task<int> TotalByThemeIdAsync(int themeId)
        => await this.db
            .ForumArticles
            .Where(fa => fa.ForumThemeId == themeId && fa.IsDeleted == false)
            .CountAsync();

        public async Task<bool> DeleteArticleAsync(string articleId)
        {
            int id = int.Parse(articleId);

            var article = await this.db
                            .ForumArticles
                            .Where(fm => fm.Id == id)
                            .FirstOrDefaultAsync();

            if (article == null)
            {
                return false;
            }

            article.IsDeleted = true;

            await this.db.SaveChangesAsync();

            return true;
        }
    }
}
