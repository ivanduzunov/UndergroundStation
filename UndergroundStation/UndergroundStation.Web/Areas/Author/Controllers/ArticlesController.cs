namespace UndergroundStation.Web.Areas.Author.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using UndergroundStation.Web.Infrastructure.Extentions;
    using Models.Articles;
    using Services.Author;

    using static WebConstants;

    [Area(AuthorArea)]
    [Authorize(Roles = AuthorRole)]
    public class ArticlesController : Controller
    {
        private readonly IAuthorArticleService articles;

        public ArticlesController(IAuthorArticleService articles)
        {
            this.articles = articles;
        }

        public IActionResult Create()
           => View();

        [HttpPost]
        public async Task<IActionResult> Create(ArticlesCreateFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

           var success =  await articles
                .CreateAsync(model.Title,
                  model.Content,
                  model.ImageUrl,
                  model.VideoUrl,
                  model.Type);

            if (!success)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage($"Article {model.Title} successfully published.");

            return this.Redirect("/articles/All");
        }
    }
}