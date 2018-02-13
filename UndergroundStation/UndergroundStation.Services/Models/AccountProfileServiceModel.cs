namespace UndergroundStation.Services.Models
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;

    public class AccountProfileServiceModel : IMapFrom<User>, IHaveCustomMapping
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public int CommentsCount { get; set; }

        public int ForumThemesCount { get; set; }

        public int ForumArticlesCount { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                   .CreateMap<User, AccountProfileServiceModel>()
                   .ForMember(c => c.CommentsCount, cfg => cfg.MapFrom(c => c.Comments.Count))
                   .ForMember(c => c.ForumThemesCount, cfg => cfg.MapFrom(c => c.ForumThemes.Count))
                   .ForMember(c => c.ForumArticlesCount, cfg => cfg.MapFrom(c => c.ForumArticles.Count));
        }
    }
}
