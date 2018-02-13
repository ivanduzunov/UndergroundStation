namespace UndergroundStation.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class ForumSection
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ForumSectionTitleMinLenght)]
        [MaxLength(ForumSectionTitleMaxLenght)]
        public string Tittle { get; set; }

        [Required]
        [MinLength(ForumSectionDescriptionMinLenght)]
        [MaxLength(ForumSectionDescriptionMaxLenght)]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public List<ForumTheme> Themes { get; set; } = new List<ForumTheme>();
    }
}
