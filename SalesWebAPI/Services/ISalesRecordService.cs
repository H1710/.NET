using SalesWebAPI.Controllers.Requests;
using SalesWebAPI.Models;

namespace SalesWebAPI.Services
{
    public interface ISalesRecordService
    {
        Task<IEnumerable<SalesRecord>> GetAllSalesRecordsAsync();
        Task<SalesRecord> GetSalesRecordByIdAsync(int id);
        Task AddSalesRecordAsync(CreateSalesRecordRequest salesRecord);
        Task UpdateSalesRecordAsync(SalesRecord salesRecord);
        Task DeleteSalesRecordAsync(int id);
    }

}
