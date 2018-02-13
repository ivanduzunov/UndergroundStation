namespace UndergroundStation.Web.Areas.Forum.Models.Articles
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    using static Data.DataConstants;

    public class ArticlesCreateFormModel
    {
        [Required]
        [MinLength(ForumArticleTitleMinLenght)]
        [MaxLength(ForumArticleTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MinLength(ForumArticleContentMinLenght)]
        [MaxLength(ForumArticleContentMaxLenght)]
        public string Content { get; set; }

        public DateTime PublishedDate { get; set; }

        public int MotherArticleId { get; set; }

        public string AuthorId { get; set; }

        public int ForumThemeId { get; set; }
    }
}
