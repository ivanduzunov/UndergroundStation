namespace UndergroundStation.Web.Areas.Forum.Models.Themes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    using static Data.DataConstants;

    public class ThemeCreateFormModel
    {
        [Required]
        [MinLength(ForumThemeTitleMinLenght)]
        [MaxLength(ForumThemeTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MinLength(ForumThemeDescriptionMinLenght)]
        [MaxLength(ForumThemeDescriptionMaxLenght)]
        public string Description { get; set; }

        public int ForumSectionId { get; set; }

        public ForumSection ForumSection { get; set; }

        public string CreatorId { get; set; }

        public User Creator { get; set; }

        public DateTime PublishedDate { get; set; }
    }
}
