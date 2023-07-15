using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger_Assignment.EF;
using ZeroHunger_Assignment.EF.Models;

namespace ZeroHunger_Assignment.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            ZeroHungerContext db = new ZeroHungerContext();
            var cr = (List<CollectRequest>)Session["cart"];
            return View(cr);


        }
    }
}