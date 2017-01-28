using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheVidStore.Models;
using TheVidStore.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

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








        // GET: customer/Det/{Id}
        public ActionResult Det(int id)
        {
            var customers = _context.Customers.SingleOrDefault(c => c.Id == id);
            {
                if (customers == null)
                    return HttpNotFound();
                else
                    return View(customers);
            };
        }






        // GET: customer

        public ViewResult Index()
        {
            return View();
        }







        public ActionResult New()
        {
            var MembershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Customer = new Customer(),
                MembershipTypes = MembershipTypes
            };
            return View("CustomerForm", viewModel);
        }







        // GET: customer/Edit/{Id}

        public ActionResult Edit(int Id)
        {
            var Customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (Customer == null)
            {
                return HttpNotFound();
            }
            var ViewModel = new NewCustomerViewModel
            {
                Customer = Customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", ViewModel);
        }







        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (    !ModelState.IsValid)
            {
                var ViewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", ViewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }

            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipType = customer.MembershipType;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex);
            }

            return RedirectToAction("Index", "Customer");
        }





    }
}