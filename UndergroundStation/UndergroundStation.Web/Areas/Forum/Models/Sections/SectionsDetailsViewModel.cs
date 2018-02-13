namespace UndergroundStation.Web.Areas.Forum.Models.Sections
{
    using Services.Forum.Models;
    using System.Collections.Generic;

    public class SectionsDetailsViewModel
    {
        public SectionDetailsServiceModel SectionDetails { get; set; }

        public IEnumerable<ThemeListingServiceModel> Themes { get; set; }
    }
}
