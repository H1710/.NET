using SalesWebAPI.Controllers.Requests;
using SalesWebAPI.Models;
using SalesWebAPI.Repositories;

namespace SalesWebAPI.Services
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _repository;
        private readonly IDepartamentRepository _departmentRepository;

        public SellerService(ISellerRepository repository, IDepartamentRepository departmentRepository)
        {
            _repository = repository;
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<Seller>> GetAllSellersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Seller> GetSellerByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddSellerAsync(CreateSellerRequest sellerRequest)
        {
            var departament = await _departmentRepository.GetByIdAsync(sellerRequest.DepartamentId);
            if (departament == null)
            {
                throw new Exception("Departament not found.");
            }
            var seller = new Seller
            {
                Name = sellerRequest.Name,
                Email = sellerRequest.Email,
                BirthDate = sellerRequest.BirthDate,
                BaseSalary = sellerRequest.BaseSalary,
                Departament = departament
            };

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
