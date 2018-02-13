namespace UndergroundStation.Web.Models.ArticleViewModels
{
    using System;
    using System.Collections.Generic;
    using Services.Models;

    using static Services.ServiceConstants;

    public class NewsListingViewModelByType
    {
        public IEnumerable<NewsListingServiceModel> News { get; set; }

        public int TotalArticles { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalArticles / NewsArticlesPageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages
                ? this.TotalPages
                : this.CurrentPage + 1;

        public string articleTypeDescription { get; set; }
    }
}
