namespace UndergroundStation.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using UndergroundStation.Web.Models;
    using UndergroundStation.Services;
    using System.Threading.Tasks;
    using Models.HomeViewModels;

    public class HomeController : Controller
    {
        private readonly INewsService news;

        public HomeController(INewsService news)
        {
            this.news = news;
        }

        public async Task<IActionResult> Index()
        {
            var newsList = await news.AllHomeNewsAsync();

            return View(new NewsListingModel
            {
                News = newsList
            });
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }  
}

