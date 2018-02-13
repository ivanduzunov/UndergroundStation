namespace UndergroundStation.Web.Areas.Forum.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Infrastructure.Extentions;
    using Microsoft.AspNetCore.Routing;
    using Data.Models;
    using Models.Articles;
    using Services.Forum;

    using static WebConstants;


    [Area(ForumArea)]
    public class ArticlesController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IArticleService articles;

        public ArticlesController
            (UserManager<User> userManager,
            IArticleService articles)
        {
            this.userManager = userManager;
            this.articles = articles;
        }

        [Authorize]
        public async Task<IActionResult> Create(int id)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return NotFound();
            }

            var model = new ArticlesCreateFormModel
            {
                AuthorId = user.Id,
                ForumThemeId = id,
                PublishedDate = DateTime.UtcNow
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create
            (ArticlesCreateFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var success = await this.articles.CreateAsync
                (model.Title,
                model.Content,
                model.AuthorId,
                model.ForumThemeId,
                model.PublishedDate,
                model.MotherArticleId);

            if (!success)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage($"Article {model.Title} successfully published.");

            return RedirectToAction("Details", "Themes", 
                new RouteValueDictionary(
                new {
                      themeId = model.ForumThemeId.ToString(),
                      page = "1",
                    }));
        }

        [Authorize]
        public async Task<IActionResult> CreateAnswer(string themeId, string articleId, string title)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return NotFound();
            }

            var model = new AnswerCreateFormModel
            {
               Title = title,
               AuthorId = user.Id,
               ForumThemeId = int.Parse(themeId),
               MotherArticleId = int.Parse(articleId),
               PublishedDate = DateTime.UtcNow
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateAnswer
            (AnswerCreateFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var success = await this.articles.CreateAnswerAsync
                (model.Title,
                model.Content,
                model.AuthorId,
                model.PublishedDate,
                model.MotherArticleId);

            if (!success)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage($"Answer {model.Title} successfully published.");

            return RedirectToAction("Details", "Themes",
               new RouteValueDictionary(
               new
               {
                   themeId = model.ForumThemeId.ToString(),
                   page = "1",
               }));
        }

        [HttpPost]
        [Authorize(Roles = ForumModeratorRole)]
        public async Task<IActionResult> DeleteArticle(string articleId, string themeId)
        {
            if (articleId == null || themeId == null)
            {
                return NotFound();
            }

            var success = await this.articles.DeleteArticleAsync(articleId);

            if (!success)
            {
                return BadRequest();
            }

            return RedirectToAction
                ("Details", "Themes", new { area = "Forum", themeId = int.Parse(themeId), page = 1 });
        }
    }
}