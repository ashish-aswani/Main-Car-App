using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarServiceAPP.Models;

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

		public ActionResult CarForm(Car car)
		{
			return View(car);
		}

		public ActionResult AddCar(Car car)
		{
			if (car.Id == 0)
				_context.Cars.Add(car);
			else
			{
				var carInDb = _context.Cars.Single(c => c.Id == car.Id);
				carInDb.VIN = car.VIN;
				carInDb.Make = car.Make;
				carInDb.Model = car.Model;
				carInDb.Style = car.Style;
				carInDb.Year = car.Year;
			}
			_context.SaveChanges();
			return RedirectToAction("ViewDetails", "Customer");
		}
    }
}