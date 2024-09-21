using SalesWebAPI.Models;
using SalesWebAPI.Repositories;

namespace SalesWebAPI.Services
{
    public class DepartamentService : IDepartamentService
    {
        private readonly IDepartamentRepository _repository;

        public DepartamentService(IDepartamentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Departament>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Departament> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Departament departament)
        {
            await _repository.AddAsync(departament);
        }

        public async Task UpdateAsync(Departament departament)
        {
            await _repository.UpdateAsync(departament);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public bool DepartamentExists(int id)
        {
            return _repository.DepartamentExists(id);
        }
    }
}
