using SalesWebAPI.Models;
using SalesWebAPI.Models.Enums;

namespace SalesWebAPI.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Departament.Any() || _context.Seller.Any() || _context.SalesRecord.Any() || _context.Notes.Any())
            {
                return; // DB has been seeded
            }

            // Departaments
            Departament d1 = new Departament(1, "Computers");
            Departament d2 = new Departament(2, "Eletronics");
            Departament d3 = new Departament(3, "Fashion");
            Departament d4 = new Departament(4, "Books");

            // Sellers
            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            Seller s3 = new Seller(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
            Seller s4 = new Seller(4, "Victor Vinicius", "victorvinicius@gmail.com", new DateTime(2000, 6, 21), 3000.0, d4);
            Seller s5 = new Seller(5, "Pedro Henrique", "pedrohenrique@gmail.com", new DateTime(2006, 5, 24), 4000.0, d3);
            Seller s6 = new Seller(6, "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

            // SalesRecords
            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed, s1);
            // ... add other SalesRecords ...

            // Notes
            Notes n1 = new Notes { Id = 1, Title = "Meeting Notes", Content = "Discussed project timeline and deliverables." };
            Notes n2 = new Notes { Id = 2, Title = "Workshop Summary", Content = "Key learnings from the ReactJS workshop." };
            Notes n3 = new Notes { Id = 3, Title = "Todo List", Content = "1. Update documentation\n2. Refactor codebase." };
            Notes n4 = new Notes { Id = 4, Title = "Client Feedback", Content = "Positive feedback from the latest release." };

            _context.Departament.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecord.AddRange(r1);
            _context.Notes.AddRange(n1, n2, n3, n4);

            _context.SaveChanges();
        }
    }
}
