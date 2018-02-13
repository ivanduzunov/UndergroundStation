namespace UndergroundStation.Services.Forum.Models
{
    using System;
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;

    public class ThemeDetailsServiceModel : IMapFrom<ForumTheme> , IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ForumSectionTitle { get; set; }

        public int ForumSectionId { get; set; }

        public string CreatorName { get; set; }

        public DateTime PublishedDate { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                  .CreateMap<ForumTheme, ThemeDetailsServiceModel>()
                  .ForMember(c => c.ForumSectionTitle, cfg => cfg.MapFrom(c => c.ForumSection.Tittle))
                  .ForMember(c => c.ForumSectionId, cfg => cfg.MapFrom(c => c.ForumSection.Id))
                  .ForMember(c => c.CreatorName, cfg => cfg.MapFrom(c => c.Creator.UserName));
        }
    }
}
