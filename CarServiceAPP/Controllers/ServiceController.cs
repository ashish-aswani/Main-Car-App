using CarServiceAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarServiceAPP.ViewModels;

namespace CarServiceAPP.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            return View();
        }

        ApplicationDbContext _context;
        public ServiceController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Service(Car car)
        {
            var viewModel = new CarAndServiceViewModel
            {
                Cars = car,
                Services = _context.Services.ToList()
            };
            return View(viewModel);
        }

        public ActionResult ServiceForm(Car car)
        {
            var viewModel = new CarAndServiceViewModel
            {
                Cars = car
            };
            return View(viewModel);
        }

        public ActionResult AddService(CarAndServiceViewModel carAndService)
        {
            carAndService.Service.CarId = carAndService.Cars.Id;
            _context.Services.Add(carAndService.Service);
            _context.SaveChanges();
            var car = _context.Cars.Find(carAndService.Cars.Id);
            return RedirectToAction("Service", "Service", car);
        }

        public ActionResult DeleteService(Service service)
        {
            var c = _context.Cars.Find(service.CarId);
            var carServId = _context.Services.Find(service.Id);
            _context.Services.Remove(carServId);
            _context.SaveChanges();

            return RedirectToAction("Service", "Service", c);
        }
    }
}