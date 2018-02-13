namespace UndergroundStation.Services.Forum.Models
{
    using System.Collections.Generic;
    using Data.Models;
    using Common.Mapping;

    public class SectionListingServiceModel : IMapFrom<ForumSection>
    {
        public int Id { get; set; }

        public string Tittle { get; set; }

        public string Description { get; set; }

        public List<ForumTheme> Themes { get; set; } = new List<ForumTheme>();
    }
}
