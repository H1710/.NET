using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models
{
    public class Departament
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Departament()
        {
        }
        public Departament(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSellers(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
