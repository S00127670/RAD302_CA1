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
            ViewBag.Football = db.college.Count(st => st.sportsTeams == SportsTeams.Football);
            ViewBag.Hurling = db.college.Count(st => st.sportsTeams == SportsTeams.Hurling);
            ViewBag.Soccer = db.college.Count(st => st.sportsTeams == SportsTeams.Soccer);
            ViewBag.Rugby = db.college.Count(st => st.sportsTeams == SportsTeams.Rugby);
            ViewBag.Swimming = db.college.Count(st => st.sportsTeams == SportsTeams.Swimming);
            return View(db.college);
        }
    }
}
