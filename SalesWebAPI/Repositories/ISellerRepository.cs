using SalesWebAPI.Models;

namespace SalesWebAPI.Repositories
{
    public interface ISellerRepository
    {
        Task<IEnumerable<Seller>> GetAllAsync();
        Task<Seller> GetByIdAsync(int id);
        Task AddAsync(Seller seller);
        Task UpdateAsync(Seller seller);
        Task DeleteAsync(int id);
    }

}
