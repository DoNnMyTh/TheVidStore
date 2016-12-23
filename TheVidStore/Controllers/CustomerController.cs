using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheVidStore.Models;
using TheVidStore.ViewModels;

namespace TheVidStore.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: customer/Details
        public ActionResult Details()
        {
            var customers = new List<Customer>
            {
                new Customer {Name = "amit" },
                new Customer {Name = "ghanu" },
                new Customer {Name = "ashish" },
                new Customer {Name = "adi" }
            };
            var viewModel = new ByIdViewModel
            {
                customer = customers
            };
            return View(viewModel);
        }

        public ActionResult Det(int id)
        {
            var customers = _context.Customres.SingleOrDefault(c => c.Id == id);
            {
                if (customers == null)
                    return HttpNotFound();
                else
                    return View(customers);
            };
        }
        public ActionResult ById(int id)
        {
            return Content("your id is :" + id);
        }
        public ViewResult Index()
        {
            var customer = _context.Customres.ToList();
            return View(customer);
        }
    }
}