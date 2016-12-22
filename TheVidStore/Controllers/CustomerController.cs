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
        public ActionResult ById(int id)
        {
            return Content("your id is :" + id);
        }
    }
}