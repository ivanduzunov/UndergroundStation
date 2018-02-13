namespace UndergroundStation.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface INewsService
    {
        Task<IEnumerable<NewsListingServiceModel>> AllHomeNewsAsync();

        Task<IEnumerable<NewsListingServiceModel>> AllAsync(int page = 1);

        Task<IEnumerable<NewsListingServiceModel>> AllByTypeAsync(string articleType, int page);

        Task<int> TotalAsync();

        Task<int> TotalByTypeAsync(string articleType);

        NewsDetailsServiceModel ByIdAsync(int id);

        Task<bool> AddUnlikeAsync(int articleId, string userId);

        Task<bool> AddLikeAsync(int articleId, string userId);

        Task<bool> AddCommentByArticleAsync(string comment, int id, string userId);

        Task<bool> AddCommentByCommentAsync(string answer, int id, string userId);
    }
}
