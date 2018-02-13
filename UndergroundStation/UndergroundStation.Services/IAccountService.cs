namespace UndergroundStation.Services
{
    using System.Threading.Tasks;
    using Models;

    public interface IAccountService
    {
        Task<AccountProfileServiceModel> ProfileByUsername(string username);
    }
}
