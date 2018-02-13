using System.ComponentModel;

namespace UndergroundStation.Data.Models.Enums
{
    public enum ArticleType
    {
        [Description("New Albums - New albums news")]
        NewAlbums = 0,
        [Description("Concerts - Upcoming shows and concerts reports")]
        Concerts = 1,
        [Description("Album Reviews - New and Classical album reviews")]
        AlbumReviews = 3,
        [Description("Interviews - Interviews with the artists or people related to the Underground scene worldwide")]
        Interviews = 4,
        [Description("History")]
        History = 5,
    }
}
