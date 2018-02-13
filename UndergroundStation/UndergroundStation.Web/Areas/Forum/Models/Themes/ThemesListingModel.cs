namespace UndergroundStation.Web.Areas.Forum.Models.Themes
{
    using System.Collections.Generic;
    using Services.Forum.Models;

    public class ThemesListingModel
    {
        public IEnumerable<ThemeListingServiceModel> Themes { get; set; }

        public string SectionName { get; set; }
    }
}
