using CarServiceAPP.Models;
using CarServiceAPP.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarServiceAPP.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        ApplicationDbContext _context;
        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [Authorize]
        public ActionResult Index()
        {
            string userName = User.Identity.GetUserName();
            ApplicationUser user = _context.Users.Where(c => c.UserName.Equals(userName)).SingleOrDefault();
            var viewModel = new CarAndCustomerViewModel
            {
                User=user,
                Cars = _context.Cars.ToList()
            };
            return View(viewModel);
        }

    }
}