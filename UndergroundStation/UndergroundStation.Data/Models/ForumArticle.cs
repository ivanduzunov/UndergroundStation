namespace UndergroundStation.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class ForumArticle
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ForumArticleTitleMinLenght)]
        [MaxLength(ForumArticleTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MinLength(ForumArticleContentMinLenght)]
        [MaxLength(ForumArticleContentMaxLenght)]
        public string Content { get; set; }

        public DateTime PublishedDate { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public int? ForumThemeId { get; set; }

        public ForumTheme ForumTheme { get; set; }

        public int? MotherArticleId { get; set; }

        public ForumArticle MotherArticle { get; set; }

        public bool IsDeleted { get; set; }

        public List<ForumArticle> Answers { get; set; } = new List<ForumArticle>();

        public List<Like> Likes { get; set; } = new List<Like>();
    }
}
