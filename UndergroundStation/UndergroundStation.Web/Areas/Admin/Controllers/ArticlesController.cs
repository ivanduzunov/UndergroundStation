namespace UndergroundStation.Web.Areas.Admin.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Infrastructure.Extentions;
    using Services.Admin;

    public class ArticlesController : BaseAdminController
    {
        private readonly IAdminArticleService articles;

        public ArticlesController(IAdminArticleService articles)
        {
            this.articles = articles;
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComment(string commentId, string articleId)
        {
            if (!ModelState.IsValid || commentId == null || articleId == null)
            {
                return NotFound();
            }

            var success = await this.articles.DeleteComment(commentId);

            if (!success)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage($"Comment deleted successfully!");

            return RedirectToAction("Details", "Articles", new { area = "" , id = int.Parse(articleId) } );
        }
    }
}