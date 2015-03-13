using S00127670_CA1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S00127670_CA1.Controllers
{
    public class HomeController : Controller
    {
        public CollegeDb db = new CollegeDb();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(db.college);
        }
    }
}
