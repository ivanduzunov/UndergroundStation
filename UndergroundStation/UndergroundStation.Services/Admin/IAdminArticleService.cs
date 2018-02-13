namespace UndergroundStation.Services.Admin
{
    using System.Threading.Tasks;

    public interface IAdminArticleService
    {
        Task<bool> DeleteComment(string commentId);
    }
}
