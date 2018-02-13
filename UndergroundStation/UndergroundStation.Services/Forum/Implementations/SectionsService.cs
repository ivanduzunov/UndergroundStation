namespace UndergroundStation.Services.Forum.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using Models;
    using Data;
    using Data.Models;

    public class SectionsService : ISectionsService
    {
        private readonly UndergroundStationDbContext db;

        public SectionsService(UndergroundStationDbContext db)
        {
            this.db = db;
        }


        public async Task<IEnumerable<SectionListingServiceModel>> AllAsync()
             => await this.db
                .ForumSections
                .OrderBy(fs => fs.Tittle)
                .ProjectTo<SectionListingServiceModel>()
                .ToListAsync();

        public async Task<SectionDetailsServiceModel> ByIdAsync(int id)
              =>  await this.db.ForumSections
                .Where(s => s.Id == id)
                .ProjectTo<SectionDetailsServiceModel>()
                .FirstOrDefaultAsync();

           
        public async Task<bool> Create(string title, string description)
        {
            if (title == null || description == null)
            {
                return false;
            }

            var section = new ForumSection
            {
                Tittle = title,
                Description = description
            };

            db.Add(section);

            await db.SaveChangesAsync();

            return true;
        }
    }
}
