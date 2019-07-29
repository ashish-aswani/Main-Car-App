using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarServiceAPP.Models;
using CarServiceAPP.ViewModels;

namespace CarServiceAPP.Controllers
{
    public class CarController : Controller
    {
		// GET: Car

		ApplicationDbContext _context;

		public CarController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}


		public ActionResult Index()
        {
            return View();
        }

		public ActionResult CarForm(Customer customer)
		{

            var viewModel = new CarCustomer()
            {
                Customers = customer,
                CarMakes = _context.CarMakes.ToList(),
                CarStyles = _context.CarStyles.ToList()
            };
			return View(viewModel);
		}

		public ActionResult AddCar(CarCustomer carCustomer)
		{
                carCustomer.Cars.CustomerId = carCustomer.Customers.Id;
                _context.Cars.Add(carCustomer.Cars);

            _context.SaveChanges();
			return RedirectToAction("ViewDetails", "Customer",carCustomer.Customers);
            
		}


        public ActionResult EditCar(Car car)
        {

            var c = _context.Cars.Find(car.Id);
            return View(c);

          
        }

        public ActionResult SaveEdit(Car car)
        {
            var editCar = _context.Cars.Find(car.Id);

            editCar.VIN = car.VIN;
            editCar.Make = car.Make;
            editCar.Model = car.Model;
            editCar.Style = car.Style;
            editCar.Year = car.Year;
            _context.SaveChanges();
            var customer = _context.Customers.Find(editCar.CustomerId);
            return RedirectToAction("ViewDetails","Customer",customer);
          
        }
        public ActionResult DeleteCar(Car car)
        {
            var deleteCar = _context.Cars.Find(car.Id);
            var id = car.CustomerId;
            _context.Cars.Remove(deleteCar);
            _context.SaveChanges();
            var customer = _context.Customers.Find(id);
            return RedirectToAction("ViewDetails", "Customer",customer);
        }
    }
}