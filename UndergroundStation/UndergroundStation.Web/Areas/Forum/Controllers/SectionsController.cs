namespace UndergroundStation.Web.Areas.Forum.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Services.Forum;
    using Models.Sections;
    using Infrastructure.Extentions;
    using Microsoft.AspNetCore.Identity;
    using Models.Themes;
    using Data.Models;

    using static WebConstants;

    [Area(ForumArea)]
    public class SectionsController : Controller
    {
        private readonly ISectionsService sections;
        private readonly IThemesService themes;
        private readonly UserManager<User> userManager;

        public SectionsController
            (ISectionsService sections,
            IThemesService themes,
            UserManager<User> userManager)
        {
            this.sections = sections;
            this.themes = themes;
            this.userManager = userManager;
        }

        [Authorize(Roles = ForumModeratorRole)]
        public IActionResult Create()
           => View();

        [Authorize(Roles = ForumModeratorRole)]
        [HttpPost]
        public async Task<IActionResult> Create(SectionCreateFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (model.Description == null || model.Title == null)
            {
                return BadRequest();
            }

            var success = await sections.Create(model.Title, model.Description);

            if (!success)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage($"Article {model.Title} successfully published.");

            return Redirect("/Forum/Home/Index");
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {

            var secDetails = await this.sections.ByIdAsync(id);

            var themes = await this.themes.BySectionIdAsync(id);

            var section = 
                new SectionsDetailsViewModel
            {
                SectionDetails = secDetails,
                Themes = themes
            };

            return View(section);
        }

        [Authorize]
        public async Task< IActionResult> AddTheme(int id)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);

            if (user.Id == null)
            {
                return NotFound();
            }

            var model = new ThemeCreateFormModel
            {
                PublishedDate = DateTime.UtcNow,
                CreatorId = user.Id,
                ForumSectionId = id
            };
           

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddTheme(ThemeCreateFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var success = await themes.CreateThemeAsync
                (model.Title,
                 model.Description,
                 model.CreatorId,
                 model.ForumSectionId,
                 model.PublishedDate);

            if (!success)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage($"Theme {model.Title} successfully published.");

            return Redirect($"/forum/sections/details/{model.ForumSectionId}");
        }

    }
}
