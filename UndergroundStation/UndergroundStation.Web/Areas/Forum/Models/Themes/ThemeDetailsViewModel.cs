namespace UndergroundStation.Web.Areas.Forum.Models.Themes
{
    using System;
    using System.Collections.Generic;
    using Services.Forum.Models;

    using static Services.ServiceConstants;

    public class ThemeDetailsViewModel
    {
        public ThemeDetailsServiceModel ThemeDetails { get; set; }

        public IEnumerable<ArticleListingServiceModel> Articles { get; set; }

        public int TotalArticles { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalArticles / ForumArticlesPageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages
                ? this.TotalPages
                : this.CurrentPage + 1;
    }
}
