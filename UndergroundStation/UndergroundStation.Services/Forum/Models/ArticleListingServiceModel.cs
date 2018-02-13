namespace UndergroundStation.Services.Forum.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;

    public class ArticleListingServiceModel : IMapFrom<ForumArticle>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishedDate { get; set; }

        public string authorUserName { get; set; }

        public List<ArticleListingServiceModel> Answers { get; set; } = new List<ArticleListingServiceModel>();

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                   .CreateMap<ForumArticle, ArticleListingServiceModel>()
                   .ForMember(c => c.authorUserName, cfg => cfg.MapFrom(c => c.Author.UserName))
                   .ForMember(c => c.Answers, cfg => cfg.MapFrom(c => c.Answers.Where(a => a.IsDeleted == false)));
        }
    }
}
