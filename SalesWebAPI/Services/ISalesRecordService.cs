using SalesWebAPI.Models;

namespace SalesWebAPI.Services
{
    public interface ISalesRecordService
    {
        Task<IEnumerable<SalesRecord>> GetAllSalesRecordsAsync();
        Task<SalesRecord> GetSalesRecordByIdAsync(int id);
        Task AddSalesRecordAsync(SalesRecord salesRecord);
        Task UpdateSalesRecordAsync(SalesRecord salesRecord);
        Task DeleteSalesRecordAsync(int id);
    }

}
