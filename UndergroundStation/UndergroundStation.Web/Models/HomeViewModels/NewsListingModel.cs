namespace UndergroundStation.Web.Models.HomeViewModels
{
    using System.Collections.Generic;
    using Services.Models;

    public class NewsListingModel
    {
        public IEnumerable<NewsListingServiceModel> News { get; set; }
    }
}
