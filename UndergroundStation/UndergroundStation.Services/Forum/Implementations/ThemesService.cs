namespace UndergroundStation.Services.Forum.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using Models;
    using Data;
    using Data.Models;
    using System;

    public class ThemesService : IThemesService
    {
        private readonly UndergroundStationDbContext db;

        public ThemesService(UndergroundStationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> CreateThemeAsync
           (string title,
            string description,
            string creatorId,
            int forumSectionId,
            DateTime publishedDate)
        {
            if (title == null
                || description == null
                || creatorId == null
                || forumSectionId == 0
                || publishedDate == null)
            {
                return false;
            }

            var theme = new ForumTheme
            {
                Title = title,
                Description = description,
                Creator = this.db.Users.Where(u => u.Id == creatorId).FirstOrDefault(),
                ForumSection = this.db.ForumSections.Where(fs => fs.Id == forumSectionId).FirstOrDefault(),
                PublishedDate = publishedDate
            };

            this.db.Add(theme);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<ThemeDetailsServiceModel> ById(int id)
           => await this.db.ForumThemes
                .Where(ft => ft.Id == id && ft.IsDeleted == false)
                .ProjectTo<ThemeDetailsServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<ThemeListingServiceModel>> BySectionIdAsync(int sectonId)
         => await this.db.ForumThemes
              .Where(t => t.ForumSectionId == sectonId && t.IsDeleted == false)
              .OrderBy(t => t.PublishedDate)
              .ThenBy(t => t.PublishedDate.TimeOfDay)
              .ProjectTo<ThemeListingServiceModel>()
              .ToListAsync();

        public async Task<bool> DeleteTheme(string themeId)
        {
            var id = int.Parse(themeId);

            var theme = await this.db.ForumThemes
                         .Where(t => t.Id == id)
                         .FirstOrDefaultAsync();

            if (theme == null)
            {
                return false;
            }

            theme.IsDeleted = true;

            await this.db.SaveChangesAsync();

            return true;
        }


    }
}
