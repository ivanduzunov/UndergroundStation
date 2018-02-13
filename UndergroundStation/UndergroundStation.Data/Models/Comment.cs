namespace UndergroundStation.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    using static DataConstants;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MinLength(CommentTitleMinLenght)]
        [MaxLength(CommentTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MinLength(CommentContentMinLenght)]
        [MaxLength(CommentContentMaxLenght)]
        public string Content { get; set; }

        public DateTime PublishedDate { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public int? NewsArticleId { get; set; }

        public NewsArticle NewsArticle { get; set; }

        public int? MotherCommentId { get; set; }

        public Comment  MotherComment { get; set; }

        public bool  IsDeleted { get; set; }

        public List<Comment> Answers { get; set; } = new List<Comment>();
    }
}
