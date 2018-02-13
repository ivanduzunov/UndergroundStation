namespace UndergroundStation.Web.Areas.Forum.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Services.Forum;
    using Models.Themes;

    using static WebConstants;

    [Area(ForumArea)]
    public class ThemesController : Controller
    {
        private readonly IThemesService themes;
        private readonly IArticleService articles;

        public ThemesController
            (IThemesService themes,
            IArticleService articles)
        {
            this.themes = themes;
            this.articles = articles;
        }

        [Authorize]
        public async Task<IActionResult> Details(string themeId, string page)
        {
            int id = int.Parse(themeId);
            int pageNum = int.Parse(page);

            var theme = new ThemeDetailsViewModel
            {
                ThemeDetails = await this.themes.ById(id),
                Articles = await this.articles.ByThemeIdAsync(id, pageNum),
                TotalArticles = await this.articles.TotalByThemeIdAsync(id),
                CurrentPage = pageNum
            };

            return View(theme);
        }

        [HttpPost]
        [Authorize(Roles = ForumModeratorRole)]
        public async Task<IActionResult> DeleteTheme(string themeId, string sectionId)
        {
            if (themeId == null || sectionId == null)
            {
                return NotFound();
            }

            var success = await this.themes.DeleteTheme(themeId);

            if (!success)
            {
                return BadRequest();
            }

            return RedirectToAction
                ("Details", "Sections", new { area = "Forum", id = int.Parse(sectionId)});
        }
    }
}