using CarServiceAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
		public ActionResult Index()
        {
			var customers = _context.Customers.ToList();
            return View(customers);
        }

		public ActionResult CustomerForm(Customer customer)
		{
			
			return View(customer);
		}

		public ActionResult RegisterCustomer(Customer customer)
		{
			if (customer.Id == 0)
				_context.Customers.Add(customer);
			else
			{
				var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
				customerInDb.FirstName = customer.FirstName;
				customerInDb.LastName = customer.LastName;
				customerInDb.Email = customer.Email;
				customerInDb.Mobile = customer.Mobile;
				customerInDb.City = customer.City;
			}
			_context.SaveChanges();
			return RedirectToAction("Index", "Customer");
		}

		public ActionResult EditCustomer(Customer customer)
		{
			var editCustomer = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
			if (customer == null)
				return HttpNotFound();
			else
			{
				return View("CustomerForm", customer);
			}
		}

		public ActionResult DeleteCustomerDetails(Customer customer)
		{
			var deleteCustomer = _context.Customers.Find(customer.Id);
			_context.Customers.Remove(deleteCustomer);
			_context.SaveChanges();

			return RedirectToAction("Index", "Customer");
		}

		// Cars

		public ActionResult ViewDetails(int? id)
		{
			var customerDetails = _context.Customers;
			return View(customerDetails.SingleOrDefault(c => c.Id == id));

		}

	}
}