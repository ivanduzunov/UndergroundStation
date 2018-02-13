namespace UndergroundStation.Web.Areas.Forum.Models.Sections
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using Data.Models;

    using static Data.DataConstants;

    public class SectionCreateFormModel
    {
        [Required]
        [MinLength(ForumSectionTitleMinLenght)]
        [MaxLength(ForumSectionTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MinLength(ForumSectionDescriptionMinLenght)]
        [MaxLength(ForumSectionDescriptionMaxLenght)]
        public string Description { get; set; }
    }
}
