﻿using System;
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
                Customers = customer
            };
			return View(viewModel);
		}

		public ActionResult AddCar(CarCustomer carCustomer)
		{

            if (carCustomer.Cars.Id == 0)
            {
                carCustomer.Cars.CustomerId = carCustomer.Customers.Id;
                _context.Cars.Add(carCustomer.Cars);
            }
            else
            {
                var carInDb = _context.Cars.Single(c => c.Id == carCustomer.Cars.Id);
                carInDb.VIN = carCustomer.Cars.VIN;
                carInDb.Make = carCustomer.Cars.Make;
                carInDb.Model = carCustomer.Cars.Model;
                carInDb.Style = carCustomer.Cars.Style;
                carInDb.Year = carCustomer.Cars.Year;
            }
            _context.SaveChanges();
			return RedirectToAction("ViewDetails", "Customer",carCustomer.Customers);
            
		}

        public ActionResult EditCar(CarCustomer carCustomer)
        {
            var editCar = _context.Cars.Find(carCustomer.Cars.Id);
            if (carCustomer == null)
                return HttpNotFound();
            else
            {
                carCustomer.Cars = editCar;
                return View("CarForm", carCustomer);
            }
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