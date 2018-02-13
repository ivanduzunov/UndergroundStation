namespace UndergroundStation.Services.Forum.Models
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System.Linq;

    public class ThemeListingServiceModel : IMapFrom<ForumTheme>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string CreatorName { get; set; }

        public DateTime PublishedDate { get; set; }

        public bool IsDeleted { get; set; }

        public int ArticlesCount { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                   .CreateMap<ForumTheme, ThemeListingServiceModel>()
                    .ForMember(t => t.ArticlesCount, cfg => cfg.MapFrom(c => c.Articles.Where(a => a.IsDeleted == false).Count()))
                    .ForMember(t => t.CreatorName, cfg => cfg.MapFrom(c => c.Creator.UserName));
        }
    }
}
