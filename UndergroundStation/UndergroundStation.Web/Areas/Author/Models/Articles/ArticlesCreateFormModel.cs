namespace UndergroundStation.Web.Areas.Author.Models.Articles
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data.Models.Enums;

    using static Data.DataConstants;

    public class ArticlesCreateFormModel
    {
        [Required]
        [MinLength(NewsArticleTitleMinLenght)]
        [MaxLength(NewsArticleTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MinLength(NewsArticleContentMinLenght)]
        [MaxLength(NewsArticleContentMaxLenght)]
        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public ArticleType Type { get; set; }

        [Display(Name = "YouTube Id")]
        public string VideoUrl { get; set; }
    }
}
