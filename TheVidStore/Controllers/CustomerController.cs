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








        // GET: customer/Det
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






        // GET: customer

        public ViewResult Index()
        {
            var customers = _context.Customres.Include(c => c.MembershipType).ToList();
            return View(customers);
        }







        public ActionResult New()
        {
            var MembershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = MembershipTypes
            };
            return View("CustomerForm", viewModel);
        }







        // GET: customer/Edit/{Id}

        public ActionResult Edit(int Id)
        {
            var Customer = _context.Customres.SingleOrDefault(c => c.Id == Id);
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
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customres.Add(customer);
            }

            else
            {
                var customerInDb = _context.Customres.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.DateOfBirth = customer.DateOfBirth;
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