using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Models;

namespace VideoStore.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Customers
        public ActionResult Index()
        {
            //var customers = GetCustomers();
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }
        
        public ActionResult New()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        public IEnumerable<Customer> GetCustomers()
        {
            var results = new List<Customer>
            {
                new Customer{ Id = 1, Name = "Kemi Campbell"},
                new Customer{ Id = 2, Name = "Walter Campbell"},
                new Customer{ Id = 3, Name = "Wunmi Sobomehin"},
                new Customer{ Id = 4, Name = "Heather McKenzie"},
                new Customer{ Id = 5, Name = "Olabodunrin Sobomehin"},
                new Customer{ Id = 6, Name = "Olasupo Sobomehin"},
                new Customer{ Id = 7, Name = "Kristyn Booth"}
            };
            return results;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}