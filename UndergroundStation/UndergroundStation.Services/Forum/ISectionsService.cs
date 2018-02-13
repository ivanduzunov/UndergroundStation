namespace UndergroundStation.Services.Forum
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public  interface ISectionsService
    {
        Task<IEnumerable<SectionListingServiceModel>> AllAsync();

        Task<SectionDetailsServiceModel> ByIdAsync(int id);

        Task <bool> Create(string title, string description);
    }
}
