namespace UndergroundStation.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public List<Like> Likes { get; set; } = new List<Like>();

        public List<ForumTheme> ForumThemes { get; set; } = new List<ForumTheme>();

        public List<ForumArticle> ForumArticles { get; set; } = new List<ForumArticle>();

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
