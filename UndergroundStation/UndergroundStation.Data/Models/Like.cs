namespace UndergroundStation.Data.Models
{
    public class Like
    {
        public int Id { get; set; }

        public User User { get; set; }

        public string UserId { get; set; }

        public NewsArticle NewsArticle { get; set; }

        public int? NewsArticleId { get; set; }

        public ForumArticle ForumArtcle { get; set; }

        public int? ForumArticleId { get; set; }

        public bool IsLiked { get; set; }
    }
}
