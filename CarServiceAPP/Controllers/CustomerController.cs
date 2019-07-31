using CarServiceAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarServiceAPP.ViewModels;

namespace CarServiceAPP.Controllers
{
    public class CustomerController : Controller
    {
		ApplicationDbContext _context;

		public CustomerController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		public ActionResult Index(string option = "", string search = "")
        {
            if (option.Equals("Email"))
            {
                if (search.Equals(""))
                    return View(_context.Users.ToList());
                else
                    return View(_context.Users.Where(c => c.Email.Equals(search)).ToList());
            }
            else if (option.Equals("Mobile"))
            {
                if (search.Equals(""))
                    return View(_context.Users.ToList());
                else
                    return View(_context.Users.Where(c => c.PhoneNumber.ToString().Equals(search)).ToList());
            }
            else if (option.Equals("FirstName"))
            {
                if (search.Equals(""))
                    return View(_context.Users.ToList());
                else
                    return View(_context.Users.Where(c => c.FirstName.Equals(search)).ToList());
            }
            else
            {
                return View(_context.Users.ToList());
            }
        }


        public ActionResult EditCustomer(ApplicationUser applicationUser)
        {

            var editCustomer = _context.Users.Where(c=>c.UserName.Equals(applicationUser.UserName)).SingleOrDefault();
            return View(editCustomer);
        }

        public ActionResult SaveEdit(ApplicationUser applicationUser)
        {
            var editCustomer = _context.Users.Where(c => c.UserName.Equals(applicationUser.UserName)).SingleOrDefault();
            editCustomer.FirstName = applicationUser.FirstName;
            editCustomer.LastName = applicationUser.LastName;
            editCustomer.City = applicationUser.City;
            editCustomer.PhoneNumber = applicationUser.PhoneNumber;
            _context.SaveChanges();
            if (HttpContext.User.IsInRole("admin"))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
            
        }

        public ActionResult DeleteCustomerDetails(ApplicationUser applicationUser)
        {
            var deleteCustomer = _context.Users.Find(applicationUser.Id);
            _context.Users.Remove(deleteCustomer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Cars


        public ActionResult ViewDetails(ApplicationUser applicationUser)
		{
            var customerDetails = new CarAndCustomerViewModel()
            {
                User = _context.Users.SingleOrDefault(c => c.Id == applicationUser.Id),

                Cars = _context.Cars.ToList()

            };
                
			return View(customerDetails);
		}

        public ActionResult SearchCustomer(string option="", string search="")
        {
            if (option.Equals("Email"))
            {
                if (search.Equals(""))
                    return View(_context.Users.ToList());
                else
                    return View(_context.Users.Where(c => c.Email.Equals(search)).ToList());
            }
            else if (option.Equals("Mobile"))
            {
                if (search.Equals(""))
                    return View(_context.Users.ToList());
                else
                    return View(_context.Users.Where(c => c.PhoneNumber.ToString().Equals(search)).ToList());
            }
            else if (option.Equals("FirstName"))
            {
                if (search.Equals(""))
                    return View(_context.Users.ToList());
                else
                    return View(_context.Users.Where(c => c.FirstName.Equals(search)).ToList());
            }
            else
            {
                return View(_context.Customers.ToList());
            }
        }
    }
}