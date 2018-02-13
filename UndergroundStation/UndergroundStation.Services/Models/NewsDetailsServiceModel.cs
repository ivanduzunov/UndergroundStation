namespace UndergroundStation.Services.Models
{
    using System;
    using System.Collections.Generic;
    using Data.Models;
    using Common.Mapping;
    using Data.Models.Enums;
    using AutoMapper;

    public class NewsDetailsServiceModel : IMapFrom<NewsArticle>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public string VideoUrl { get; set; }

        public DateTime PublishedDate { get; set; }

        public bool IsLiked { get; set; }

        public string ArticleType { get; set; }

        public List<CommentsListingServiceModel> Comments { get; set; } = new List<CommentsListingServiceModel>();

        public List<Like> Likes { get; set; } = new List<Like>();

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                   .CreateMap<NewsArticle, NewsDetailsServiceModel>()
                   .ForMember(c => c.ArticleType, cfg => cfg.MapFrom(c => c.ArticleType.ToString()));

            mapper
                 .CreateMap<Comment, CommentsListingServiceModel>()
                 .ForMember(c => c.AuthorUserName, cfg => cfg.MapFrom(c => c.Author.UserName));
        }
    }
}
