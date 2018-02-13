namespace UndergroundStation.Services.Models
{
    using System;
    using System.Collections.Generic;
    using UndergroundStation.Common.Mapping;
    using Data.Models;
    using Data.Models.Enums;
    using AutoMapper;

    public class NewsListingServiceModel : IMapFrom<NewsArticle>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string ArticleType { get; set; }

        public DateTime PublishedDate { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                  .CreateMap<NewsArticle, NewsListingServiceModel>()
                  .ForMember(c => c.ArticleType, cfg => cfg.MapFrom(c => c.ArticleType.ToString()));
        }
    }
}
