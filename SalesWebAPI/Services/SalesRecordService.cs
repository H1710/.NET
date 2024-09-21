using SalesWebAPI.Models;
using SalesWebAPI.Repositories;
using SalesWebAPI.Services;

public class SalesRecordService : ISalesRecordService
{
    private readonly ISalesRecordRepository _repository;

    public SalesRecordService(ISalesRecordRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<SalesRecord>> GetAllSalesRecordsAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<SalesRecord> GetSalesRecordByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddSalesRecordAsync(SalesRecord salesRecord)
    {
        await _repository.AddAsync(salesRecord);
    }

    public async Task UpdateSalesRecordAsync(SalesRecord salesRecord)
    {
        await _repository.UpdateAsync(salesRecord);
    }

    public async Task DeleteSalesRecordAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
