using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.Models.ViewModels;
namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {


        private VidlyDBContext _context;

        public CustomersController()
        {
            _context = new VidlyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult New() {

            var membershipTypes = _context.MembershipTypes.ToList();
            NewCustomerViewModel viewModel = new NewCustomerViewModel {
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            

            return RedirectToAction("Index","Customers");
        }

        // GET: Customer
        public ActionResult Index()
        {

            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }
        public ActionResult Details(int id) {

            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}