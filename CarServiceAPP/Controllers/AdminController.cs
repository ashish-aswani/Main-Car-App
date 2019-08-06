using CarServiceAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarServiceAPP.ViewModels;

namespace CarServiceAPP.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ActionResult Index()
        {
            var viewModel = new Admin
            {
                CarMakes = _context.CarMakes.ToList(),
                CarStyles = _context.CarStyles.ToList(),
                ServiceTypes = _context.ServiceTypes.ToList()
            };
            return View(viewModel);
        }

        public ActionResult AddMake(Admin admin)
        {
            _context.CarMakes.Add(admin.CarMake);
            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult DeleteMake(int? id)
        {
            var deleteMake = _context.CarMakes.Find(id);
            _context.CarMakes.Remove(deleteMake);
            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }


        public ActionResult AddStyle(Admin admin)
        {
            _context.CarStyles.Add(admin.CarStyle);
            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult DeleteStyle(int? id)
        {
            var deleteStyle = _context.CarStyles.Find(id);
            _context.CarStyles.Remove(deleteStyle);
            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult AddServiceType(Admin admin)
        {
            _context.ServiceTypes.Add(admin.ServiceType);
            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult DeleteServiceType(int? id)
        {
            var deleteServiceType = _context.ServiceTypes.Find(id);
            _context.ServiceTypes.Remove(deleteServiceType);
            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
    }
}