using SalesWebAPI.Controllers.Requests;
using SalesWebAPI.Models;
using SalesWebAPI.Repositories;
using SalesWebAPI.Services;

public class SalesRecordService : ISalesRecordService
{
    private readonly ISalesRecordRepository _repository;
    private readonly ISellerRepository _sellerRepository;

    public SalesRecordService(ISalesRecordRepository repository, ISellerRepository sellerRepository)
    {
        _repository = repository;
        _sellerRepository = sellerRepository;
    }

    public async Task<IEnumerable<SalesRecord>> GetAllSalesRecordsAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<SalesRecord> GetSalesRecordByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddSalesRecordAsync(CreateSalesRecordRequest salesRecordRequest)
    {
        var seller = await _sellerRepository.GetByIdAsync(salesRecordRequest.SellerId);

        if (seller == null)
        {
            throw new Exception("Seller not found");
        }

        var salesRecord = new SalesRecord
        {
            Date = salesRecordRequest.Date,
            Amount = salesRecordRequest.Amount,
            Status = salesRecordRequest.Status,
            Seller = seller
        };

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
