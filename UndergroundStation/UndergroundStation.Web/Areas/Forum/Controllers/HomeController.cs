namespace UndergroundStation.Web.Areas.Forum.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Services.Forum;

    using static WebConstants;

    [Area(ForumArea)]
    public class HomeController : Controller
    {
        private readonly ISectionsService sections;

        public HomeController(ISectionsService sections)
        {
            this.sections = sections;
        }

        [Authorize]
        public async Task<IActionResult> Index()
            => View(await sections.AllAsync());

    }
}