using SalesWebAPI.Models;

namespace SalesWebAPI.Repositories
{
    public interface ISalesRecordRepository
    {
        Task<IEnumerable<SalesRecord>> GetAllAsync();
        Task<SalesRecord> GetByIdAsync(int id);
        Task AddAsync(SalesRecord salesRecord);
        Task UpdateAsync(SalesRecord salesRecord);
        Task DeleteAsync(int id);
    }

}
