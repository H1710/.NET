using SalesWebAPI.Controllers.Requests;
using SalesWebAPI.Models;

namespace SalesWebAPI.Services
{
    public interface ISellerService
    {
        Task<IEnumerable<Seller>> GetAllSellersAsync();
        Task<Seller> GetSellerByIdAsync(int id);
        Task AddSellerAsync(CreateSellerRequest seller);
        Task UpdateSellerAsync(Seller seller);
        Task DeleteSellerAsync(int id);
    }

}
