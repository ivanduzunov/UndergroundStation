namespace UndergroundStation.Services.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;

    public class AccountService : IAccountService
    {
        private readonly UndergroundStationDbContext db;

        public AccountService(UndergroundStationDbContext db)
        {
            this.db = db;
        }

        public async Task<AccountProfileServiceModel> ProfileByUsername(string username)
        {
            var user = await this.db
                .Users
                .Where(u => u.UserName == username)
                .ProjectTo<AccountProfileServiceModel>()
                .FirstOrDefaultAsync();

            var userId = this.db
                .Users
                .Where(u => u.UserName == username)
                .Select(u => u.Id)
                .FirstOrDefault()
                .ToString();

            var roleId = await this.db
                .UserRoles
                .Where(ur => ur.UserId == userId)
                .Select(r => r.RoleId)
                .FirstOrDefaultAsync();

            if (roleId != null)
            {
                var roleName = await this.db.Roles
                    .Where(r => r.Id == roleId)
                    .Select(r => r.Name)
                    .FirstOrDefaultAsync();

                user.Role = roleName;
            }

            return  user;
        }
    }
}
