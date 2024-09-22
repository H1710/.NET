using SalesWebAPI.Data;
using SalesWebAPI.Models;
using SalesWebAPI.Models.Enums;

namespace SalesWebAPI.Data
{
    public class SeedingService
    {
        private readonly SalesWebMvcContext _context;

        // Inject the context via the constructor
        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            Console.WriteLine("Seeding started...");

            if (_context.Departament.Any() || _context.Seller.Any() || _context.SalesRecord.Any() || _context.Notes.Any())
            {
                Console.WriteLine("Data already exists, skipping seeding.");
                return; // Database has already been seeded, no need to run again
            }

            // Seed Departaments (without specifying Ids)
            var d1 = new Departament { Name = "Computers" };
            var d2 = new Departament { Name = "Electronics" };
            var d3 = new Departament { Name = "Fashion" };
            var d4 = new Departament { Name = "Books" };

            // Seed Sellers (without specifying Ids)
            var s1 = new Seller { Name = "Bob Brown", Email = "bob@gmail.com", BirthDate = new DateTime(1998, 4, 21), BaseSalary = 1000.0, Departament = d1 };
            var s2 = new Seller { Name = "Maria Green", Email = "maria@gmail.com", BirthDate = new DateTime(1979, 12, 31), BaseSalary = 3500.0, Departament = d2 };
            var s3 = new Seller { Name = "Alex Grey", Email = "alex@gmail.com", BirthDate = new DateTime(1988, 1, 15), BaseSalary = 2200.0, Departament = d1 };
            var s4 = new Seller { Name = "Victor Vinicius", Email = "victorvinicius@gmail.com", BirthDate = new DateTime(2000, 6, 21), BaseSalary = 3000.0, Departament = d4 };
            var s5 = new Seller { Name = "Pedro Henrique", Email = "pedrohenrique@gmail.com", BirthDate = new DateTime(2006, 5, 24), BaseSalary = 4000.0, Departament = d3 };
            var s6 = new Seller { Name = "Alex Pink", Email = "bob@gmail.com", BirthDate = new DateTime(1997, 3, 4), BaseSalary = 3000.0, Departament = d2 };

            // Seed SalesRecords (without specifying Ids)
            var r1 = new SalesRecord { Date = new DateTime(2018, 09, 25), Amount = 11000.0, Status = SaleStatus.Billed, Seller = s1 };

            // Seed Notes (without specifying Ids)
            var n1 = new Notes { Title = "Meeting Notes", Content = "Discussed project timeline and deliverables." };
            var n2 = new Notes { Title = "Workshop Summary", Content = "Key learnings from the ReactJS workshop." };
            var n3 = new Notes { Title = "Todo List", Content = "1. Update documentation\n2. Refactor codebase." };
            var n4 = new Notes { Title = "Client Feedback", Content = "Positive feedback from the latest release." };

            // Add all seed data to the context
            _context.Departament.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecord.AddRange(r1);
            _context.Notes.AddRange(n1, n2, n3, n4);

            // Save changes to persist seed data in the database
            _context.SaveChanges();
            Console.WriteLine("Seeding completed.");
        }

    }
}
