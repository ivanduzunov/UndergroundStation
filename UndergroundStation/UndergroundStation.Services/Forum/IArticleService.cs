namespace UndergroundStation.Services.Forum
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IArticleService
    {
        Task<bool> CreateAsync(string title, string content, string authorId, int forumThemeId, DateTime publishedDate, int motherArticleId);

        Task<bool> CreateAnswerAsync(string title, string content, string authorId, DateTime publishedDate, int motherArticleId);

        Task<IEnumerable<ArticleListingServiceModel>> ByThemeIdAsync(int themeId, int page);

        Task<int> TotalByThemeIdAsync(int themeId);

        Task<bool> DeleteArticleAsync(string articleId);
    }
}
