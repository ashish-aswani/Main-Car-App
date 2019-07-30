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

		public ActionResult CarForm(ApplicationUser applicationUser)
		{

            var viewModel = new CarCustomer()
            {
                ApplicationUsers = applicationUser,
                CarMakes = _context.CarMakes.ToList(),
                CarStyles = _context.CarStyles.ToList()
            };
			return View(viewModel);
		}

		public ActionResult AddCar(CarCustomer carCustomer)
		{
                carCustomer.Cars.ApplicationUserId = carCustomer.ApplicationUsers.Id;
                _context.Cars.Add(carCustomer.Cars);

            _context.SaveChanges();
			return RedirectToAction("ViewDetails", "Customer",carCustomer.ApplicationUsers);
            
		}


        public ActionResult EditCar(Car car)
        {
           
            //var c = _context.Cars.Find(car.Id);
            var viewModel = new CarCustomer
            {
                Cars = car,
                CarMakes = _context.CarMakes.ToList(),
                CarStyles = _context.CarStyles.ToList()
            };
            return View(viewModel);  
        }

        [HttpPost]
        public ActionResult EditCar(CarCustomer viewModel)
        {
            

            using(var db=new ApplicationDbContext())
            {
                var editCar = db.Cars.Find(viewModel.Cars.Id);
                editCar.VIN = viewModel.Cars.VIN;
                editCar.Make = viewModel.Cars.Make;
                editCar.Model = viewModel.Cars.Model;
                editCar.Style = viewModel.Cars.Style;
                editCar.Year = viewModel.Cars.Year;
                db.SaveChanges();
            }
            
            var user = _context.Users.Find(viewModel.Cars.ApplicationUserId);
            return RedirectToAction("ViewDetails","Customer",user);
          
        }
        public ActionResult DeleteCar(Car car)
        {
            var deleteCar = _context.Cars.Find(car.Id);
            var id = car.ApplicationUserId;
            _context.Cars.Remove(deleteCar);
            _context.SaveChanges();
            var user = _context.Users.Find(id);
            return RedirectToAction("ViewDetails", "Customer",user);
        }
    }
}