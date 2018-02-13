namespace UndergroundStation.Services.Forum
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IThemesService
    {
        Task <bool> CreateThemeAsync(string title, string description, string creatorId, int forumSectionId, DateTime publishedDate);

        Task<IEnumerable<ThemeListingServiceModel>> BySectionIdAsync(int sectonId);

        Task<ThemeDetailsServiceModel> ById(int id);

        Task<bool> DeleteTheme(string themeId);
    }
}
