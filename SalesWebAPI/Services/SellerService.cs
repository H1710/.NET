using SalesWebAPI.Models;
using SalesWebAPI.Repositories;

namespace SalesWebAPI.Services
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _repository;

        public SellerService(ISellerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Seller>> GetAllSellersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Seller> GetSellerByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddSellerAsync(Seller seller)
        {
            await _repository.AddAsync(seller);
        }

        public async Task UpdateSellerAsync(Seller seller)
        {
            await _repository.UpdateAsync(seller);
        }

        public async Task DeleteSellerAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
