namespace UndergroundStation.Services.Models
{
    using System;
    using System.Collections.Generic;
    using UndergroundStation.Common.Mapping;
    using UndergroundStation.Data.Models;

    public class CommentsListingServiceModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime PublishedDate { get; set; }

        public string  AuthorUserName { get; set; }

        public int? MotherCommentId { get; set; }

        public Comment MotherComment { get; set; }

        public List<CommentsListingServiceModel> Answers { get; set; } = new List<CommentsListingServiceModel>();
    }
}
