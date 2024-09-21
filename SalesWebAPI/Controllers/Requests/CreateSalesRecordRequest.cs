using SalesWebAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SalesWebAPI.Controllers.Requests
{
    public class CreateSalesRecordRequest
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public int SellerId { get; set; }

        public CreateSalesRecordRequest()
        {
        }
        public CreateSalesRecordRequest(int id, DateTime date, double amount, SaleStatus status, int sellerId)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            SellerId = sellerId;
        }
    }
}
